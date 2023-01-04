import sqlalchemy as db
from sql.BaseSqlAlchemyImporter import BaseSqlAlchemyImporter

class MSSqlAlchemyImporter(BaseSqlAlchemyImporter):
    def __init__(self, config_path):
        print("MSSqlAlchemyImporter")
        super().__init__(config_path)


    def return_data_type(self, data_type):
        # convert types to match the types in the database. Not sure if this could be in the base class
        if type(data_type) is db.types.NVARCHAR or type(data_type) is db.types.VARCHAR:
            return "string"
        elif type(data_type) is db.types.INTEGER:
            return "Int32"
        elif type(data_type) is db.types.SMALLINT:
            return "Int16"
        elif type(data_type) is db.types.DECIMAL or type(data_type) is db.sql.sqltypes.NUMERIC:
            return "decimal"
        elif type(data_type) is db.dialects.mssql.base.DATETIME2 or type(data_type) is db.sql.sqltypes.DATETIME:
            return "DateTime"
        elif type(data_type) is db.dialects.mssql.base.REAL:
            return "real"
        elif type(data_type) is db.dialects.mssql.base.VARBINARY or type(data_type) is db.sql.sqltypes.BINARY:
            return "byte[]"
        elif type(data_type) is db.dialects.mssql.base.BIT:
            return "bool"
        elif type(data_type) is db.dialects.mssql.base.DATETIMEOFFSET:
            return "DateTimeOffset"
        elif type(data_type) is db.sql.sqltypes.BIGINT:
            return "long"
        elif type(data_type) is db.dialects.mssql.base.UNIQUEIDENTIFIER:
            return "Guid"
        elif type(data_type) is db.sql.sqltypes.FLOAT:
            return "float"
        elif type(data_type) is db.dialects.mssql.base.TIME:
            return "TimeSpan"
        elif type(data_type) is db.dialects.mssql.base.MONEY:
            return "decimal"
        else:
            print(type(data_type))
        return data_type

    def return_schema(self, schema_name):
        # print(foreign_key['referred_schema'])
        if schema_name is not None:
            return schema_name
        return "dbo"
