# write_messages.py

from jinja2 import Environment, FileSystemLoader
import json
from types import SimpleNamespace
from _templates.models import BaseData
from _templates.generator import ProjectGenerator
project_generator = ProjectGenerator.ProjectGenerator("./model", "base.json", './_templates/c_sharp')
project_generator.run_core()