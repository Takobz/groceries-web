# Groceries Web App
Read me guide on getting started

[![Build Status](https://dev.azure.com/kobelakhutso/groceries-web/_apis/build/status%2FTakobz.groceries-web?branchName=main)](https://dev.azure.com/kobelakhutso/groceries-web/_build/latest?definitionId=5&branchName=main)

## How to run locally
This section goes through how to run the web app locally as full application and individual components.

## Dependencies:
Dependencies needed to run this locally.
>[!NOTE]
> Please note for Node and .NET, you can run the app locally without installing them on your physical machine by using docker-compose, as seen [here](#docker-compose-dev). Though having them installed wouldn't hurt.


- [Docker](https://www.docker.com/) for containerization
- [Node](https://nodejs.org/en) for React
- [.NET](https://dotnet.microsoft.com/en-us/download) for the WEB API
- [Postgres image](https://hub.docker.com/_/postgres)

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

### Runing the WEBAPI without Docker Compose
If maybe you want to debug the WEB API via say vs code, the docker compose approach is not ideal as it will want you to rebuild images and you won't be able to use break points etc.  
  
To run API locally outside of a docker container, you would need to first create a Postgres database on your local machine that your web API can connect to.  
The Postgres container should have configuration corresponding to the values in the environmentVariables in the [launchSetting.json](./src/groceries-web-api/Groceries.Core.Application/Properties/launchSettings.json).  

#### Initial Run
 This is usually when you run the API for the first time or after you have deleted all your docker images/containers:

- Pull postgres image from docker `docker pull postgres:latest`
- Then run command:
```bash
# You can make this a single line if the terminal complian about the format
docker run --name local_groceries_db -d \ 
    -e POSTGRES_PASSWORD=postgres_password \
    -e POSTGRES_USER=postgres \
    -e POSTGRES_DB=groceries_database \
    -p 5432:5432 \
    postgres

```
- Then go into the project `src/groceries-web-api/Groceries.Core.Application` then run `dotnet run`.
- The code will take care of database migrations, then you can dev 🚀

#### Subsequent Runs
This is the guide for when you once did the [initial run](#initial-run) and still have your postgres container on your local machine.  

- Check if you still have the container of the postgres database: `docker ps -a`
- If you see no container with the name `local_groceries_db` or any name you specified on the flag `--name` then do steps in [intital run](#initial-run)
- if you see the conatiner like similar to this:
```bash
CONTAINER ID   IMAGE      COMMAND                  CREATED          STATUS                     PORTS     NAMES
f22a6cf1b18a   postgres   "docker-entrypoint.s…"   22 minutes ago   Exited (0) 8 minutes ago             local_groceries_db
```
- Do the command: `docker start local_groceries_db` make sure the name is the same as the NAMES value.
- Doing a `docker ps` should show this container running.
- Then go into the project `src/groceries-web-api/Groceries.Core.Application` then run `dotnet run`.
- Then that's it, dev more!

>[!NOTE]
> Just remember to stop the database container when you are done local debugging.
> use the command: `docker stop local_groceries_db`

## Architecture and Design
- [Application Design](./design-and-docs/docs/DDDImplementation.md)
- [Use Cases](./design-and-docs/design-assets/groceries.drawio.png)