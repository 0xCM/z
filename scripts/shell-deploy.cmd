@echo off
call %~dp0shell-retract.cmd
call %DeleteShellDeploymentLink% 2>nul
dotnet publish %ProjectPath% --output %ShellDeployment% --configuration %ConfigName% --framework %FrameworkMoniker% --version-suffix %VersionSuffix%
call %CreateShellDeploymentLink%