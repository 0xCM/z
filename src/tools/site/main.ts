import {copy } from "./robocopy"
import {FS} from "./core"
import {Tk} from "./core"
import { DocFx,Pack } from "."
import * as Env from "./env"

export function main() {    
    const _Src = FS.path('<Src>')
    const _Dst = FS.path('<Dst>')
    const _Script = copy('<name>', _Src, _Dst, Tk.BackSlash())    
    const _Pack = Pack.add('d:/isolate','d:/isolate.z7')
    const _DocFx = DocFx.build('docfx',`${Env.DocSources()}/microsoft/visualstudio-docs/docs`, `${Env.DocTargets()}/visualstudio-docs`)    
    console.log(_Pack)
}

/*
docfx build b:/docs/microsoft/visualstudio-docs/docs/docfx.json --cleanupCacheHistory --loglevel Verbose --output f:/build/docs/visualstudio-docs/docs/docs/site --debug --debugOutput f:/build/docs/visualstudio-docs/docs/docs/debug --exportRawModel --rawModelOutputFolder f:/build/docs/visualstudio-docs/docs/docs/raw --exportViewModel --viewModelOutputFolder f:/build/docs/visualstudio-docs/docs/docs/view --intermediateFolder f:/build/docs/visualstudio-docs/docs/docs/obj
*/