from _templates.generator import BaseGenerator
from _templates.generator.template_helpers import convert_to_case
from jinja2 import Environment, FileSystemLoader, Template, PackageLoader
import json
import glob
from types import SimpleNamespace
import os
from re import sub
import stringcase


class RepositoryGenerator(BaseGenerator.BaseGenerator):
    def __init__(self, collection, drivers, namingConvention, domain, project_data, template, template_dir):
        self.template = template
        self.template_dir = template_dir
        super().__init__(collection, drivers, namingConvention, domain, project_data, template)

    def run_core(self):
        lookup_template = next(
            (x for x in self.project_data.templates if x.id == self.template.id), None)
        self.generate(lookup_template)

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
        return j2_enviroment.from_string(loaded_template)

    def return_context_data(self, lookup_template):
        for file in glob.glob(f"{self.template_dir}/{lookup_template.template}/data.json"):
            f = open(file)
            data = json.loads(
                f.read(), object_hook=lambda d: SimpleNamespace(**d))
            f.close()
            return data

    def generate(self, lookup_template):
        lookup_template_context = next(
            (x for x in self.project_data.templates if x.id == "00000000-0000-0000-0000-000000000001"), None)
        context_data = self.return_context_data(lookup_template_context)
        for context in context_data.contexts:
            self.generate_repository_interface(lookup_template, context)
            self.generate_repository(lookup_template, context)
            self.generate_repository_extension(lookup_template, context)

    def return_context_table(self, context):
        results = []
        for model in context.models:
            table = next(
                (x for x in self.project_data.tables if x.table_name == model.table_name), None)
            if table is not None:
                results.append(table)
        return results

    def generate_repository_extension(self, lookup_template, context_data):
        print("Generating Repository Extension")
        for file_path in glob.glob(f"{self.template_dir}/{lookup_template.template}/template_extension_registration.j2"):
            with open(file_path) as file:
                loaded_template = file.read()
                j2_template = self.return_template(
                    loaded_template, lookup_template)
                repository = self.load_data(lookup_template)
                namespace = f"{self.project_data.base_namespace}.{self.template.namespace}.{context_data.context_name}s"
                
                repository_namespace_interface = f"{self.project_data.base_namespace}.{self.template.namespace_interface}.{context_data.context_name}s"
                repository_namespace = f"{self.project_data.base_namespace}.{self.template.namespace}.{context_data.context_name}s"
                context_tables = self.return_context_table(context_data)

                processed_template = j2_template.render(
                    tables=self.return_context_table(context_data),
                    namespace=namespace,
                    repository_namespace_interface=repository_namespace_interface,
                    repository_namespace=repository_namespace,
                    entity=repository,
                    template=self.template,
                    domain=self.domain,
                    # context_name=context_data.context_name
                )
                save_file_path = f"{self.project_data.basePath}/{self.template.base_path}/{context_data.context_name}s/RepositoryExtension.g.cs"
                os.makedirs(os.path.dirname(
                    save_file_path), exist_ok=True)
                with open(save_file_path, mode="w", encoding="utf-8") as message:
                    message.write(processed_template)

    def generate_repository_interface(self, lookup_template, context_data):
        print("Generating Repository Interfaces")
        for file_path in glob.glob(f"{self.template_dir}/{lookup_template.template}/template_interface.j2"):
            with open(file_path) as file:
                loaded_template = file.read()
                j2_template = self.return_template(
                    loaded_template, lookup_template)
                repository = self.load_data(lookup_template)
                for table in self.return_context_table(context_data):
                    namespace = f"{self.project_data.base_namespace}.{self.template.namespace_interface}.{context_data.context_name}s"

                    processed_template = j2_template.render(
                        table=table,
                        namespace=namespace,
                        entity=repository,
                        template=self.template,
                        domain=self.domain,
                        context_name=context_data.context_name
                    )
                    save_file_path = f"{self.project_data.basePath}/{self.template.base_path_interface}/{context_data.context_name}s/I{convert_to_case(table.table_name, self.domain.namingConvention)}Repository.g.cs"
                    os.makedirs(os.path.dirname(
                        save_file_path), exist_ok=True)
                    with open(save_file_path, mode="w", encoding="utf-8") as message:
                        message.write(processed_template)

    def generate_repository(self, lookup_template, context_data):
        print("Generating Repository")
        for file_path in glob.glob(f"{self.template_dir}/{lookup_template.template}/template.j2"):
            with open(file_path) as file:
                loaded_template = file.read()
                j2_template = self.return_template(
                    loaded_template, lookup_template)
                repository = self.load_data(lookup_template)
                for table in self.return_context_table(context_data):
                    namespace = f"{self.project_data.base_namespace}.{self.template.namespace}.{context_data.context_name}s"

                    processed_template = j2_template.render(
                        table=table,
                        namespace=namespace,
                        entity=repository,
                        template=self.template,
                        domain=self.domain,
                        context_name=context_data.context_name
                    )
                    save_file_path = f"{self.project_data.basePath}/{self.template.base_path}/{context_data.context_name}s/{convert_to_case(table.table_name, self.domain.namingConvention)}Repository.g.cs"
                    os.makedirs(os.path.dirname(
                        save_file_path), exist_ok=True)
                    with open(save_file_path, mode="w", encoding="utf-8") as message:
                        message.write(processed_template)
