# Code Generator 
## Simple, highly flexible project scaffolding tool using Python and Jinja2
It is designed to make the creation of new projects as simple as possible by being able to get the required metadata from several sources. This metadata is stored in a JSON file and is used to generate the project files. The metadata can be provided by the user or by the tool itself. The tool can also be used to generate files for existing projects.

Once the metadata is collected, the tool uses Jinja2 to generate the project files. Jinja2 is a template engine for Python. It is designed to be easy to use and flexible. It is also very powerful and can be used to generate any type of file. 

Select a package to determine what the output will be. Each package consists of template modules. Each template module consists of jinja2 and data files. These will render a layer i.e) entities.
### As an example, the Dotnet WebApi Domain Driven Design package:
- [x] Context ( Entity Framework Core 7.0 )
- [x] Entities
- [x] Repository Layer
- [x] Application Service
- [ ] AutoMapper
- [ ] Models 
- [ ] Controllers
### Package Types:
- [x] Dotnet WebApi Domain Driven Design 
- [ ] Python FastApi Domain Driven Design  
- [ ] Next.js Domain Driven Design   

**Note:** The tool is still in development and is not yet ready for production use.
# Importing Schemas
## Importing project data is possible from the following sources:
- [x] MSSQL database / Sqlalchemy (ODBC)
- [ ] MySQL database / Sqlalchemy
- [ ] PostgreSQL database / Sqlalchemy
- [ ] UI 
## Importing from a database
1. Open the data_importer directory: cd ./generation/data_importer
2. Create a configuration file: cp ~import.json import.json
3. Update the connection_string in the configuration file
4. Update import_schemas in the configuration file. This specifies which schema's tables to import. Run ./mssql_import_available_schemas.py to import all the schemas from the database. Remove the schemas that you don't want to import from the import.json file.
5. Update import_tables in the configuration file. This specifies which tables to import. Run ./mssql_import_available_tables.py to import all the tables in the selected schemas from the database. Remove the tables that you don't want to import from the import.json file.
6. Import selected table details: ./mssql_import.py
# Generating the projects from the imported data
Todo: Add instructions for generating the projects from the imported data
```
python3 ./generation/generate.py
```