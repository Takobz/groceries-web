param principalId string

//roleid: 7f951dda-4ed3-4680-a7ca-43fe172d538d for ACR Push role
var acrPushRole = subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '7f951dda-4ed3-4680-a7ca-43fe172d538d')

resource containerRegistry 'Microsoft.ContainerRegistry/registries@2022-12-01' existing = {
  name: 'containerRegistry'
}

resource roleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(subscription().subscriptionId, 'container-registry-roles-assignment')
  properties: {
    principalId: principalId
    roleDefinitionId:  acrPushRole
    scope: containerRegistry
  }
}
