@echo off
call %~dp0..\config.cmd
call %DeployShell%
: robocopy %~dp0..\artifacts %InstallBase% /e

: dotnet tool install --global dotnet-dump --version 6.0.328102
dotnet tool install --global dotnet-trace --version 6.0.328102
dotnet tool install --global dotnet-counters --version 6.0.328102
dotnet tool install --global dotnet-gcdump --version 6.0.328102
dotnet tool install --global Microsoft.dotnet-interactive --version 1.0.340501
dotnet tool install --global dotnet-reportgenerator-globaltool --version 5.1.9
dotnet tool install --global Octopus.DotNet.Cli --version 9.1.7
dotnet tool install --global fake-cli --version 5.23.0
dotnet tool install --global dotnet-svcutil --version 2.0.3
dotnet tool install --global dotnet-symbol --version 1.0.335501
dotnet tool install --global dotnet-sos --version 6.0.328102
dotnet tool install --global Microsoft.Web.LibraryManager.Cli --version 2.1.175
dotnet tool install --global Microsoft.CST.DevSkim.CLI --version 0.7.3-alpha
dotnet tool install --global dotnet-stack --version 6.0.328102
dotnet tool install --global dotnet-sql-cache --version 6.0.8
dotnet tool install --global Microsoft.dotnet-openapi --version 6.0.8
dotnet tool install --global Microsoft.dotnet-httprepl --version 6.0.0
dotnet tool install --global try-convert --version 0.9.232202
dotnet tool install --global dotnet-typegen --version 3.0.0
dotnet tool install --global RelationalGit --version 2.0.2
dotnet tool install --global ilspycmd --version 8.0.0.7106-preview2
dotnet tool install --global dotnet-grpc --version 2.48.0
dotnet tool install --global Microsoft.DotNet.Mage --version 6.0.1