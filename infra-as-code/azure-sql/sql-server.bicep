@description('The name of the SQL logical server.')
param serverName string

@description('Location for all resources.')
param location string = resourceGroup().location

resource sqlServer 'Microsoft.Sql/servers@2022-05-01-preview' = {
  name: serverName
  location: location
}
