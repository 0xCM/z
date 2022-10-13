export * as Clang from "./clang"
export * as Cabal from "./cabal"
export * as DumpBin from "./dumpbin"
export * as DocFx from "./docfx"
export * as Git from "./git"
export * as GhcUp from "./ghcup"
export * as Llvm from "./llvm"
export * as Nuget from "./nuget"
export * as Pip from "./pip"
export * as Python from "./python"
export * as Pkg from "./pkg"
export * as Pwsh from "./pwsh"
export * as RoboCopy from "./robocopy"
export * as SymStore from "./symstore"
export * as SymCheck from "./symcheck"
export * as YarnV1 from "./yarn/v1"

import * as Clang from "./clang"
import * as Cabal from "./cabal"
import * as DumpBin from "./dumpbin"
import * as DocFx from "./docfx"
import * as Git from "./git"

export type ToolName =
    | Clang.Name
    | Cabal.Name
    | DumpBin.Name
    | DocFx.Name
    | Git.Name

export type Tool =
    | Clang.Tool
    | Cabal.Tool
    | DumpBin.Tool
    | DocFx.Tool
    | Git.Tool
