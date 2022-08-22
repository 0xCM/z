@echo off
echo Level:%~dp0
call %~dp0..\config.cmd
set BuildPrefix=z0
set SlnVersion=0.0.1
set ArchName=x64
set OsName=win
set ConfigName=Release
set FrameworkMoniker=net6.0
set PlatformName="Any CPU"
set RuntimeMoniker=%OsName%-%ArchName%
set VersionSuffix=3
set SlnId=z0

set EnvFile=%~dp0artifacts\%ProjectId%.env
echo # %ProjectId% env>%EnvFile%

set Archives=%EnvRoot%\archives
echo Archives=%Archives%>>%EnvFile%

set PackageOut=%EnvRoot%\packages\%SlnId%
echo PackageOut=%PackageOut%>>%EnvFile%

set RepoArchives=%Archives%\repos
echo RepoArchives=%RepoArchives%>>%EnvFile%

set RepoArchive=%RepoArchives%\%SlnId%.zip
echo RepoArchive=%RepoArchive%>>%EnvFile%

set CommitLog=%RepoArchives%\%SlnId%.commit.log
echo CommitLog=%CommitLog%>>%EnvFile%

set SlnRoot=%EnvRoot%\dev\%SlnId%
echo SlnRoot=%SlnRoot%>>%EnvFile%

set Artifacts=%SlnRoot%\artifacts
echo Artifacts=%Artifacts%>>%EnvFile%

set SlnArtifacts=%SlnRoot%\artifacts
echo SlnArtifacts=%SlnArtifacts%>>%EnvFile%

set SlnLibs=%SlnRoot%\libs
echo SlnLibs=%SlnLibs%>>%EnvFile%

set SlnShells=%SlnRoot%\shells
set SlnTests=%SlnRoot%\test

set SlnArea=%SlnRoot%\%Area%
echo SlnArea=%SlnArea%>>%EnvFile%

set ExternalDeps=%Artifacts%\deps
echo ExternalDeps=%ExternalDeps%>>%EnvFile%

set NetSdk=%ExternalDeps%\dotnet
echo NetSdk=%NetSdk%>>%EnvFile%

set DOTNET_ROOT=%NetSdk%
echo DOTNET_ROOT=%DOTNET_ROOT%>>%EnvFile%

set PATH=%DOTNET_ROOT%;%PATH%
echo PATH=%PATH%>>%EnvFile%

set Reports=%Artifacts%\reports
echo Reports=%Reports%>>%EnvFile%

set Distributions=%Artifacts%\dist
echo Distributions=%Distributions%>>%EnvFile%

set Deployments=%EnvRoot%\tools\z0
echo Deployments=%Deployments%>>%EnvFile%

set NuGetDeps=%ExternalDeps%\nuget
echo NugetDeps=%NugetDeps%>>%EnvFile%

set SlnDist=%Distributions%\%SlnId%
echo SlnDist=%SlnDist%>>%EnvFile%

set BuildLogs=%Artifacts%\logs
echo BuildLogs=%BuildLogs%>>%EnvFile%

set SlnScripts=%SlnRoot%\scripts
echo SlnScripts=%SlnScripts%>>%EnvFile%

set SlnProps=%SlnRoot%\props
echo SlnProps=%SlnProps%>>%EnvFile%

set AppSettings=%SlnProps%\app.settings.csv
echo AppSettings=%AppSettings%>>%EnvFile%

set ProjectRoot=%SlnRoot%\%Area%\%ProjectId%
set ProjectSlnFile=%BuildPrefix%.%ProjectId%.sln
set ProjectFile=%BuildPrefix%.%ProjectId%.csproj

set ProjectScripts=%ProjectRoot%\scripts
echo ProjectScripts=%ProjectScripts%>>%EnvFile%

set ProjectPath=%ProjectRoot%\%BuildPrefix%.%ProjectId%.csproj
echo ProjectPath=%ProjectPath%>>%EnvFile%

set ProjectSln=%ProjectRoot%\%BuildPrefix%.%ProjectId%.sln
echo ProjectSln=%ProjectSln%>>%EnvFile%

set ProjectBin=%Artifacts%\bin\%BuildPrefix%.%ProjectId%
set ProjectObj=%Artifacts%\obj\%BuildPrefix%.%ProjectId%

set ProjectShell=%ProjectBin%\%ConfigName%\%FrameworkMoniker%\%RuntimeMoniker%\%ShellId%.exe
echo ProjectShell=%ProjectShell%>>%EnvFile%

set ProjectDist=%Distributions%\%ProjectId%
echo ProjectDist=%ProjectDist%>>%EnvFile%

set PublishedShell=%ProjectDist%\%ShellId%.exe
set DeployedShell=%Deployments%\%ProjectId%\%ShellId%.exe
set BuildProps=/p:Configuration=%ConfigName% /p:Platform=%PlatformName%
set SlnPath=%SlnArea%\z0.%Area%.sln

set BuildLogs=%Artifacts%\logs
echo BuildLogs=%BuildLogs%>>%EnvFile%

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
set BuildProject=%BuildTool% %ProjectPath% %BuildProps% %BuildLogSpec%; %BuildOptions%
set BuildSln=%BuildTool% %SlnPath% %BuildProps% %BuildLogSpec%; %BuildOptions%
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
set CmdShellRoot=%SlnRoot%\cmd
set CmdProject=%CmdShellRoot%\z0.cmd.csproj

set BuildCmdShell=%BuildTool% %~dp0cmd\z0.cmd.csproj %BuildProps% %BuildLogSpec%; %BuildOptions%

set ShellDeployment=%Deployments%\%ShellId%
set CleanBuild=rmdir %Artifacts% \s\q
set CleanObj=rmdir %Artifacts%\obj \s\q
set CleanBin=rmdir %Artifacts%\bin \s\q
set CleanNugetDeps=rmdir %NuGetDeps% \s\q
set AddSlnProject=%SlnScripts%\sln-add.cmd

set ProjectDist=%Distributions%\%ProjectId%
echo ProjectDist=%ProjectDist%>>%EnvFile%

set PublishLib=dotnet publish %ProjectPath% --output %ProjectDist% --configuration %ConfigName% --framework %FrameworkMoniker% --version-suffix %VersionSuffix%

set PublishShell=dotnet publish %ProjectPath% --output %ProjectDist% --configuration %ConfigName% --framework %FrameworkMoniker% --version-suffix %VersionSuffix%

set DeployShell=dotnet publish %ProjectPath% --output %ShellDeployment% --configuration %ConfigName% --framework %FrameworkMoniker% --version-suffix %VersionSuffix%

set PackageLib=dotnet pack %ProjectPath% --output %PackageDist% --configuration %ConfigName% --version-suffix %VersionSuffix% %PackageFlags%
echo PackageLib=%PackageLib%>>%EnvFile%

set PackageSln=dotnet pack %ProjectSln% --output %PackagePath%
echo PackageSln=%PackageSln%>>%EnvFile%

: set PublishSln=dotnet publish %RootSlnPath% --output %SlnDist% %PackageFlags% --version-suffix %VersionSuffix% 

set RestoreProject=dotnet restore %ProjectPath% --packages %NuGetDeps% --use-current-runtime --verbosity normal --force-evaluate
echo RestoreProject=%RestoreProject%>>%EnvFile%

set ProjectNugetConfig=%ProjectRoot%\nuget.config
set LocalRestore=dotnet restore %ProjectPath% --packages %NuGetDeps% --use-current-runtime --verbosity normal --force-evaluate --configfile %ProjectNugetConfig%
set MimeTypes=%EnvSite%\mime.types

set ServeSite=http-server %SlnRoot% --port 48005 --ext txt --mimetypes %MimeTypes% --gzip --brotli -o
echo ServeSite=%ServeSite%>>%EnvFile%

set ShellPath=%Artifacts%\bin\%BuildPrefix%.%ProjectId%\%ConfigName%\%FrameworkMoniker%\%RuntimeMoniker%\%ShellId%.exe`
echo ShellPath=%ShellPath%>>%EnvFile%

set RunToolOptions=--project %ProjectPath% --framework %FrameworkMoniker% --configuration %ConfigName% --runtime %RuntimeMoniker% --verbosity normal --self-contained
set RunTool=dotnet run %RunToolOptions%

echo RunTool=%RunTool%>>%EnvFile%

set GitPush=git push -u origin main -v
: echo GitPush=%GitPush%>>%EnvFile%

: git remote add origin https://github.com/0xCM/z.git
: git branch -M main
: git push -u origin main