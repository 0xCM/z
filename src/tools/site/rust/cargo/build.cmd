@echo off
set SrcDir=J:\source\rust\ucd-generate
set DstDir=j:\ws\.out\rust\ucd-generator
set CmdSpec=cargo build --release --target-dir %DstDir%
cd /D %SrcDir%
%CmdSpec%