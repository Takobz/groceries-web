# Groceries Web App
Read me guide on getting started

## How to run locally
This section goes through how to run the web app locally as full application and individual components.

### Docker Compose Dev
The local set uses Docker Compose to run the full application, here's how:
- run `docker-compose -f docker-compose-dev.yml build` to build the Dockerfiles in respective projects
- run `docker-compose -f docker-compose-dev.yml up` to run the built and created images.
The above will create images and containers for the .NET WEB API, React Client and an empty Postgres database.


### Database Migrations
The Application uses EF Code First Migration to create/update database tables. Here's how the database models are migrated:
- The Docker Compose file will fire up the database first, then the API and latestly React client App.
- On StartUp of the WEB API will try to migrate by running command: `groceriesDatabaseContext.Database.Migrate();`
- The Docker Compose file, has `restart: on-failure` so Docker will keep retrying to get the container up if it fails to start up, this is to account for when the database might be still initializing but the WEB API tries to connect or migrate.


## Architecture and Design
- [Application Design](./design-and-docs/docs/DDDImplementation.md)
- [Use Cases](./design-and-docs/design-assets/groceries.drawio.png)