import sqlalchemy as db
import json
from types import SimpleNamespace
from sqlalchemy import MetaData, Table
from sqlalchemy.engine import URL, reflection
from sql.IdentityDetails import IdentityDetails
from sql.TableDetails import TableDetails

class BaseSqlAlchemyImporter:
    def __init__(self, config_path):
        self.config_path = config_path
    
    def load_config(self):
        with open(self.config_path) as json_file:
            self.config = json.loads(json_file.read(), object_hook=lambda d: SimpleNamespace(**d))
            self.connection_url = URL.create(
                "mssql+pyodbc", query={"odbc_connect": self.config.connection_string})
            self.engine = db.create_engine(self.connection_url)   
                 
    def save_config(self):
        with open(self.config_path, 'w') as outfile:
            outfile.write(json.dumps(self.config, indent=4, default=lambda o: o.__dict__))
    
    def return_schemas(self, engine):
        insp = db.inspect(engine)
        schemas = insp.get_schema_names()
        for schema in self.config.exclude_schemas:
            schemas.remove(schema)
        return schemas

    def return_data_type(self, data_type):
        print("Returning Data Type")

    def return_schema(self, schema_name):
        print("Returning Schema")

    def return_tables(self, schemas):
        tables = []
        for schema in schemas:
            metadata = MetaData(schema=schema)
            metadata.reflect(bind=self.engine)
            for table in metadata.tables:
                table_name = table.split('.')[1]
                tables.append(
                    TableDetails(schema, table_name)
                )
                # print(f"Schema: {schema}, Table: {table_name}")
        return tables

    def return_column_length(self, data_type):
        # This is a hack to get around the fact that the length is not returned for some data types
        try:
            return data_type.length
        except:
            return 0

    def return_column_precision(self, data_type):
        # This is a hack to get around the fact that the precision is not returned for some data types
        try:
            return data_type.precision
        except:
            return 0

    def return_column_scale(self, data_type):
        # This is a hack to get around the fact that the precision is not returned for some data types
        try:
            return data_type.scale
        except:
            return 0

    def return_identity(self, column):
        #     server_default=Identity(start=1, increment=1))
        try:
            result = IdentityDetails(False, 0, 0)
            if column.server_default is not None and type(column.server_default) is db.sql.schema.Identity:
                print("Identity:", type(column.server_default))
                result.is_identity = True
                result.seed = column.server_default.start
                result.increment = column.server_default.increment
                return result
            else:
                return result
        except:
            return result

    def generate_columns_model(self, table_details):
        print("Generate Column Models")
        columns = []
        column_index = 0
        for column in table_details.columns:
            column_index += 1
            # test identity, current database doesn't have any
            identity_details = self.return_identity(column)
            columns.append(
                {
                    "column_name": column.name,
                    "alias": column.name,
                    "column_order": column_index,
                    "data_type": self.return_data_type(column.type),
                    "is_primary_key": column.primary_key,
                    "is_required": column.nullable == False,
                    "length": self.return_column_length(column.type),
                    "precision": self.return_column_precision(column.type),
                    "scale": self.return_column_scale(column.type),
                    "is_identity": identity_details.is_identity,
                    "identity_seed": identity_details.seed,
                    "identity_increment": identity_details.increment
                })
            # print(column)
        return columns

    def return_index_type(self, index):
        # print("Index Type:", index.columns[0].primary_key)
        if index.columns[0].primary_key:
            return "PrimaryKey"
        else:
            return "NonClustered"
        return index

    def generate_indexes_model(self, table_details):
        print("Generate Index Models")
        results = []
        for index in table_details.indexes:
            column_results = []
            for column in index.columns:
                column_results.append(
                    column.name
                )
            result = {
                "index_type": self.return_index_type(index),
                "is_unique": index.unique,
                "name": index.name,
                "columns": column_results
            }
            # print("Index:", index)

            results.append(result)
        return results

    def calculate_multiplicity(self, foreign_key, table_details):
        column = table_details.columns[foreign_key['constrained_columns'][0]]
        if (column.primary_key):
            return "ZeroToOne"
        else:
            return "Many"

    def calculate_referenced_multiplicity(self, foreign_key, table_details):
        column = table_details.columns[foreign_key['constrained_columns'][0]]
        if (column.nullable):
            return "ZeroToOne"
        else:
            return "One"

    def generate_relationship_models(self, table_details, engine, table_name):
        print("Generating relationships")
        relationships = []
        insp = reflection.Inspector.from_engine(engine)
        for foreign_key in insp.get_foreign_keys(table_name):
            relationships.append(
                {
                    "column_name": foreign_key['constrained_columns'][0],
                    "relationship": "ForeignKey",
                    "referenced_column_name": foreign_key['referred_columns'][0],
                    "render": True,
                    "schema_name": self.return_schema(foreign_key['referred_schema']),
                    "referenced_table_name": foreign_key['referred_table'],
                    "multiplicity": self.calculate_multiplicity(foreign_key, table_details),
                    "referenced_multiplicity": self.calculate_referenced_multiplicity(foreign_key, table_details),
                    "user_relationship": False,
                    "relationship_name": foreign_key["name"]
                }
            )
            # print(foreign_key)
        return relationships

    def generate_table_model(self, table, engine):
        print(f"Generate Table Models - {table.schema}.{table.name}")
        result = {}
        schema = table.schema
        table_name = table.name
        metadata = MetaData(schema=schema)
        table_details = Table(
            table.name, metadata, autoload_with=engine)
        result["description"] = table_details.description
        result["schema_name"] = schema
        result["table_name"] = table_name
        result["alias"] = table_name 
        result["enabled_for_code_generation"] = True
        result["columns"] = self.generate_columns_model(table_details)
        result["indexes"] = self.generate_indexes_model(table_details)
        result["relationships"] = self.generate_relationship_models(
            table_details, engine, table_name)
        return result

    def return_tables_referenced(self, tables, engine):
        # this is only going one level deep, might need to be recursive. Not sure if I want that?
        insp = reflection.Inspector.from_engine(engine)
        for table in tables:
            for foreign_key in insp.get_foreign_keys(table.name):
                table_found = next((item for item in tables if item.name ==
                                    foreign_key['referred_table'] and item.schema == self.return_schema(foreign_key['referred_schema'])), None)
                if table_found is None:
                    tables.append(TableDetails(
                        self.return_schema(foreign_key['referred_schema']), foreign_key['referred_table']))
                    # print(f"Found{foreign_key['referred_schema']}.{foreign_key['referred_table']}")

    def generate_foreign_key_children_relationships(self, table, generated_models, engine):
        insp = reflection.Inspector.from_engine(engine)
        for foreign_key in insp.get_foreign_keys(table["table_name"]):
            referenced_table = next((item for item in generated_models if item["table_name"] == foreign_key[
                                    'referred_table'] and self.return_schema(item["schema_name"]) == self.return_schema(foreign_key['referred_schema'])), None)
            foreign_key_model = next(
                (item for item in table["relationships"] if item["relationship_name"] == foreign_key['name']), None)
            print("fk_model", foreign_key_model)
            referenced_table["relationships"].append(
                {
                    "column_name": foreign_key['referred_columns'][0],
                    "relationship": "ForeignKeyChild",
                                    "referenced_column_name": foreign_key['constrained_columns'][0],
                                    "render": True,
                    "schema_name": self.return_schema(table['schema_name']),
                    "referenced_table_name": table['table_name'],
                                    "multiplicity": foreign_key_model["referenced_multiplicity"],
                                    "referenced_multiplicity": foreign_key_model["multiplicity"],
                                    "user_relationship": False,
                                    "relationship_name": f"{foreign_key_model['relationship_name']}_child"
                }
            )

    def generate_table_models(self, tables):
        results = []
        self.return_tables_referenced(tables, self.engine)
        for table in tables:
            print(f"Generate Table Models - {table.schema}.{table.name}")
            results.append(self.generate_table_model(table, self.engine))

        for table in results:
            self.generate_foreign_key_children_relationships(
                table, results, self.engine)
        return results
