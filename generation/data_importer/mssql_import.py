#!/usr/bin/python3
import json
from types import SimpleNamespace
from sql.TableDetails import TableDetails
from sql.IdentityDetails import IdentityDetails
from sql.BaseSqlAlchemyImporter import BaseSqlAlchemyImporter
from sql.MSSqlAlchemyImporter import MSSqlAlchemyImporter

importer = MSSqlAlchemyImporter("import.json")
importer.load_config()

importer.config.table_details = importer.generate_table_models(importer.config.import_tables)
importer.save_config()