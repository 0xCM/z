call %~dp0config.cmd

set ProjectId=lib
set WsId=lib
call %AddSln%

set ProjectId=api.contracts
call %AddSln%

set ProjectId=nats
call %AddSln%

set ProjectId=interop
call %AddSln%

set ProjectId=literals
call %AddSln%

set ProjectId=clr.query
call %AddSln%

set ProjectId=part
call %AddSln%

set ProjectId=monadic
call %AddSln%




