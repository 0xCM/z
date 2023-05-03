@echo off
call %EnvRoot%\buildkits\native\config.cmd
set DOTNET_ROOT=K:\dist\dotnet\unpacked\dotnet-sdk-6.0.303
set PATH=%DOTNET_ROOT%;%PATH%
set SlnName=z0
set SlnRoot=%~dp0..\%SlnName%
set SlnFilePath=%SlnRoot%\%SlnName%.sln
set ConfigName=Release
set FrameworkMoniker=net6.0
set VerbosityOption=--verbosity normal
set RepoArchive=%RepoArchives%\%SlnName%.zip
set CommitLog=%RepoArchives%\%SlnName%.commit.log
set Artifacts=%SlnRoot%\artifacts
set SlnBuild=%SlnRoot%\artifacts
set BuildLogs=%Artifacts%\logs
set ShellBuildProps=/p:Configuration=Release /p:Platform=x64 /p:DebugType=Embedded -bl:%BuildLogs%\z0.%ProjectName%.binlog
set ProjectBuildProps=/p:Configuration=Release /p:Platform=x64 /p:DebugType=Embedded -bl:%BuildLogs%\z0.%ProjectName%.binlog
set PackBuildProps=/p:Configuration=Release /p:Platform="Any CPU" /p:DebugType=Embedded -bl:%BuildLogs%\z0.pack.binlog
set SlnBuildProps=/p:Configuration=Release /p:DebugType=Embedded -bl:%BuildLogs%\z0.solution.binlog
set BuildToolOptions=-m:24
set BuildTool=dotnet build %BuildToolOptions%
set ProjectRoot=%SlnRoot%\src\%ProjectName%
set ProjectPath=%ProjectRoot%\z0.%ProjectName%.csproj
set ShellBuildCmd=%BuildTool% %ProjectPath% %ShellBuildProps%
set ProjectBuildCmd=%BuildTool% %ProjectPath% %ProjectBuildProps%
set BuildProject=%ProjectBuildCmd%
set BuildSlnCmd=%BuildTool% %SlnFilePath% %SlnBuildProps%
