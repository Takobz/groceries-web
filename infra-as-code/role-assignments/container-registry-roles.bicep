param principalId string

//roleid: 7f951dda-4ed3-4680-a7ca-43fe172d538d for ACR Push role
var acrPushRole = subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '7f951dda-4ed3-4680-a7ca-43fe172d538d')

resource roleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(subscription().subscriptionId, 'container-registry-roles-assignment')
  properties: {
    principalId: principalId
    roleDefinitionId:  acrPushRole
    principalType: 'ServicePrincipal'
  }
}

/*
REMEMBER THIS WHEN DOING RBAC IN THE FUTURE:

The Enterprice Application Linked to the App Registration with principalId was given RBAC roles.
It was given the Owner Role so that it can be able to write to the resource group's role assignments.
This was done in the portal and not with IaC as the service principal doesn't have the required permissions to assign roles.
*/
