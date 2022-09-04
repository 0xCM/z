@echo off
call %~dp0sln-retract.cmd
dotnet publish %ProjectPath% --output %SlnDeployment% --configuration %ConfigName% --framework %FrameworkMoniker% --version-suffix %VersionSuffix%
