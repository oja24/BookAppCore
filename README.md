Sample of ASP.NET CORE 2.0 that use Microsoft SQL Server as backend database.
This project used to build a complete CI/CD pipeline

[![Build Status](https://dev.azure.com/Roya-DevOps-World/BookAppWeb/_apis/build/status/BookAppWeb-ASP.NET%20Core-CI?branchName=master)](https://dev.azure.com/Roya-DevOps-World/BookAppWeb/_build/latest?definitionId=26&branchName=master)

In the CI pipeline, I have used SonarCloud which is cloud-based code quality and security service to scan my project for code quality. I have also used whiteSource bolt to scan all my open source software. I generated the dacpac file building my database project, which I used to created the database in the CD phase.
In the CD, I haved used azure cli to provision all the resources that the project need:
```sh
Azure App Service Plan
$ az appservice plan create -n fasoappplan -g $rg --sku s1 --is-linux
Azure web app
$ az webapp create --resource-group devops --plan fasoappplan --name petworldapp 
$ az sql server create -n PetSoreAppDB -g $rg -l $location --admin-user dbadmin --admin-password P#assWord12$$12

$ az sql server firewall-rule create -n AllowLocalClient --server $serverName -g $rg --start-ip-address 0.0.0.0 --end-ip-address 0.0.0.0

az sql db create -g $rg --server MSSQLAppDB--name MSSQLWebbAppDB --service-objective S0
```
Here is the Azure Devops project link: https://dev.azure.com/Roya-DevOps-World/BookAppWeb

