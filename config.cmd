@echo off
call %EnvRoot%\settings\config.cmd
set SlnId=z0
set SlnRoot=%DevRoot%\%SlnId%
set CfgFile=%SlnRoot%\%SlnId%.cfg
set BuildPrefix=z0
set DotNetVer=6.0.303
set ArchName=x64
set OsName=win
set ConfigName=Release
set FrameworkMoniker=net6.0
set PlatformName="Any CPU"
set RuntimeMoniker=%OsName%-%ArchName%
set SlnMain=%SlnRoot%\z0.sln
set RepoArchive=%RepoArchives%\%SlnId%.zip
set SlnArchive=%DevArchives%\%SlnId%
set CommitLog=%RepoArchives%\%SlnId%.commit.log
set Artifacts=%SlnRoot%\artifacts
set SlnArtifacts=%SlnRoot%\artifacts
set SlnBin=%Artifacts%\bin
set SlnDeps=%Artifacts%\deps
set SlnObj=%Artifacts%\obj
set SlnLogs=%Artifacts%\logs
set SlnTests=%SlnRoot%\test
set SlnArea=%SlnRoot%\%Area%
set ShellPath=%Artifacts%\bin\%BuildPrefix%.%ProjectId%\%ConfigName%\%FrameworkMoniker%\%RuntimeMoniker%\%ShellId%.exe
set NetSdk=%Artifacts%\deps\dotnet
set Reports=%Artifacts%\reports
set Distributions=%Artifacts%\dist
set NuGetDeps=%SlnDeps%\nuget
set SlnDist=%Distributions%\%SlnId%
set BuildLogs=%Artifacts%\logs
set SlnScripts=%SlnRoot%\scripts
set SlnProps=%SlnRoot%\props
set ProjectRoot=%SlnRoot%\%Area%\%ProjectId%
set ProjectScripts=%ProjectRoot%\scripts
set ProjectPath=%ProjectRoot%\%BuildPrefix%.%ProjectId%.csproj
set ProjectSln=%ProjectRoot%\%BuildPrefix%.%ProjectId%.sln
set ProjectBin=%Artifacts%\bin\%BuildPrefix%.%ProjectId%
set TargetBuildRoot=%ProjectBin%\%ConfigName%\%FrameworkMoniker%
set ShellBin=%TargetBuildRoot%\%RuntimeMoniker%

set ProjectObj=%Artifacts%\obj\%BuildPrefix%.%ProjectId%
set ProjectPdb=%Artifacts%\pdb\%BuildPrefix%.%ProjectId%
set ProjectRuntime=%ProjectBin%\%ConfigName%\%FrameworkMoniker%\%RuntimeMoniker%
set ProjectShell=%ProjectRuntime%\%ShellId%.exe
set ProjectDist=%Distributions%\%ProjectId%
set PublishedShell=%ProjectDist%\%ShellId%.exe
set Deployments=b:\tools\z0\bin
set DeployedShell=%Deployments%\%ShellId%.exe
set DeploySln=%SlnScripts%\sln-deploy.cmd
set SlnPath=%SlnArea%\z0.%Area%.sln
set BuildLogs=%Artifacts%\logs
set LibName=z0.%ProjectId%.dll
set TestLog=%BuildLogs%\z0.%ProjectId%.tests.trx
set RootSlnLogPath=%BuildLogs%\%BuildPrefix%.sln.binlog
set RootSlnLogSpec=-bl:%RootSlnLogPath%
set RootSlnPath=%SlnRoot%\z0.sln
set SlnRootPath=%SlnRoot%\z0.sln
set BuildLog=%BuildLogs%\%BuildPrefix%.%ProjectId%.log
set SlnBuildLog=%BuildLogs%\%BuildPrefix%.%SlnId%.log
set BuildLogPath=%BuildLogs%\%BuildPrefix%.%ProjectId%.binlog
set BuildLogSpec=-bl:%BuildLogPath%
set BuildOptions=-graph:true -m:24
set BuildTool=dotnet build
set BuildProps=/p:Configuration=%ConfigName% /p:Platform=%PlatformName%
set BuildProject=%BuildTool% %ProjectPath% %BuildProps% %BuildLogSpec%; %BuildOptions%
set BuildSln=%BuildTool% %RootSlnPath% %BuildProps% %BuildLogSpec%; %BuildOptions%
set BuildShells=%BuildTool% %SlnRoot%\shells\z0.shells.sln %BuildProps% -bl:%BuildLogs%\z0.shells.binlog; %BuildOptions%
set BuildDeployment=%BuildTool% %~dp0deploy\z0.deploy.sln %BuildProps% -bl:%BuildLogs%\z0.deploy.binlog; %BuildOptions%
set BuildProjectSln=%BuildTool% %ProjectSln% %BuildProps% %BuildLogSpec%; %BuildOptions%

set PublishSln=%PublishTool% %ProjecSln%
set BuildSlnRoot=%BuildTool% %SlnRoot%\z0.sln %BuildProps% %RootSlnLogSpec%; %BuildOptions%
set ShellName=%ShellId%.exe
set ShellExePath=%TargetBuildRoot%\%RuntimeMoniker%\%ShellName%
set DllShellBin=%TargetBuildRoot%
set DllShellPath=%DllShellBin%\z0.%ProjectId%.exe
set shell=%ShellExePath%
set dllshell=%DllShellPath%
set CleanBuild=rmdir %Artifacts% /s/q
set CleanObj=rmdir %Artifacts%\obj /s/q
set CleanBin=rmdir %Artifacts%\bin \s\q
set CleanProject=rmdir %ProjectBin% /s/q
set CleanNugetDeps=rmdir %NuGetDeps% /s/q
set AddSlnProject=%SlnScripts%\sln-add.cmd
set ProjectDist=%Distributions%\%ProjectId%
set CleanSlnDist=rmdir %Artifacts%\dist /s/q
set CleanSlnBin=rmdir %Artifacts%\bin /s/q
set CleanSlnObj=rmdir %Artifacts%\obj /s/q
set PublishedSln=%Artifacts%\public\bin
set SlnPublish=dotnet publish %~dp0deploy/z0.deploy.sln --output %PublishedSln% --configuration %ConfigName% --framework %FrameworkMoniker%
set PublishLib=dotnet publish %ProjectPath% --output %ProjectDist% --configuration %ConfigName% --framework %FrameworkMoniker%
set PublishShell=dotnet publish %ProjectPath% --output %ProjectDist% --configuration %ConfigName% --framework %FrameworkMoniker%
set DeployShell=%~dp0scripts\shell-deploy.cmd
set SlnPubRetract=rmdir %PublishedSln%
set RestoreProject=dotnet restore %ProjectPath% --packages %NuGetDeps% --use-current-runtime --verbosity normal --force-evaluate
set ProjectNugetConfig=%ProjectRoot%\nuget.config
set LocalRestore=dotnet restore %ProjectPath% --packages %NuGetDeps% --use-current-runtime --verbosity normal --force-evaluate --configfile %ProjectNugetConfig%
set ServeSite=http-server %SlnRoot% --port 48005 --ext txt --mimetypes %MimeTypes% --gzip --brotli -o
set RunToolOptions=--project %ProjectPath% --framework %FrameworkMoniker% --configuration %ConfigName% --runtime %RuntimeMoniker% --verbosity normal --self-contained
set RunTool=dotnet run %RunToolOptions%
set GitPush=git push -u origin main -v
set CleanBin=rmdir %ProjectBin% /s/q
set CleanObj=rmdir %ProjectObj% /s/q
set CleanSlnBin=rmdir %SlnBin% /s/q
set CleanSlnObj=rmdir %SlnObj% /s/q
set CleanSlnLogs=rmdir %SlnLogs% /s/q
set ArchiveSln=robocopy %SlnRoot% %DevArchives%\z0 /xd %SlnRoot%\.git /v /mir /fp /log:%DevArchives%\z0.archive.log
set ArchiveRepo=git archive -v -o %RepoArchive% HEAD
set DeployCfg=%SlnRoot%\deploy\deploy.cfg
set PlatformDeployment=%EnvB%\tools\z0\bin
