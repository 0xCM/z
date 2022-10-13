echo off
set ToolId=nuget
set ToolCmd=nuget.exe
set ToolCmdRoot=%ZControl%\tools\%ToolId%
set CmdDstPath=%ToolCmdRoot%\nuget.list
set ConfigPath=%ToolCmdRoot%\nuget.config
%ToolCmd% list runtime.win-x64 -ConfigFile %ConfigPath% -PreRelease -Verbosity detailed > %CmdDstPath%