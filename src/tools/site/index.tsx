export * from "./git"
export * from "./core"
export * from "./winsdk"
export * from "./msvc"
export * from "./clang"
export * as Pkg from "./pkg"
export * from "./cabal"
export * from "./os"
export * as DumpBin from "./dumpbin"
export * as SymStore from "./symstore"
export * as SymCheck from "./symcheck"
export * as GhcUp from "./ghcup"
export * as Llvm from "./llvm"
export * as Nuget from "./nuget"
export * as RoboCopy from "./robocopy"
export * as Pip from "./pip"
export * as SymLink from "./mklink"
export * as Python from "./python"
export * as DocFx from "./docfx"

import {main} from "./main"

main()