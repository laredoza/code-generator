class Drivers:
	def __init__(
		self, 
		id, 
		create_db, 
		include_column_order, 
		lazy_load_enabled, 
		logging_enabled, 
		name, 
		proxy_creation_enabled, 
		use_alias, 
		use_seperate_config_classes, 
		enable_cache, 
		cache):
		self.id = id
		self.create_db = create_db
		self.include_column_order = include_column_order
		self.lazy_load_enabled = lazy_load_enabled
		self.logging_enabled = logging_enabled
		self.name = name
		self.proxy_creation_enabled = proxy_creation_enabled
		self.useAlias = use_alias
		self.use_seperate_config_classes = use_seperate_config_classes
		self.enable_cache = enable_cache
		self.cache = cache