set Area=src
set ProjectId=lib
call %~dp0..\config.cmd
set AddProject=%SlnScripts%\sln-add.cmd

set ProjectId=literals
call %AddProject%

set ProjectId=interop
call %AddProject%

set ProjectId=sys
call %AddProject%

set ProjectId=clr.msil
call %AddProject%

set ProjectId=clr.models
call %AddProject%

set ProjectId=clr.query
call %AddProject%

set ProjectId=text
call %AddProject%

set ProjectId=bit
call %AddProject%

set ProjectId=imagine
call %AddProject%

set ProjectId=lib
call %AddProject%

