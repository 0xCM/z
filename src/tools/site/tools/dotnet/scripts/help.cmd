@echo off
call %~dp0..\config.cmd
set EmitHelp=%Toolsets%\emit-help-1.cmd

: set EmitHelp=%Toolbase%\emit-help2.cmd
set HelpKind=new.help
set HelpOptions=new --help
call %EmitHelp%

set HelpKind=new.list
set HelpOptions=new --list
call %EmitHelp%

set HelpKind=build-server
set HelpOptions=build-server --help
call %EmitHelp%

set HelpKind=build
set HelpOptions=build --help
call %EmitHelp%

set HelpKind=clean
set HelpOptions=clean --help
call %EmitHelp%

set HelpKind=list
set HelpOptions=list --help
call %EmitHelp%

set HelpKind=msbuild
set HelpOptions=msbuild --help
call %EmitHelp%

set HelpKind=nuget
set HelpOptions=nuget --help
call %EmitHelp%

set HelpKind=pack
set HelpOptions=pack --help
call %EmitHelp%

set HelpKind=publish
set HelpOptions=publish --help
call %EmitHelp%

set HelpKind=remove
set HelpOptions=remove --help
call %EmitHelp%

set HelpKind=restore
set HelpOptions=restore --help
call %EmitHelp%

set HelpKind=run
set HelpOptions=run --help
call %EmitHelp%

set HelpKind=sdk
set HelpOptions=sdk --help
call %EmitHelp%

set HelpKind=store
set HelpOptions=store --help
call %EmitHelp%

set HelpKind=test
set HelpOptions=test --help
call %EmitHelp%

set HelpKind=tool
set HelpOptions=tool --help
call %EmitHelp%

set HelpKind=tool.list
set HelpOptions=tool list
call %EmitHelp%

set HelpKind=vstest
set HelpOptions=vstest --help
call %EmitHelp%

set HelpKind=workload
set HelpOptions=workload --help
call %EmitHelp%

set HelpKind=sql-cache
set HelpOptions=sql-cache --help
call %EmitHelp%

set HelpKind=watch
set HelpOptions=watch --help
call %EmitHelp%

set HelpKind=tool.install
set HelpOptions=tool install --help
call %EmitHelp%

