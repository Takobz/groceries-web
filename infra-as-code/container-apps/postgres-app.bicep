//TODO: Will replace this with a Database Service, using Postgres Image for now.

@description('Name of the postgres container app')
param postgresContainerAppName string

@description('Managed Environment Id')
param managedEnvironmentId string

param postgresImage string

param postgresTargetPort int = 5432

param postgresCpu string

param postgresMemory string = '1Gi'

param containerRegistryUserAssignedIdentityId string

param environmentVariables array = []

param containerRegistryLoginServer string

resource PostgresConatinerApp 'Microsoft.App/containerApps@2024-03-01' = {
  name: postgresContainerAppName
  location: resourceGroup().location
  identity: {
    type:'UserAssigned'
    userAssignedIdentities: {
      '${containerRegistryUserAssignedIdentityId}' : {}
    }
  }
  properties: {
    managedEnvironmentId: managedEnvironmentId
    configuration: {
      ingress: {
        external: false
        targetPort: postgresTargetPort
      }
      registries: [
        {
          server: containerRegistryLoginServer
          identity: containerRegistryUserAssignedIdentityId
        }
      ]
    }
    template: {
      containers: [
        {
          name: postgresContainerAppName
          image: postgresImage
          resources: {
            cpu: json(postgresCpu)
            memory: postgresMemory
          }
          env: environmentVariables
        }
      ]
    }
  }
}
