@description('Name for the container group')
param containerGroupName string

@description('Resource group for all resources.')
param containerRegistryName string

@description('Location for all resources.')
param location string = resourceGroup().location

@description('Nginx Port, which will be exposed to the public internet.')
param port int = 80

@description('The behavior of Azure runtime if container has stopped.')
@allowed([
  'Always'
  'Never'
  'OnFailure'
])
param restartPolicy string = 'OnFailure'

@description('An array with objects that have image name, port and tag')
param imagesDetails array = []

resource containerRegistry 'Microsoft.ContainerRegistry/registries@2022-12-01' existing = {
  name: containerRegistryName
}

resource containerGroup 'Microsoft.ContainerInstance/containerGroups@2023-05-01' = {
  name: containerGroupName
  location: location
  properties: {
    containers: [
      for imageDetails in imagesDetails: {
        name: imageDetails.imageName
        properties: {
          image: '${containerRegistry.properties.loginServer}/${imageDetails.imageName}:${imageDetails.tag}'
          ports: [
            {
              port: imageDetails.port
              protocol: 'TCP'
            }
          ]
          resources: {
            requests: {
              cpu: imageDetails.cpuCores
              memoryInGB: imageDetails.memoryInGb
            }
          }
        }
      }
    ]
    osType: 'Linux'
    restartPolicy: restartPolicy
    ipAddress: {
      type: 'Public'
      ports: [
        {
          port: port
          protocol: 'TCP'
        }
      ]
    }
  }
}

output name string = containerGroup.name
output resourceGroupName string = resourceGroup().name
output resourceId string = containerGroup.id
output containerIPv4Address string = containerGroup.properties.ipAddress.ip
output location string = location
