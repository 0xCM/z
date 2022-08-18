 @echo off
 set BuildCmd=-p=D:\repos\llvm\llvm-project\build\compile_commands.json
 set SrcPath=D:\repos\llvm\llvm-project\llvm\include\llvm\MC\MCDisassembler\MCSymbolizer.h
 set CmdSpec=clang-query %BuildCmd% %SrcPath%
 call %CmdSpec%
