@echo off
call %~dp0..\config.cmd
set Packed=%DevPacks%\zpack\packed
set Unpacked=%DevPacks%\zpack\unpacked
set Stage=%DevPacks%\zpack\stage
set PackSln=dotnet pack %SlnFilePath% --output %Stage% %BuildProps% -p:DebugType=embedded
set UnpackCmd=nuget init %Stage% %Unpacked%
mkdir %Stage% 1>nul 2>nul
call %PackSln%
if errorlevel 1 goto:eof
call %UnpackCmd%
if errorlevel 1 goto:eof
robocopy %Stage% %Packed% /e 1>nul
rm %Stage% -rf
mkdir %Stage%
