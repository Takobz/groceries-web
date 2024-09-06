module containerResigstry 'container-registry/container-registry.bicep' = {
  name: 'containerRegistry'
  params: {
    acrName: 'acr${uniqueString(resourceGroup().id)}'
    location: resourceGroup().location
    acrSku: 'Basic'
  }
}
