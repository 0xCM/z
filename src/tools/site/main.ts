import {copy } from "./robocopy"
import {FS} from "./core"
import {Tk} from "./core"
import { DocFx,Nuget } from "."
import * as Env from "./pkg"

export function main() {    
    const _Src = FS.path('<Src>')
    const _Dst = FS.path('<Dst>')
    const Copy = copy('<name>', _Src, _Dst, Tk.BackSlash())    
    const DocFxBuild = DocFx.build('docfx',`${Env.DocSources()}/microsoft/visualstudio-docs/docs`, `${Env.DocTargets()}/visualstudio-docs`)
    const NugetInit = Nuget.init('V:/dist/intel/nuget', 'V:/pkg/nuget') 
    
    console.log(NugetInit)
}
