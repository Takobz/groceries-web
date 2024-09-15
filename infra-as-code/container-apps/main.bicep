param containerRegistryName string
param containerAppsEnvironmentName string

param postgresContainerAppName string
param postgresImage string
param postgresTargetPort int = 5432
param postgresCpu int = 1
param postgresMemory string = '1Gi'
param postgresImageTag string = 'latest'
param containerRegistryUserAssignedIdentityId string
param postgresEnvironmentVariables array = []

resource containerRegistry 'Microsoft.ContainerRegistry/registries@2022-12-01' existing = {
  name: containerRegistryName
}

module containerAppsEnvironment 'container-apps-environment.bicep' = {
  name: 'containerAppsEnvironment'
  params: {
    containerAppsEnvironmentName: containerAppsEnvironmentName
  }
}

module postgres 'postgres-app.bicep' = {
  name: 'postgres'
  params: {
    postgresContainerAppName: postgresContainerAppName
    managedEnvironmentId: containerAppsEnvironment.outputs.containerAppsEnvironmentId
    postgresImage: '${containerRegistry.properties.loginServer}/${postgresImage}:${postgresImageTag}'
    postgresTargetPort: postgresTargetPort
    postgresCpu: postgresCpu
    postgresMemory: postgresMemory
    containerRegistryUserAssignedIdentityId: containerRegistryUserAssignedIdentityId
    environmentVariables: postgresEnvironmentVariables
    containerRegistryLoginServer: containerRegistry.properties.loginServer
  }
}
