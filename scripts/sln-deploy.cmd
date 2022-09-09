@echo off
dotnet publish %ProjectPath% --output %SlnDeployment% --configuration %ConfigName% --framework %FrameworkMoniker% --version-suffix %VersionSuffix%
