import json
import os
import glob
from pathlib import Path
from types import SimpleNamespace
from _templates.generator.models import NamingConvention, Drivers, CollectionOption, Cache

class BaseProjectGenerator:
	model_file_dir = ""
	model_file_name = ""
	template_dir = ""
	dir = Path.cwd()
	def __init__(self, model_file_dir, model_file_name, template_dir):
		self.model_file_dir = model_file_dir
		self.model_file_name = model_file_name
		self.template_dir = template_dir
	def run_core(self):
		self.collections = self.return_collection_options()
		self.driver_types = self.return_driver_types()
		self.naming_conventions = self.return_naming_convention()
		# print(json.dumps(self.return_driver_types(), default=vars))
		f = open("{0}/{1}".format(self.model_file_dir, self.model_file_name))
		project_data = json.loads(f.read(), object_hook=lambda d: SimpleNamespace(**d))
		for domain in project_data.domains:
			# print(domain.name)
			collection = next((x for x in self.collections if x.id == domain.collectionOptionId), None)
			naming_convention = next((x for x in self.naming_conventions if x.id == domain.id), None)
			# find driver_types for domain.Drivers
			drivers = []	
			for driver in domain.driverId:
				drivers.append(next((x for x in self.driver_types if x.id == driver), None))
			# print(json.dumps(drivers, default=vars))
			# remove todo check
			templates = [path for path in os.listdir("{0}/_templates/c_sharp".format(self.dir)) if os.path.isdir("{0}/_templates/c_sharp/{1}".format(self.dir, path)) and path != "todo"]
			# print(templates)
			self.execute_generator(collection, drivers, naming_convention, domain, project_data)

			# find(lambda x: x.id == domain.collectionOptionId, self.driver_types)
			# for driver in domain.drivers:
			# 	print(driver.id)
			# 	# find the self.collections option
			# 	driver = next((x for x in self.return_driver_types() if x.id == driver.id), None)
			# 	print(json.dumps(driver, default=vars))
			# 	self.execute_generator(collection, driver, self.return_naming_convention())
			# for package in domain.packages:
			# 	print(package.name)
			# 	for template in package.templates:
			# 		print(template)
		# for i in data.tables:
    		# 	print(i.enabledForCodeGeneration)
		f.close()
	def return_naming_convention(self):
		naming_conventions = []
		for file in glob.glob("{0}/cSharp/default/namingConventions/*.json".format(self.model_file_dir)):
			f = open(file)
			data = json.loads(f.read(), object_hook=lambda d: SimpleNamespace(**d))
			naming_conventions.append(NamingConvention.NamingConvention(data.id, data.name))
			f.close()
			# print(data)
		return naming_conventions
	def return_collection_options(self):
		collection_options = []
		for file in glob.glob("{0}/cSharp/default/collections/*.json".format(self.model_file_dir)):
			f = open(file)
			data = json.loads(f.read(), object_hook=lambda d: SimpleNamespace(**d))
			collection_options.append(CollectionOption.CollectionOption(data.id, data.class_name, data.class_interface))
			f.close()
			# print(data)
		return collection_options
	def return_cache(self):
		cache = []
		for file in glob.glob("{0}/cSharp/default/cache/*.json".format(self.model_file_dir)):
			f = open(file)
			data = json.loads(f.read(), object_hook=lambda d: SimpleNamespace(**d))
			cache.append(Cache.Cache(data.id, data.name, data.driver_type))
			f.close()
			# print(data)
		return cache
	def return_driver_types(self):
		drivers_types = []
		for file in glob.glob("{0}/cSharp/default/drivers/efCore/*.json".format(self.model_file_dir)):
			f = open(file)
			data = json.loads(f.read(), object_hook=lambda d: SimpleNamespace(**d))
			drivers_types.append(Drivers.Drivers(
				data.id, 
				data.create_db, 
				data.include_column_order, 
				data.lazy_load_enabled, 
				data.logging_enabled, 
				data.name, 
				data.proxy_creation_enabled, 
				data.use_alias, 
				data.use_seperate_config_classes, 
				data.enable_cache, 
				data.cache))
			f.close()
		return drivers_types
	def execute_generator(self, collection, drivers, namingConvention, domain, project_data):
		print("execute_generator")