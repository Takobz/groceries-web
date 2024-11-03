param clientContainerAppName string
param managedEnvironmentId string
param clientImage string
param clientImageTag string
param clientCpu string
param clientMemory string
param clientTargetPort int = 3000
param containerRegistryUserAssignedIdentityId string
param environmentVariables array = []
param containerRegistryLoginServer string

resource clientContainerApp 'Microsoft.App/containerApps@2024-03-01' = {
  name: clientContainerAppName
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
        external: true
        targetPort: clientTargetPort
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
          name: clientContainerAppName
          image: '${containerRegistryLoginServer}/${clientImage}:${clientImageTag}'
          resources: {
            cpu: json(clientCpu)
            memory: clientMemory
          }
          env: environmentVariables
        }
      ]
    }
  }
}
