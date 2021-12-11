
###### Heading Six
#####  Heading Five
####   Heading Four
###    Heading Three
##     Heading Two
#      Heading One

# https://docs.github.com/en/github/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax

# Serilog - first add this to the .proj file
<PackageReference Include="Serilog.AspNetCore" Version="4.1.0" />

# SSL developer cert - this has the preferred way to add the developer cert
https://docs.microsoft.com/en-us/troubleshoot/visualstudio/general/warnings-untrusted-certificate

## database migration to create the database with package manager
because i added nuget entityframework references i get this command
which generates some c# that will perform the create 
PM> Add-Migration DatabaseCreated
Build started...
Build succeeded.
[14:11:23 INF] Entity Framework Core 6.0.0 initialized 'DatabaseContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer:6.0.0' with options: None
To undo this action, use Remove-Migration.
PM> 
This to create
PM> Update-Database
next lecture 14 i think
Then override void OnModelCreating to add some default data
PM> Add-Migration SeedingData
PM> Update-Database