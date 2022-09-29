export * from "./clang"
export * from "./cabal"
export * as DumpBin from "./dumpbin"
export * as SymStore from "./symstore"
export * as SymCheck from "./symcheck"
export * as GhcUp from "./ghcup"
export * as Llvm from "./llvm"
export * from "./git"
export * as Nuget from "./nuget"

import {Git} from "./git"

export function main() {
    console.log(JSON.stringify(Git.SubModule.syntax(), null, ' '))
}

main()