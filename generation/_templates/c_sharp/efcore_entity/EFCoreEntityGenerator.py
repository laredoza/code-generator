from _templates.generator import BaseGenerator
from _templates.generator.template_helpers import convert_to_case
from jinja2 import Environment, FileSystemLoader, Template, PackageLoader
import json
import glob
from types import SimpleNamespace
import os
from re import sub
import stringcase


def map_to_output_type(column):

    # https://stackoverflow.com/questions/44193823/get-existing-table-using-sqlalchemy-metadata
    # db_type = column.RemapDataType if column.RemapDataType else column.DomainDataType
    result = column.data_type
    # db_type = 1

    # result = ""

    # todo: map types
    if result == "String":
        result = "string"
    if result == "Int32":
        result = "int"

    if column.is_required == False and result != "string":
        result = f"{result}?"
    print("Column Type", result)
    print("Column Type", column.data_type)
    return result


class EFCoreEntityGenerator(BaseGenerator.BaseGenerator):
    def __init__(self, collection, drivers, namingConvention, domain, project_data, template, template_dir):
        self.template = template
        self.template_dir = template_dir
        super().__init__(collection, drivers, namingConvention, domain, project_data, template)

    def run_core(self):
        lookup_template = next(
            (x for x in self.project_data.templates if x.id == self.template.id), None)
        self.generate_entities(lookup_template)

    def load_data(self, lookup_template):
        for file in glob.glob(f"{self.template_dir}/{lookup_template.template}/data.json"):
            f = open(file)
            data = json.loads(
                f.read(), object_hook=lambda d: SimpleNamespace(**d))
            f.close()
            return data

    def return_template(self, loaded_template, lookup_template):
        j2_enviroment = Environment(loader=FileSystemLoader(
            f"{self.template_dir}/{lookup_template.template}"))
        j2_enviroment.filters["convert_to_case"] = convert_to_case
        j2_enviroment.filters["map_to_output_type"] = map_to_output_type
        return j2_enviroment.from_string(loaded_template)

    def generate_entities(self, lookup_template):
        print("Generating EfCore Entities")
        for file_path in glob.glob(f"{self.template_dir}/{lookup_template.template}/*.j2"):
            with open(file_path) as file:
                loaded_template = file.read()
                j2_template = self.return_template(
                    loaded_template, lookup_template)
                entity = self.load_data(lookup_template)
                for table in self.project_data.tables:
                    namespace = f"{self.project_data.base_namespace}.{self.template.namespace}"

                    # These are the referenced objects
                    foreign_relationships = [
                        relationship for relationship in table.relationships if relationship.relationship == "ForeignKey"]
                    # These represent the objects referencing this object
                    foreign_relationships_children = [
                        relationship for relationship in table.relationships if relationship.relationship == "ForeignKeyChild"]

                    processed_template = j2_template.render(
                        table=table,
                        namespace=namespace,
                        entity=entity,
                        template=self.template,
                        domain=self.domain,
                        foreign_relationships=foreign_relationships,
                        foreign_relationships_children=foreign_relationships_children
                    )
                    # print(processed_template)
                    save_file_path = f"{self.project_data.basePath}/{self.template.base_path}/{convert_to_case(table.table_name, self.domain.namingConvention)}.g.cs"
                    os.makedirs(os.path.dirname(
                        save_file_path), exist_ok=True)
                    with open(save_file_path, mode="w", encoding="utf-8") as message:
                        message.write(processed_template)
