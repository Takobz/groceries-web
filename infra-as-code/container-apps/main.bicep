param containerRegistryName string
param containerAppsEnvironmentName string
param managedIdentityName string

param webApiContainerAppName string
param webApiImage string
param webApiTargetPort int
param webApiCpu string
param webApiMemory string = '1Gi'
param webApiImageTag string = 'latest'
param webApiEnvironmentVariables array = []

param clientContainerAppName string
param clientImage string
param clientImageTag string = 'latest'
param clientCpu string = '0.5'
param clientMemory string = '1Gi'
param clientTargetPort int


param sqlServerName string
param sqlDBName string

resource containerRegistry 'Microsoft.ContainerRegistry/registries@2022-12-01' existing = {
  name: containerRegistryName
}

resource managedIdentity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
  name: managedIdentityName
  location: resourceGroup().location
}

var acrPullRoleDefinitionGuid = '7f951dda-4ed3-4680-a7ca-43fe172d538d'
resource pullImagesRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(managedIdentity.id, acrPullRoleDefinitionGuid)
  properties: {
    principalId: managedIdentity.properties.principalId
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', acrPullRoleDefinitionGuid)
    principalType: 'ServicePrincipal'
  }
}

var azureSQLServerContributorRole = '6d8ee4ec-f05a-4a1d-8b00-a9b17e38b437'
resource sqlDatabaseRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(managedIdentity.id, azureSQLServerContributorRole)
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', azureSQLServerContributorRole)
    principalId: managedIdentity.properties.principalId
  }
}

module containerAppsEnvironment 'container-apps-environment.bicep' = {
  name: 'containerAppsEnvironment'
  params: {
    containerAppsEnvironmentName: containerAppsEnvironmentName
  }
}

// https://blog.cellenza.com/en/cloud/how-to-secure-azure-sql-database-with-managed-identity-azure-ad-authentication/
module webApi 'webapi-app.bicep' = {
  name: 'webApi'
  params: {
    webApiContainerAppName: webApiContainerAppName
    managedEnvironmentId: containerAppsEnvironment.outputs.containerAppsEnvironmentId
    webapiImage: webApiImage
    webApiTargetPort: webApiTargetPort
    webApiCpu: webApiCpu
    webApiMemory: webApiMemory
    webApiImageTag: webApiImageTag
    containerRegistryUserAssignedIdentityId: managedIdentity.id
    environmentVariables: webApiEnvironmentVariables
    containerRegistryLoginServer: containerRegistry.properties.loginServer
    sqlServerName: sqlServerName
    sqlDBName: sqlDBName
    managedIdentityClientId: managedIdentity.properties.clientId
  }
}

module clientApp 'client-app.bicep' = {
  name: 'clientApp'
  params: {
    clientContainerAppName: clientContainerAppName
    managedEnvironmentId: containerAppsEnvironment.outputs.containerAppsEnvironmentId
    clientImage: clientImage
    clientImageTag: clientImageTag
    clientCpu: clientCpu
    clientMemory: clientMemory
    clientTargetPort: clientTargetPort
    containerRegistryUserAssignedIdentityId: managedIdentity.id
    environmentVariables: [
      {
        name: 'REACT_APP_GROCERIES_WEB_API_BASE_URI'
        value: webApi.outputs.containerAppFullyQualifiedDomainName
      }
    ]
    containerRegistryLoginServer: containerRegistry.properties.loginServer
  }
}
