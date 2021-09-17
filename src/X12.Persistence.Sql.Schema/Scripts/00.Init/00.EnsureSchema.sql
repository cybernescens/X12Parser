if not exists (select top (1) * from INFORMATION_SCHEMA.SCHEMATA where SCHEMA_NAME = '$x12_schema$')
  exec ('create schema [$x12_schema$]')