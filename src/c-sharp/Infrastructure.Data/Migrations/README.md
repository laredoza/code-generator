# Migration Tips

Please note that an external migration assembly is used.  Refer to the [Using a Separate Project](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects) article for more information.  Here are some notes on how to use migrations in this solution.

## Make sure you're in the web api root folder before executing any of the command

```
cd ./Infrastructure.Api
```

## Add a migration
```
dotnet ef migrations add InitialDbMigration --project ../Infrastructure.Infrastructure.Data
```

## Remove a migration
```
dotnet ef migrations remove --project ../Infrastructure.Infrastructure.Data
```

## Update the database
```
dotnet ef database update --project ../Infrastructure.Infrastructure.Data
```

## Revert the database
```
dotnet ef database update <migration name> --project ../Infrastructure.Infrastructure.Data
```

## References
[Migrations: Using a Separate Project](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects)