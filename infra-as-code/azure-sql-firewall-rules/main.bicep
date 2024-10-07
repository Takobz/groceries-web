@description('Sql Server That has the database')
param serverName string

@description('The IPs allowed to connect to the database')
param allowedIPs string[]

resource sqlServer 'Microsoft.Sql/servers@2022-05-01-preview' existing = {
  name: serverName
}

resource firewallRules 'Microsoft.Sql/servers/firewallRules@2022-05-01-preview' = [for ip in allowedIPs: {
  parent: sqlServer
  name: guid('AllowIP-${ip}')
  properties: {
    startIpAddress: ip
    endIpAddress: ip
  }
}]
