@echo off
set BuildPrefix=z0
set ProjectRoot=%SlnRoot%\%ProjectName%
set StagePath=%DevTools%\%BuildPrefix%\stage\%ToolName%
set DeployPath=%DevTools%\%BuildPrefix%\bin
set ProjectPath=%ProjectRoot%\%BuildPrefix%.%ProjectName%.csproj
set LogOptions=-bl:%BuildLogs%\%BuildPrefix%.%ProjectName%.binlog
set VerbosityOption=--verbosity normal
set OutputOption=--output %DeployPath%
set ConfigOption=--configuration %ConfigName%
set FrameworkOption=--framework %FrameworkMoniker%
set BuildProps=-p:PublishReadyToRun=true -p:PreserveCompilationContext=true -p:PublishDocumentationFiles=true -p:CopyLocalLockFileAssemblies=true -p:CopyDebugSymbolsFromPackages=true -p:CopyDocumentationFilesFromPackages=true
set PublishApp=dotnet publish %ProjectPath% %OutputOption% %ConfigOption% %VerbosityOption% %FrameworkOption% %BuildProps% %LogOptions% %BuildProps%
echo PublishApp=%PublishApp%
call %PublishApp%
