@description('The name of the SQL logical server.')
param serverName string

@description('The name of the SQL Database.')
param databaseName string

@description('Location for all resources.')
param location string = resourceGroup().location

module sqlServer 'sql-server.bicep' = {
  name: 'main-sql-server'
  params: {
    serverName: serverName
    location: location
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
