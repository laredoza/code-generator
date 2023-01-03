import json
import glob
from types import SimpleNamespace
from _templates.generator import BaseProjectGenerator, BaseGenerator
from jinja2 import Environment, FileSystemLoader, Template
from _templates.c_sharp.efcore_context import EFCoreContextGenerator
from _templates.c_sharp.efcore_entity import EFCoreEntityGenerator
from _templates.c_sharp.efcore_entity_configuration import EFCoreEntityConfigurationGenerator
from _templates.c_sharp.repository import RepositoryGenerator 
from _templates.c_sharp.services import ServicesGenerator 

class ProjectGenerator(BaseProjectGenerator.BaseProjectGenerator):
    def __init__(self, model_file_dir, model_file_name, template_dir):
        # Replace with super()
        BaseProjectGenerator.BaseProjectGenerator.__init__(
            self, model_file_dir, model_file_name, template_dir)
        # https://realpython.com/primer-on-jinja-templating/

    def execute_generator(self, collection, drivers, namingConvention, domain, project_data):
        for package in domain.packages:
            for template in package.templates:
                if template.id == "00000000-0000-0000-0000-000000000001":
                    # EfCore Context
                    context = EFCoreContextGenerator.EFCoreContextGenerator(
                        collection, drivers, namingConvention, domain, project_data, template, self.template_dir)
                    context.run_core()
                if template.id == "00000000-0000-0000-0000-000000000002":
                    # Entities
                    entity = EFCoreEntityGenerator.EFCoreEntityGenerator(
                        collection, drivers, namingConvention, domain, project_data, template, self.template_dir)
                    entity.run_core()
                if template.id == "00000000-0000-0000-0000-000000000003":
                    # Entity Configurations
                    entity = EFCoreEntityConfigurationGenerator.EFCoreEntityConfigurationGenerator(
                        collection, drivers, namingConvention, domain, project_data, template, self.template_dir)
                    entity.run_core()
                if template.id == "00000000-0000-0000-0000-000000000004":
                    # Repositories 
                    entity = RepositoryGenerator.RepositoryGenerator(
                        collection, drivers, namingConvention, domain, project_data, template, self.template_dir)
                    entity.run_core()
                if template.id == "00000000-0000-0000-0000-000000000005":
                    # Services 
                    entity = ServicesGenerator.ServicesGenerator(
                        collection, drivers, namingConvention, domain, project_data, template, self.template_dir)
                    entity.run_core()