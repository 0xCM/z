export {}

export type ToolName = "dotnet-symbol"

export type CmdFlag =
    "--diagnostics"
    | "--debugging"
    | "--modules"
    | "--symbols"
    | "--recurse-subdirectories"



// @echo off
// set DstDir=%~dp0context\symbols
// mkdir %DstDir% 1>nul 2>nul

// set SrcFiles=%~dp0context\bin\*.dll
// set CmdOptions=--output %DstDir%
// set CmdArgs=--diagnostics --debugging --modules --symbols --recurse-subdirectories --output %DstDir% %SrcFiles%

// set CmdSpec=dotnet-symbol %CmdArgs%
// echo CmdSpec:%CmdSpec%

// %CmdSpec%
