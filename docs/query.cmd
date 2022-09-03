 @echo off
 set LlvmWs=E:/mounts/E2/repos/llvm
 set LlvmRepo=%LlvmWs%/llvm-project
 set LLvmBuild=%LlvmWs%/build
 set CompileCommands=%LlvmWs%/build/compile_commands.json
 : V:\repos\llvm\llvm-project\llvm\include\llvm\MC\MCInst.h
 set SrcPath=%LlvmRepo%/llvm/include/llvm/MC/MCInst.h
 set LlvmBin=%LLvmBuild%/bin
 set clang-query=%LlvmBin%/clang-query.exe
 set CmdSpec=%clang-query% -p=%CompileCommands% %SrcPath%
call %CmdSpec%

: match functionDecl()
: match enumDecl()