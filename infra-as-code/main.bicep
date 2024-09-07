param principalId string
param registryName string
param registrySku string

module containerRegistry 'container-registry/container-registry.bicep' = {
  name: 'containerRegistry'
  params: {
    acrName: registryName
    location: resourceGroup().location
    acrSku: registrySku
  }
}

module containerRegistryRoles 'role-assignments/container-registry-roles.bicep' = {
  name: 'containerRegistryRoles'
  params: {
    principalId: principalId
  }
  dependsOn: [
    containerRegistry
  ]
}
