FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source/groceries-web-api

# install EF Core tools
#RUN dotnet tool install --global dotnet-ef

#restore app solution
COPY *.sln .
COPY ./Groceries.Core.Domain/*.csproj ./Groceries.Core.Domain/
COPY ./Groceries.Core.Application/*.csproj ./Groceries.Core.Application/
COPY ./Groceries.Infrastructure/*.csproj ./Groceries.Infrastructure/
COPY ./Groceries.Data/*.csproj ./Groceries.Data/
COPY ./Groceries.Tests.Unit/*.csproj ./Groceries.Tests.Unit/
COPY ./Groceries.Tests.Integration/*.csproj ./Groceries.Tests.Integration/

RUN dotnet restore

# add unit tests to image build?

#copy all files to source and publish
COPY . ../groceries-web-api/
WORKDIR /source/groceries-web-api
RUN dotnet publish -c Release -o /app --no-restore

# export environment variables needed by Postgres db migrations
# TODO: figure out how to get postgres at this point.
ENV PGDB=groceries_database
ENV PGUSER=postgres
ENV PGPASSWORD=postgres_password
ENV PGPORT=5432
#host should match postgres service name in docker-compose-dev.yml
ENV PGHOST=postgres

#build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app ./
# use ENTRYPOINT in prod dockerfile, CMD for dev to allow us -it into the container
CMD ["dotnet", "Groceries.Core.Application.dll"]
