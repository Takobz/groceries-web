param principalId string
param registryName string
param registrySku string
param enterpriseAppObjectId string

module containerRegistry 'container-registry/container-registry.bicep' = {
  name: 'containerRegistry'
  params: {
    acrName: registryName
    location: resourceGroup().location
    acrSku: registrySku
  }
}

module customPipelineRole 'role-assignments/custom-pipeline-role.bicep' = {
  name: 'customPipelineRole'
  params: {
    enterpriseAppObjectId: enterpriseAppObjectId
  }
}

module containerRegistryRoles 'role-assignments/container-registry-roles.bicep' = {
  name: 'containerRegistryRoles'
  params: {
    principalId: principalId
  }
  dependsOn: [
    customPipelineRole
    containerRegistry
  ]
}
