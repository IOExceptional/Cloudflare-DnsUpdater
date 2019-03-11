# DNS Updater

This is a service to be installed on a machine where the IP can change, giving a "No-IP" like service.

Updates a specific zone's subdomain `A` record with the "public" IP of the machine it's run on

## How to use

It's a console app, so for the time being;

> dotnet path/to/project.dll "email" "apiKey" "zoneId" "zoneName" "dnsRecordId" "dnsRecordName"

## TODO

1. Use Cloudflare.Net (once nuget package updated)
2. Get the zone id and record id by name (reducing config)
3. 
4. Look into it using IPv6 + `AAAA` records? 
 