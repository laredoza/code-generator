from _templates.generator import BaseGenerator
from _templates.generator.template_helpers import convert_to_case
from jinja2 import Environment, FileSystemLoader, Template, PackageLoader
import json
import glob
from types import SimpleNamespace
import os
from re import sub
import stringcase

class EFCoreContextGenerator(BaseGenerator.BaseGenerator):
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

    def return_context(self, lookup_template):
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
        
        

    def generate_contexts(self, driver, lookup_template):
        print("Generating EfCore Context")
        for file_path in glob.glob(f"{self.template_dir}/{lookup_template.template}/*.j2"):
            with open(file_path) as file:
                loaded_template = file.read()
                j2_template = self.return_template(loaded_template, lookup_template)
                context_data = self.return_context(lookup_template)
                for context in context_data.contexts:
                    context_namespace = f"{self.project_data.base_namespace}.{context.namespace}"
                    processed_template = j2_template.render(
                        driver=driver,
                        context=context,
                        context_namespace=context_namespace,
                        context_data=context_data,
                        template=self.template,
                        domain=self.domain
                    )
                    # print(processed_template)
                    save_file_path = f"{self.project_data.basePath}/{self.template.base_path}/{driver.prefix}/{convert_to_case(context.context_name, self.domain.namingConvention)}.g.cs"
                    os.makedirs(os.path.dirname(save_file_path), exist_ok=True)
                    with open(save_file_path, mode="w", encoding="utf-8") as message:
                        message.write(processed_template)
