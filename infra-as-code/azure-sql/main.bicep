@description('The name of the SQL logical server.')
param serverName string

@description('The name of the SQL Database.')
param databaseName string

@description('Location for all resources.')
param location string = resourceGroup().location

@description('The administrator username of the SQL logical server.')
param administratorLogin string

@description('The administrator password of the SQL logical server.')
@secure()
param administratorLoginPassword string

module sqlServer 'sql-server.bicep' = {
  name: 'main-sql-server'
  params: {
    serverName: serverName
    location: location
    administratorLogin: administratorLogin
    administratorLoginPassword: administratorLoginPassword
  }
}

module sqlDatabase 'sql-database.bicep' = {
  name: 'main-sql-database'
  params: {
    serverName: serverName
    sqlDBName: databaseName
    location: location
  }
  dependsOn: [
    sqlServer
  ]
}
