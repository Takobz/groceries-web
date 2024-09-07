@description('Grants the enterprise app the ability to write into the role assignment')
param enterpriseAppObjectId string

@description('Custom role that allows any identity to write into the role assignment')
resource customWriteRole 'Microsoft.Authorization/roleDefinitions@2022-04-01' = {
  name: guid(subscription().id, 'role-assignment-writer')
  properties: {
    roleName: 'role-assignment-writer'
    description: 'Grants application the ability to write into the role assignment'
    assignableScopes: [
      '/subscriptions/${subscription().id}/resourceGroups/${resourceGroup().name}'
    ]
    permissions: [
      {
        actions: [
          'Microsoft.Authorization/roleAssignments/write'
        ]
        notActions: []
        dataActions: []
        notDataActions: []
      }
    ]
  }
}

@description('Grants the enterprise app the ability to write into the role assignment')
resource roleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(subscription().id, 'role-assignment-writer')
  properties: {
    principalId: enterpriseAppObjectId
    roleDefinitionId: customWriteRole.id
    scope: '/subscriptions/${subscription().id}/resourceGroups/${resourceGroup().name}'
  }
}
