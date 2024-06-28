# Groceries Web App
Read me guide on getting started

## How to run locally
This section goes through how to run the web app locally as full application and individual components.

### Docker Compose Dev
The local set uses Docker Compose to run the full application, here's how:
- run `docker-compose -f docker-compose-dev.yml build` to build the Dockerfiles in respective projects
- run `docker-compose -f docker-compose-dev.yml up` to run the built and created images.
The above will create images and containers for the .NET WEB API, React Client and an empty Postgres database.

**TODO: Do migrations on building of web api** 

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