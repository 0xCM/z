@echo off
dotnet publish %ProjectPath% --output %ShellDeployment% --configuration %ConfigName% --framework %FrameworkMoniker%
