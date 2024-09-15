param principalId string
param registryName string
param registrySku string

module containerRegistry 'container-registry.bicep' = {
  name: 'containerRegistry'
  params: {
    acrName: registryName
    location: resourceGroup().location
    acrSku: registrySku
  }
}

module containerRegistryRoles 'container-registry-roles.bicep' = {
  name: 'containerRegistryRoles'
  params: {
    principalId: principalId
  }
  dependsOn: [
    containerRegistry
  ]
}
