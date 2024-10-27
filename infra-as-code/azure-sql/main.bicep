@description('The name of the SQL logical server.')
param serverName string

@description('The name of the SQL Database.')
param databaseName string

@description('Location for all resources.')
param location string = resourceGroup().location

@description('User Assigned Managed Identity That has access to the SQL Server.')
param managedIdentityName string

module sqlServer 'sql-server.bicep' = {
  name: 'main-sql-server'
  params: {
    serverName: serverName
    location: location
    managedIdentityName: managedIdentityName
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
