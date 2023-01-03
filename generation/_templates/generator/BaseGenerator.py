class BaseGenerator:
	def __init__(self, collection, drivers, namingConvention, domain, project_data, template):
		self.collection = collection
		self.drivers = drivers
		self.namingConvention = namingConvention
		self.domain = domain
		self.project_data = project_data
		self.template = template
	def run_core(self):
		print("Base Generator")