@description('Name of the postgres container app')
param webApiContainerAppName string

@description('Managed Environment Id')
param managedEnvironmentId string
param webapiImage string
param webApiTargetPort int = 5000
param webApiImageTag string = 'latest'
param webApiCpu string
param webApiMemory string = '1Gi'
param containerRegistryUserAssignedIdentityId string
param environmentVariables array = []
param containerRegistryLoginServer string
param sqlServerName string
param sqlDBName string
param managedIdentityClientId string

var defaultWebApiEnvironmentVariables = [
  {
  name: 'DOTNET_RUNNING_IN_CONTAINER'
  value: 'true'
  }
  {
    name: 'ConnectionStrings__AZURE_SQL_CONNECTIONSTRING'
    value: 'Server=${sqlServerName}.database.windows.net;Database=${sqlDBName};User Id=${managedIdentityClientId};Authentication=Active Directory Managed Identity; Encrypt=True;'
  }
]

resource webApiConatinerApp 'Microsoft.App/containerApps@2024-03-01' = {
  name: webApiContainerAppName
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
        targetPort: webApiTargetPort
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
          name: webApiContainerAppName
          image: '${containerRegistryLoginServer}/${webapiImage}:${webApiImageTag}'
          resources: {
            cpu: json(webApiCpu)
            memory: webApiMemory
          }
          env: union(environmentVariables, defaultWebApiEnvironmentVariables)
        }
      ]
    }
  }
}

output containerAppOutboundIpAddress string[] = webApiConatinerApp.properties.outboundIpAddresses

