call %~dp0..\config.cmd

set Deployments=%EnvB%\tools\z0\bin
set RetractCmd=rmdir %Deployments% /s/q
call %RetractCmd%

set CopySymbols=copy %ProjectRuntime%\*.pdb %ProjectPdb%\ /Y
set PublishSymbols=robocopy %ProjectPdb% %Deployments%
call %~dp0env.cmd

@REM call %RetractCmd%
@REM if errorlevel 1 goto:eof

@REM call %PublishCmd%
@REM if errorlevel 1 goto:eof

@REM call %CopySymbols%
@REM if errorlevel 1 goto:eof

@REM call %PublishSymbols%
@REM if errorlevel 1 goto:eof
