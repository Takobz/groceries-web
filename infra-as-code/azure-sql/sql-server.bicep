@description('The name of the SQL logical server.')
param serverName string

@description('Location for all resources.')
param location string = resourceGroup().location

@description('The name of the SQL database.')
param managedIdentityName string

//think about having two different managed identities for the sql server and the web api
resource managedIdentity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' existing = {
  name: managedIdentityName
}

resource sqlServer 'Microsoft.Sql/servers@2022-05-01-preview' = {
  name: serverName
  location: location
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${managedIdentity.id}': {}
    }
  }
  properties: {
    primaryUserAssignedIdentityId: managedIdentity.id
    administrators: {
      administratorType: 'ActiveDirectory'
      login: managedIdentityName
      sid: managedIdentity.properties.principalId
      tenantId: subscription().tenantId
      principalType: 'Application'
    }
  }
}
