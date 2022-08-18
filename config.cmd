@echo off

set BuildTool=dotnet build
set PackageTool=dotnet pack --include-symbols --include-source
set BuildPrefix=z0
set SlnVersion=0.0.1
set VersionSuffix=3
set Platform="Any CPU"
set FrameworkMoniker=net6.0
set TargetFramework=%FrameworkMoniker%
set BuildKind=Release
set RuntimeMoniker=win-x64
set Configuration=Release
set SlnId=z0
set SlnRoot=%~dp0
set AreaRoot=%SlnRoot%%Area%
set Artifacts=%SlnRoot%artifacts
set Reports=%Artifacts%\reports
set Distributions=%Artifacts%\dist
set Packages=%Artifacts%\packages
set Deployments=%Views%\tools\z0
set ExternalDeps=%Artifacts%\deps
set NuGetDeps=%ExternalDeps%\nuget
set NetSdk=%ExternalDeps%\dotnet
set DOTNET_ROOT=%NetSdk%
set PATH=%DOTNET_ROOT%;%PATH%
set ProjectDist=%Distributions%\%ProjectId%
set PackageDist=%Packages%
set SlnDist=%Distributions%\%SlnId%

set BuildLogs=%Artifacts%\logs
set SlnScripts=%SlnRoot%scripts
set Archives=%Views%\archives
set RepoArchives=%Archives%\repos
set RepoArchive=%RepoArchives%\%SlnId%.zip
set CommitLog=%RepoArchives%\%SlnId%.commit.log

set ProjectProps=%SlnRoot%\props\
set AppSettings=%ProjectProps%app.settings.csv

set ProjectRoot=%SlnRoot%\%Area%\%ProjectId%
set ProjectSlnFile=%BuildPrefix%.%ProjectId%.sln
set ProjectFile=%BuildPrefix%.%ProjectId%.csproj
set ProjectScripts=%ProjectRoot%\scripts
set ProjectPath=%ProjectRoot%\%BuildPrefix%.%ProjectId%.csproj
set ProjectSln=%ProjectRoot%\%BuildPrefix%.%ProjectId%.sln
set ProjectBin=%Artifacts%\bin\%BuildPrefix%.%ProjectId%
set ProjectObj=%Artifacts%\obj\%BuildPrefix%.%ProjectId%
set ProjectShell=%ProjectBin%\%Configuration%\%TargetFramework%\%RuntimeMoniker%\%ShellId%.exe
set ProjectPubs=%Distributions%\%ProjectId%
set PublishedShell=%ProjectPubs%\%ShellId%.exe
set DeployedShell=%Deployments%\%ProjectId%\%ShellId%.exe

set BuildProps=/p:Configuration=%Configuration% /p:Platform=%Platform%
set TestRoot=%SlnRoot%test
set LibRoot=%SlnRoot%libs
set SlnPath=%AreaRoot%\z0.%Area%.sln
set BuildLogs=%Artifacts%\logs

set CleanProjectBin=rmdir %ProjectBin% /s/q
set CleanProjectObj=rmdir %ProjectObj% /s/q

set LibName=z0.%ProjectId%.dll

set CgRoot=%SlnRoot%cg

set WsBin=%Artifacts%\bin
set TestLog=%BuildLogs%\z0.%ProjectId%.tests.trx

set RootSlnLogPath=%BuildLogs%\%BuildPrefix%.sln.binlog
set RootSlnLogSpec=-bl:%RootSlnLogPath%

set RootSlnPath=%SlnRoot%z0.sln
set SlnRootPath=%SlnRoot%\z0.sln
set BuildLog=%BuildLogs%\%BuildPrefix%.%ProjectId%.log
set SlnBuildLog=%BuildLogs%\%BuildPrefix%.%SlnId%.log

set BuildLogPath=%BuildLogs%\%BuildPrefix%.%ProjectId%.binlog
set BuildLogSpec=-bl:%BuildLogPath%

set BuildOptions=-graph:true -m:24

set BuildProject=%BuildTool% %ProjectPath% %BuildProps% %BuildLogSpec%; %BuildOptions%

set BuildSln=%BuildTool% %SlnPath% %BuildProps% %BuildLogSpec%; %BuildOptions%
set BuildProjectSln=%BuildTool% %ProjectSln% %BuildProps% %BuildLogSpec%; %BuildOptions%
set PackageProject=%PackageTool% %ProjectPath%
set PackageSln=%PackageTool% %ProjectSln%
set PublishSln=%PublishTool% %ProjecSln%

set TargetBuildRoot=%ProjectBin%\%BuildPrefix%.%ProjectId%\%BuildKind%\%TargetFramework%

set BuildSlnRoot=%BuildTool% %RootSlnPath% %BuildProps% %RootSlnLogSpec%; %BuildOptions%

set ShellName=%ShellId%.exe
set ShellExePath=%TargetBuildRoot%\%RuntimeMoniker%\%ShellName%
set DllShellBin=%TargetBuildRoot%
set DllShellPath=%DllShellBin%\z0.%ProjectId%.exe

set shell=%ShellExePath%
set dllshell=%DllShellPath%

set CmdShellRoot=%SlnRoot%\cmd
set CmdProject=%CmdShellRoot%\z0.cmd.csproj
set BuildCmdShell=%BuildTool% %CmdProject% %BuildProps% %BuildLogSpec%; %BuildOptions%

set SlnLibs=%SlnRoot%\libs
set SlnShells=%SlnRoot%\shells
set SlnCg=%SlnRoot%\cg
set SlnTests=%SlnRoot%\test

set ShellDeployment=%Deployments%\%ShellId%

set PackageFlags=--include-symbols --include-source
set CleanBuild=rmdir %Artifacts% /s/q
set CleanObj=rmdir %Artifacts%\obj /s/q
set CleanBin=rmdir %Artifacts%\bin /s/q
set CleanNugetDeps=rmdir %NuGetDeps% /s/q
set AddSlnProject=%SlnScripts%\sln-add.cmd
set PackagePath=%PackageDist%\%BuildPrefix%.%ProjectId%.%SlnVersion%.nupkg

set PublishLib=dotnet publish %ProjectPath% --output %ProjectDist% --configuration %Configuration% --framework %FrameworkMoniker% --version-suffix %VersionSuffix%
set PublishShell=dotnet publish %ProjectPath% --output %ProjectDist% --configuration %Configuration% --framework %FrameworkMoniker% --version-suffix %VersionSuffix%
set DeployShell=dotnet publish %ProjectPath% --output %ShellDeployment% --configuration %Configuration% --framework %FrameworkMoniker% --version-suffix %VersionSuffix%
set PackageLib=dotnet pack %ProjectPath% --output %PackageDist% --configuration %Configuration% --version-suffix %VersionSuffix% %PackageFlags%
set PackageSln=dotnet pack %ProjectSln% --output %PackagePath%
set PublishSln=dotnet publish %RootSlnPath% --output %SlnDist% %PackageFlags% --version-suffix %VersionSuffix% 
set RestoreProject=dotnet restore %ProjectPath% --packages %NuGetDeps% --use-current-runtime --verbosity normal --force-evaluate
set ProjectNugetConfig=%ProjectRoot%\nuget.config
set LocalRestore=dotnet restore %ProjectPath% --packages %NuGetDeps% --use-current-runtime --verbosity normal --force-evaluate --configfile %ProjectNugetConfig%
set MimeTypes=%Views%\db\servers\mime.types
set WsServe=http-server %SlnRoot% --port 48005 --ext txt --mimetypes %MimeTypes% --gzip --brotli -o
set RestoreDeps=dotnet restore %ProjectProps%deps.props --packages %NuGetDeps% --use-current-runtime --verbosity normal --force-evaluate
: mkdir %BuildLogs% 1>nul 2>nul
: mkdir %NuGetDeps% 1>nul 2>nul