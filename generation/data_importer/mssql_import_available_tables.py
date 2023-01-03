#!/usr/bin/python3
import json
from types import SimpleNamespace
from sql.TableDetails import TableDetails
from sql.IdentityDetails import IdentityDetails
from sql.BaseSqlAlchemyImporter import BaseSqlAlchemyImporter
from sql.MSSqlAlchemyImporter import MSSqlAlchemyImporter

importer = MSSqlAlchemyImporter("import.json")
importer.load_config()

importer.config.import_tables = importer.return_tables(importer.config.import_schemas)
importer.save_config()