@echo off
echo Level:%~dp0
call %~dp0..\config.cmd

set EnvPartition=dev
set SlnId=z0
set BuildPrefix=z0
set SlnVersion=0.0.1
set ArchName=x64
set OsName=win
set ConfigName=Release
set FrameworkMoniker=net6.0
set PlatformName="Any CPU"
set RuntimeMoniker=%OsName%-%ArchName%
set VersionSuffix=3
set SlnRoot=%Z0%
set MimeTypes=%EnvSite%\mime.types
set Archives=%PArchives%
set PackageOut=%EnvRoot%\packages\%SlnId%
set RepoArchives=%Archives%\repos
set DevArchives=%Archives%\%EnvPartition%
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
set DOTNET_ROOT=%NetSdk%
set PATH=%DOTNET_ROOT%;%PATH%
set Reports=%Artifacts%\reports
set Distributions=%Artifacts%\dist
set Deployments=%EnvRoot%\tools\z0
set NuGetDeps=%SlnDeps%\nuget
set SlnDist=%Distributions%\%SlnId%
set BuildLogs=%Artifacts%\logs
set SlnScripts=%SlnRoot%\scripts
set SlnProps=%SlnRoot%\props
set AppSettings=%SlnProps%\app.settings.csv
set ProjectRoot=%SlnRoot%\%Area%\%ProjectId%
set ProjectScripts=%ProjectRoot%\scripts
set ProjectPath=%ProjectRoot%\%BuildPrefix%.%ProjectId%.csproj
set ProjectSln=%ProjectRoot%\%BuildPrefix%.%ProjectId%.sln
set ProjectBin=%Artifacts%\bin\%BuildPrefix%.%ProjectId%
set ProjectObj=%Artifacts%\obj\%BuildPrefix%.%ProjectId%
set ProjectShell=%ProjectBin%\%ConfigName%\%FrameworkMoniker%\%RuntimeMoniker%\%ShellId%.exe
set ProjectDist=%Distributions%\%ProjectId%
set PublishedShell=%ProjectDist%\%ShellId%.exe

set DeployedShell=%Deployments%\%ProjectId%\%ShellId%.exe
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
set BuildSln=%BuildTool% %SlnPath% %BuildProps% %BuildLogSpec%; %BuildOptions%
set BuildShells=%BuildTool% %SlnRoot%\shells\z0.shells.sln %BuildProps% -bl:%BuildLogs%\z0.shells.binlog; %BuildOptions%
set BuildProjectSln=%BuildTool% %ProjectSln% %BuildProps% %BuildLogSpec%; %BuildOptions%
set Packages=%Artifacts%\packages
set PackageFlags=--include-symbols --include-source
set PackageTool=dotnet pack %PackageFlags%
set PackageProject=%PackageTool% %ProjectPath%
set PackagePath=%Packages%\%BuildPrefix%.%ProjectId%.%SlnVersion%.nupkg
set PackageSln=%PackageTool% %ProjectSln%
set PublishSln=%PublishTool% %ProjecSln%
set TargetBuildRoot=%ProjectBin%\%BuildPrefix%.%ProjectId%\%ConfigName%\%FrameworkMoniker%
set BuildSlnRoot=%BuildTool% %SlnRoot%\z0.sln %BuildProps% %RootSlnLogSpec%; %BuildOptions%
set ShellName=%ShellId%.exe
set ShellExePath=%TargetBuildRoot%\%RuntimeMoniker%\%ShellName%
set DllShellBin=%TargetBuildRoot%
set DllShellPath=%DllShellBin%\z0.%ProjectId%.exe
set shell=%ShellExePath%
set dllshell=%DllShellPath%
set ShellDeployment=%Deployments%\%ShellId%
set CleanBuild=rmdir %Artifacts% \s\q
set CleanObj=rmdir %Artifacts%\obj \s\q
set CleanBin=rmdir %Artifacts%\bin \s\q
set CleanNugetDeps=rmdir %NuGetDeps% \s\q
set AddSlnProject=%SlnScripts%\sln-add.cmd

set ProjectDist=%Distributions%\%ProjectId%

set PublishLib=dotnet publish %ProjectPath% --output %ProjectDist% --configuration %ConfigName% --framework %FrameworkMoniker% --version-suffix %VersionSuffix%
set PublishShell=dotnet publish %ProjectPath% --output %ProjectDist% --configuration %ConfigName% --framework %FrameworkMoniker% --version-suffix %VersionSuffix%
set DeployShell=dotnet publish %ProjectPath% --output %ShellDeployment% --configuration %ConfigName% --framework %FrameworkMoniker% --version-suffix %VersionSuffix%
set PackageLib=dotnet pack %ProjectPath% --output %PackageDist% --configuration %ConfigName% --version-suffix %VersionSuffix% %PackageFlags%
set PackageSln=dotnet pack %ProjectSln% --output %PackagePath%
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

set CfgFile=%Artifacts%\%ProjectId%.cfg

: mkdir %Artifacts% 1>nul 2>nul
echo # %ProjectId% env>%CfgFile%
echo Deployments=%Deployments%>>%CfgFile%
echo MimeTypes=%MimeTypes%>>%CfgFile%
echo Archives=%Archives%>>%CfgFile%
echo PackageOut=%PackageOut%>>%CfgFile%
echo RepoArchives=%RepoArchives%>>%CfgFile%
echo DevArchives=%DevArchives%>>%CfgFile%
echo RepoArchive=%RepoArchive%>>%CfgFile%
echo SlnArchive=%SlnArchive%>>%CfgFile%
echo CommitLog=%CommitLog%>>%CfgFile%
echo SlnRoot=%SlnRoot%>>%CfgFile%
echo SlnBin=%SlnBin%>>%CfgFile%
echo SlnObj=%SlnObj%>>%CfgFile%
echo SlnLogs=%SlnLogs%>>%CfgFile%
echo SlnArea=%SlnArea%>>%CfgFile%
echo ShellPath=%ShellPath%>>%CfgFile%
echo NetSdk=%NetSdk%>>%CfgFile%
echo DOTNET_ROOT=%DOTNET_ROOT%>>%CfgFile%
echo PATH=%PATH%>>%CfgFile%
echo Reports=%Reports%>>%CfgFile%
echo Distributions=%Distributions%>>%CfgFile%
echo NugetDeps=%NugetDeps%>>%CfgFile%
echo SlnDist=%SlnDist%>>%CfgFile%
echo BuildLogs=%BuildLogs%>>%CfgFile%
echo SlnScripts=%SlnScripts%>>%CfgFile%
echo SlnProps=%SlnProps%>>%CfgFile%
echo AppSettings=%AppSettings%>>%CfgFile%
echo ProjectRoot=%ProjectRoot%>>%CfgFile%
echo ProjectScripts=%ProjectScripts%>>%CfgFile%
echo ProjectPath=%ProjectPath%>>%CfgFile%
echo ProjectSln=%ProjectSln%>>%CfgFile%
echo ProjectBin=%ProjectBin%>>%CfgFile%
echo ProjectObj=%ProjectObj%>>%CfgFile%
echo ProjectShell=%ProjectShell%>>%CfgFile%
echo ProjectDist=%ProjectDist%>>%CfgFile%
echo DeployedShell=%DeployedShell%>>%CfgFile%
echo BuildLogs=%BuildLogs%>>%CfgFile%
echo ProjectDist=%ProjectDist%>>%CfgFile%

: echo GitPush=%GitPush%>>%CfgFile%
: git remote add origin https://github.com/0xCM/z.git
: git branch -M main
: git push -u origin main