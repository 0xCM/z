export * from "./clang"
export * as Env from "./env"
export * from "./cabal"
export * as DumpBin from "./dumpbin"
export * as SymStore from "./symstore"
export * as SymCheck from "./symcheck"
export * as GhcUp from "./ghcup"
export * as Llvm from "./llvm"
export * from "./git"
export * as Nuget from "./nuget"
export * from "./core"
export * as RoboCopy from "./robocopy"

import {Git} from "./git"

import * as Env from "./env"
import { copy } from "./robocopy"
import {FS} from "./core"
import {Tk} from "./core"

export function main() {
    
    const _Src = FS.path('<Src>')
    const _Dst = FS.path('<Dst>')
    const _Script = copy('<name>', _Src, _Dst, Tk.BackSlash())
    console.log(_Script)
    //console.log(copy('name', F))
    //console.log(RoboCopy.)
    //console.log(Env.ZuluJdkBin())
    //console.log(LlvmSdk().LlvmSdk.path('index.ts'))
    //console.log(JSON.stringify(Git.SubModule.syntax(), null, ' '))
}

main()