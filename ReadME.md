# Groceries Web App
Read me guide on getting started

## How to run locally

### EF Migrations
The Application uses EF Code First Migration to create/update database tables. Below is how we can do that:  

The application uses Environment variables to construct the connection string.
When doing database migrations `dotnet ef migrations` doesn't read the `luanchSettings.json` by default. To run migration, firstly export the required env variables like so:
```bash
export PGDB="groceries_database"
```
Just make sure you use values in the [launchSettings.json](./src/groceries-web-api/Groceries.Core.Application/Properties/launchSettings.json)


## Architecture and Design
- [Application Design](./design-and-docs/docs/DDDImplementation.md)
- [Solution Architecture](./)