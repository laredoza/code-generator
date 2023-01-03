from _templates.generator import BaseGenerator
from _templates.generator.template_helpers import convert_to_case
from jinja2 import Environment, FileSystemLoader, Template, PackageLoader
import json
import glob
from types import SimpleNamespace
import os
from re import sub
import stringcase

def return_relationships_with_valid_columns(table, tables):
    relationships = []
    for relationship in table.relationships:
        if relationship.render == True:
            for o in tables:
                if o.schema_name == relationship.schema_name and o.table_name == relationship.referenced_table_name:
                    relationships.append(relationship)

    return relationships

def return_parent_relationships(table, tables, relationship):
    result = []
    for model in tables:
        return next(
            (o for o in model.relationships
                if o.referenced_table_name == table.table_name
                and model.table_name == relationship.referenced_table_name
                and o.schema_name == relationship.schema_name
                and o.column_name == relationship.referenced_column_name
                and o.referenced_column_name == relationship.column_name
             ), None)

class EFCoreEntityConfigurationGenerator(BaseGenerator.BaseGenerator):
    def __init__(self, collection, drivers, namingConvention, domain, project_data, template, template_dir):
        self.template = template
        self.template_dir = template_dir
        super().__init__(collection, drivers, namingConvention, domain, project_data, template)

    def run_core(self):
        lookup_template = next(
            (x for x in self.project_data.templates if x.id == self.template.id), None)
        for driver in self.domain.driverId:
            driver_lookup = next(
                (x for x in self.project_data.drivers if x.id == driver), None)
            self.generate_contexts(driver_lookup, lookup_template)

    # def return_context(self, lookup_template):
    #     for file in glob.glob(f"{self.template_dir}/{lookup_template.template}/context.json"):
    #         f = open(file)
    #         data = json.loads(
    #             f.read(), object_hook=lambda d: SimpleNamespace(**d))
    #         f.close()
    #         return data

    def return_template(self, loaded_template, lookup_template):
        j2_enviroment = Environment(loader=FileSystemLoader(
            f"{self.template_dir}/{lookup_template.template}"))
        j2_enviroment.filters["convert_to_case"] = convert_to_case
        j2_enviroment.filters["return_relationships_with_valid_columns"] = return_relationships_with_valid_columns
        j2_enviroment.filters["return_parent_relationships"] = return_parent_relationships
        return j2_enviroment.from_string(loaded_template)

    def load_data(self, lookup_template):
        for file in glob.glob(f"{self.template_dir}/{lookup_template.template}/data.json"):
            f = open(file)
            data = json.loads(
                f.read(), object_hook=lambda d: SimpleNamespace(**d))
            f.close()
            return data

    def generate_contexts(self, driver, lookup_template):
        print("Generating Entity Configuration")
        for file_path in glob.glob(f"{self.template_dir}/{lookup_template.template}/*.j2"):
            with open(file_path) as file:
                loaded_template = file.read()
                j2_template = self.return_template(
                    loaded_template, lookup_template)
                entity = self.load_data(lookup_template)
                for table in self.project_data.tables:
                    namespace = f"{self.project_data.base_namespace}.{self.template.namespace}.FullContext"

                    # These are the referenced objects
                    foreign_relationships = [
                        relationship for relationship in table.relationships if relationship.relationship == "ForeignKey"]
                    # These represent the objects referencing this object
                    foreign_relationships_children = [
                        relationship for relationship in table.relationships if relationship.relationship == "ForeignKeyChild"]
                    primary_key_columns = [
                        column for column in table.columns if column.is_primary_key == True]

                    processed_template = j2_template.render(
                        driver=driver,
                        table=table,
                        namespace=namespace,
                        entity=entity,
                        domain=self.domain,
                        foreign_relationships=foreign_relationships,
                        foreign_relationships_children=foreign_relationships_children,
                        primary_key_columns=primary_key_columns,
                        tables=self.project_data.tables
                    )
                    # print(processed_template)
                    save_file_path = f"{self.project_data.basePath}/{self.template.base_path}/FullContext/{convert_to_case(table.table_name, self.domain.namingConvention)}EntityConfiguration.g.cs"
                    os.makedirs(os.path.dirname(
                        save_file_path), exist_ok=True)
                    with open(save_file_path, mode="w", encoding="utf-8") as message:
                        message.write(processed_template)