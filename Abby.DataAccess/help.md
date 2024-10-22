# Entity Framework Core

## Commands

The following commands needs to be run in the root folder of the project.

### Add Migration

```bash
dotnet ef migrations add InitialCreate --project Abby.DataAccess --startup-project AbbyWeb
```

### Update Database

```bash
dotnet ef database update --project Abby.DataAccess --startup-project AbbyWeb
```