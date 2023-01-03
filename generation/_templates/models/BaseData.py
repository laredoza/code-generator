# Generated by https://quicktype.io

from uuid import UUID
from typing import List, Any


class PackageTemplate:
	id: UUID
	base_path: str
	enabled: bool
	name_space: str

	def __init__(self, id: UUID, base_path: str, enabled: bool, name_space: str) -> None:
		self.id = id
		self.base_path = base_path
		self.enabled = enabled
		self.name_space = name_space


class Package:
	id: UUID
	name: str
	children: List[Any]
	enabled: bool
	parent_id: UUID
	selected: bool
	templates: List[PackageTemplate]
	version: float

	def __init__(self, id: UUID, name: str, children: List[Any], enabled: bool, parent_id: UUID, selected: bool, templates: List[PackageTemplate], version: float) -> None:
		self.id = id
		self.name = name
		self.children = children
		self.enabled = enabled
		self.parent_id = parent_id
		self.selected = selected
		self.templates = templates
		self.version = version


class Domain:
	id: UUID
	name: str
	collection_option_id: UUID
	driver_id: List[UUID]
	source_type_id: UUID
	naming_convention: str
	packages: List[Package]

	def __init__(self, id: UUID, name: str, collection_option_id: UUID, driver_id: List[UUID], source_type_id: UUID, naming_convention: str, packages: List[Package]) -> None:
		self.id = id
		self.name = name
		self.collection_option_id = collection_option_id
		self.driver_id = driver_id
		self.source_type_id = source_type_id
		self.naming_convention = naming_convention
		self.packages = packages


class Column:
	column_name: str
	column_order: int
	data_type: str
	is_primary_key: bool
	is_required: bool
	length: int
	precision: int
	scale: int
	is_identity: bool
	identity_seed: int
	identity_increment: bool

	def __init__(self, column_name: str, column_order: int, data_type: str, is_primary_key: bool, is_required: bool, length: int, precision: int, scale: int, is_identity: bool, identity_seed: int, identity_increment: bool) -> None:
		self.column_name = column_name
		self.column_order = column_order
		self.data_type = data_type
		self.is_primary_key = is_primary_key
		self.is_required = is_required
		self.length = length
		self.precision = precision
		self.scale = scale
		self.is_identity = is_identity
		self.identity_seed = identity_seed
		self.identity_increment = identity_increment


class Index:
	index_type: str
	is_unique: bool
	name: str
	columns: List[str]

	def __init__(self, index_type: str, is_unique: bool, name: str, columns: List[str]) -> None:
		self.index_type = index_type
		self.is_unique = is_unique
		self.name = name
		self.columns = columns


class Relationship:
	column_name: str
	relation_ship: str
	referenced_column_name: str
	render: bool
	schema_name: str
	referenced_table_name: str
	multiplicity: str
	referenced_multiplicity: str
	user_relationship: bool
	relationship_name: str

	def __init__(self, column_name: str, relation_ship: str, referenced_column_name: str, render: bool, schema_name: str, referenced_table_name: str, multiplicity: str, referenced_multiplicity: str, user_relationship: bool, relationship_name: str) -> None:
		self.column_name = column_name
		self.relation_ship = relation_ship
		self.referenced_column_name = referenced_column_name
		self.render = render
		self.schema_name = schema_name
		self.referenced_table_name = referenced_table_name
		self.multiplicity = multiplicity
		self.referenced_multiplicity = referenced_multiplicity
		self.user_relationship = user_relationship
		self.relationship_name = relationship_name


class Table:
	description: str
	schema_name: str
	table_name: str
	enabled_for_code_generation: bool
	columns: List[Column]
	database_generation_key_type: str
	relationships: List[Relationship]
	indexes: List[Index]

	def __init__(self, description: str, schema_name: str, table_name: str, enabled_for_code_generation: bool, columns: List[Column], database_generation_key_type: str, relationships: List[Relationship], indexes: List[Index]) -> None:
		self.description = description
		self.schema_name = schema_name
		self.table_name = table_name
		self.enabled_for_code_generation = enabled_for_code_generation
		self.columns = columns
		self.database_generation_key_type = database_generation_key_type
		self.relationships = relationships
		self.indexes = indexes


class BaseDataTemplate:
	id: UUID
	language: str
	template: str
	enabled: bool
	version: float

	def __init__(self, id: UUID, language: str, template: str, enabled: bool, version: float) -> None:
		self.id = id
		self.language = language
		self.template = template
		self.enabled = enabled
		self.version = version


class BaseData:
	base_name_space: str
	domains: List[Domain]
	templates: List[BaseDataTemplate]
	tables: List[Table]
	header_text: str
	base_path: str
	version: float
	license: str
	company: str

	def __init__(self, base_name_space: str, domains: List[Domain], templates: List[BaseDataTemplate], tables: List[Table], header_text: str, base_path: str, version: float, license: str, company: str) -> None:
		self.base_name_space = base_name_space
		self.domains = domains
		self.templates = templates
		self.tables = tables
		# self.tables = []
		# for table in tables:
		# 	self.tables.append(Table(**table))
		self.header_text = header_text
		self.base_path = base_path
		self.version = version
		self.license = license
		self.company = company