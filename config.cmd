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

set EnvFile=%~dp0artifacts\%ProjectId%.env
echo # %ProjectId% env>%EnvFile%

set MimeTypes=%EnvSite%\mime.types

set Archives=%PArchives%

set PackageOut=%EnvRoot%\packages\%SlnId%

set RepoArchives=%Archives%\repos

set DevArchives=%Archives%\%EnvPartition%

set RepoArchive=%RepoArchives%\%SlnId%.zip

set SlnArchive=%DevArchives%\%SlnId%

set CommitLog=%RepoArchives%\%SlnId%.commit.log

set SlnRoot=%EnvRoot%\%EnvPartition%\%SlnId%

set Artifacts=%SlnRoot%\artifacts

set SlnArtifacts=%SlnRoot%\artifacts

set SlnLibs=%SlnRoot%\libs

set SlnTests=%SlnRoot%\test

set SlnArea=%SlnRoot%\%Area%

set ShellPath=%Artifacts%\bin\%BuildPrefix%.%ProjectId%\%ConfigName%\%FrameworkMoniker%\%RuntimeMoniker%\%ShellId%.exe

set ExternalDeps=%Artifacts%\deps

set NetSdk=%ExternalDeps%\dotnet

set DOTNET_ROOT=%NetSdk%

set PATH=%DOTNET_ROOT%;%PATH%

set Reports=%Artifacts%\reports

set Distributions=%Artifacts%\dist

set Deployments=%EnvRoot%\tools\z0

set NuGetDeps=%ExternalDeps%\nuget

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
echo Deployments=%Deployments%>>%EnvFile%
echo MimeTypes=%MimeTypes%>>%EnvFile%
echo Archives=%Archives%>>%EnvFile%
echo PackageOut=%PackageOut%>>%EnvFile%
echo RepoArchives=%RepoArchives%>>%EnvFile%
echo DevArchives=%DevArchives%>>%EnvFile%
echo RepoArchive=%RepoArchive%>>%EnvFile%
echo SlnArchive=%SlnArchive%>>%EnvFile%
echo CommitLog=%CommitLog%>>%EnvFile%
echo SlnRoot=%SlnRoot%>>%EnvFile%
echo Artifacts=%Artifacts%>>%EnvFile%
echo SlnArtifacts=%SlnArtifacts%>>%EnvFile%
echo SlnLibs=%SlnLibs%>>%EnvFile%
echo SlnArea=%SlnArea%>>%EnvFile%
echo ShellPath=%ShellPath%>>%EnvFile%
echo ExternalDeps=%ExternalDeps%>>%EnvFile%
echo NetSdk=%NetSdk%>>%EnvFile%
echo DOTNET_ROOT=%DOTNET_ROOT%>>%EnvFile%
echo PATH=%PATH%>>%EnvFile%
echo Reports=%Reports%>>%EnvFile%
echo Distributions=%Distributions%>>%EnvFile%
echo NugetDeps=%NugetDeps%>>%EnvFile%
echo SlnDist=%SlnDist%>>%EnvFile%
echo BuildLogs=%BuildLogs%>>%EnvFile%
echo SlnScripts=%SlnScripts%>>%EnvFile%
echo SlnProps=%SlnProps%>>%EnvFile%
echo AppSettings=%AppSettings%>>%EnvFile%
echo ProjectRoot=%ProjectRoot%>>%EnvFile%
echo ProjectScripts=%ProjectScripts%>>%EnvFile%
echo ProjectPath=%ProjectPath%>>%EnvFile%
echo ProjectSln=%ProjectSln%>>%EnvFile%
echo ProjectBin=%ProjectBin%>>%EnvFile%
echo ProjectObj=%ProjectObj%>>%EnvFile%
echo ProjectShell=%ProjectShell%>>%EnvFile%
echo ProjectDist=%ProjectDist%>>%EnvFile%
echo DeployedShell=%DeployedShell%>>%EnvFile%
echo BuildLogs=%BuildLogs%>>%EnvFile%

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
echo ProjectDist=%ProjectDist%>>%EnvFile%

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

: echo GitPush=%GitPush%>>%EnvFile%
: git remote add origin https://github.com/0xCM/z.git
: git branch -M main
: git push -u origin main