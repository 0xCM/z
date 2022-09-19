@echo off
call %~dp0config.cmd

dotnet new sln

dotnet sln %SlnPath% add %WsRoot%/z0.%WsId%.csproj

set ProjectId=cmd.exec
dotnet sln %SlnPath% add %LibsWs%/%ProjectId%/z0.%ProjectId%.csproj

set ProjectId=cmd.specs
dotnet sln %SlnPath% add %LibsWs%/%ProjectId%/z0.%ProjectId%.csproj

set ProjectId=cmd.svc
dotnet sln %SlnPath% add %LibsWs%/%ProjectId%/z0.%ProjectId%.csproj

set ProjectId=archives
dotnet sln %SlnPath% add %LibsWs%/%ProjectId%/z0.%ProjectId%.csproj

set ProjectId=lib
dotnet sln %SlnPath% add %LibsWs%/%ProjectId%/z0.%ProjectId%.csproj



