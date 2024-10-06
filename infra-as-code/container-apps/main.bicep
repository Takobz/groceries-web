param containerRegistryName string
param containerAppsEnvironmentName string
param managedIdentityName string

param postgresContainerAppName string
param postgresImage string
param postgresTargetPort int = 5432
param postgresCpu string
param postgresMemory string = '1Gi'
param postgresImageTag string = 'latest'
param postgresEnvironmentVariables array = []

param webApiContainerAppName string
param webApiImage string
param webApiTargetPort int
param webApiCpu string
param webApiMemory string = '1Gi'
param webApiImageTag string = 'latest'
param webApiEnvironmentVariables array = []

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

module containerAppsEnvironment 'container-apps-environment.bicep' = {
  name: 'containerAppsEnvironment'
  params: {
    containerAppsEnvironmentName: containerAppsEnvironmentName
  }
}

//remove this and use a storage service.
module postgres 'postgres-app.bicep' = {
  name: 'postgres'
  params: {
    postgresContainerAppName: postgresContainerAppName
    managedEnvironmentId: containerAppsEnvironment.outputs.containerAppsEnvironmentId
    postgresImage: postgresImage
    postgresTargetPort: postgresTargetPort
    postgresCpu: postgresCpu
    postgresMemory: postgresMemory
    containerRegistryUserAssignedIdentityId: managedIdentity.id
    environmentVariables: postgresEnvironmentVariables
    containerRegistryLoginServer: containerRegistry.properties.loginServer
    postgresImageTag: postgresImageTag
  }
  dependsOn: [
    pullImagesRoleAssignment
  ]
}

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
  }
  dependsOn: [
    postgres
  ]
}
