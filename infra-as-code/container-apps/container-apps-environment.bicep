param containerAppsEnvironmentName string

resource containerAppsEnvironment 'Microsoft.App/managedEnvironments@2024-03-01' = {
  name: containerAppsEnvironmentName
  location: resourceGroup().location
  properties: {}
}

output containerAppsEnvironmentId string = containerAppsEnvironment.id
