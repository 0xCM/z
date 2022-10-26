@echo off
call %~dp0..\config.cmd
set PubCmd=dotnet publish %ProjectPath% --verbosity Detailed /p:TargetFramework=net7.0 /p:NativeLib=Static /p:SelfContained=true /p:RuntimeIdentifier=win-x64 /p:PublishAot=true
call %PubCmd%