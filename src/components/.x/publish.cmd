@echo off
call %~dp0..\config.cmd
set BuildProps=/p:PublishReadyToRun=true /p:PublishSingleFile=true /p:DebugType=embedded /p:PublishDocumentationFiles=false /p:CopyDebugSymbolsFromPackages=true /p:CopyDocumentationFilesFromPackages=false /p:IncludeNativeLibrariesInSingleFile=true
dotnet publish %BuildProps% --verbosity normal --output %SlnBuild%\%ProojectName%
