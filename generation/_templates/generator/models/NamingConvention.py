# from _templates.base_generator.interfaces import INamingConvention

# class NamingConvention(INamingConvention):
class NamingConvention:
	def __init__(self, id, name):
		self.id = id
		self.name = name
	# def get_id(self):
	# 	return self.id
	# def get_name(self):
	# 	return self.name