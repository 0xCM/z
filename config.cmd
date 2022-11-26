@echo off
call %EnvRoot%\settings\config.cmd
set SlnRoot=%DevRoot%\z0
set ConfigName=Release
set SlnName=z0
set CfgFile=%SlnRoot%\%SlnName%.cfg
set BuildPrefix=z0
set DotNetVer=6.0.303
set ArchName=x64
set OsName=win
set Configuration=%ConfigName%
set FrameworkMoniker=net6.0
set PlatformName="Any CPU"
set RuntimeMoniker=%OsName%-%ArchName%
set SlnMain=%SlnRoot%\z0.sln
set RepoArchive=%RepoArchives%\%SlnName%.zip
set SlnArchive=%DevArchives%\%SlnName%
set CommitLog=%RepoArchives%\%SlnName%.commit.log
set Artifacts=%SlnRoot%\artifacts
set SlnArtifacts=%SlnRoot%\artifacts
set SlnBin=%Artifacts%\bin
set SlnDeps=%Artifacts%\deps
set SlnObj=%Artifacts%\obj
set SlnLogs=%Artifacts%\logs
set SlnTests=%SlnRoot%\test
set SlnArea=%SlnRoot%\%Area%
set ShellPath=%Artifacts%\bin\%BuildPrefix%.%ProjectName%\%ConfigName%\%FrameworkMoniker%\%RuntimeMoniker%\%ToolName%.exe
set NetSdk=%Artifacts%\deps\dotnet
set Reports=%Artifacts%\reports
set Distributions=%Artifacts%\dist
set NuGetDeps=%SlnDeps%\nuget
set SlnDist=%Distributions%\%SlnName%
set BuildLogs=%Artifacts%\logs
set SlnScripts=%SlnRoot%\scripts
set SlnProps=%SlnRoot%\props
set ProjectRoot=%SlnRoot%\src\%ProjectName%
set ProjectScripts=%ProjectRoot%\scripts
set ProjectPath=%ProjectRoot%\%BuildPrefix%.%ProjectName%.csproj
set ProjectSln=%ProjectRoot%\%BuildPrefix%.%ProjectName%.sln
set ProjectBin=%Artifacts%\bin\%BuildPrefix%.%ProjectName%
set TargetBuildRoot=%ProjectBin%\%ConfigName%\%FrameworkMoniker%
set ShellBin=%TargetBuildRoot%\%RuntimeMoniker%
set ProjectObj=%Artifacts%\obj\%BuildPrefix%.%ProjectName%
set ProjectPdb=%Artifacts%\pdb\%BuildPrefix%.%ProjectName%
set ProjectDist=%Distributions%\%ProjectName%
set PublishedShell=%ProjectDist%\%ShellId%.exe
set DeploySln=%SlnScripts%\sln-deploy.cmd
set SlnPath=%SlnArea%\z0.%Area%.sln
set BuildLogs=%Artifacts%\logs
set LibName=z0.%ProjectName%.dll
set TestLog=%BuildLogs%\z0.%ProjectName%.tests.trx
set RootSlnLogPath=%BuildLogs%\%BuildPrefix%.sln.binlog
set RootSlnLogSpec=-bl:%RootSlnLogPath%
set RootSlnPath=%SlnRoot%\z0.sln
set SlnRootPath=%SlnRoot%\z0.sln
set BuildLog=%BuildLogs%\%BuildPrefix%.%ProjectName%.log
set SlnBuildLog=%BuildLogs%\%BuildPrefix%.%SlnName%.log
set BuildLogPath=%BuildLogs%\%BuildPrefix%.%ProjectName%.binlog
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
set DllShellPath=%DllShellBin%\z0.%ProjectName%.exe
set shell=%ShellExePath%
set dllshell=%DllShellPath%
set CleanBuild=rmdir %Artifacts% /s/q
set CleanObj=rmdir %Artifacts%\obj /s/q
set CleanBin=rmdir %Artifacts%\bin \s\q
set CleanProject=rmdir %ProjectBin% /s/q
set CleanNugetDeps=rmdir %NuGetDeps% /s/q
set AddSlnProject=%SlnScripts%\sln-add.cmd
set ProjectDist=%Distributions%\%ProjectName%
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
