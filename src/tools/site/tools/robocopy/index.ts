import * as Core from "../imports"
import {PathSep} from "../imports"
import {Tk,Actor,FS, Literal} from "../imports"

export type Name = `robocopy`
export type Tool = Actor<Name>

export function tool(name:Name = 'robocopy') : Tool {
    return Core.actor(name)
}

// export function copy<S extends Literal,T extends Literal,N>(name:N, src:FS.Folder<S>, dst:FS.Folder<T>, sep:PathSep = Tk.BackSlash()) {
//     const _Sep = FS.sep(sep)
//     const _Src = FS.format(_Sep, src)
//     const _Dst = FS.format(_Sep, dst)
//     const _Script = `robocopy ${_Src}${_Sep}${name} ${_Dst}${_Sep}${name} /e`
//     return _Script
// }

const DocSource = 'https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/robocopy'

type ToolCmd<T> = {
    tool:T
    source:string
    target:string
    flags?:string
    options?:string
}


function usage<T>(tool:T){
    return `${tool} <source> <target> [<file>[ ...]] [<options>]`
}

export function robocopy(src:string, dst:string, flags= "/e", options?:string) : ToolCmd<Name> {
    return {
        tool:'robocopy',
        source:src,
        target:dst,
        flags:flags,
        options:options
    }
}

export function render(cmd:ToolCmd<Name>){
    let base = `${cmd.tool} ${cmd.source} ${cmd.target}`
    var result = base;
    if(cmd.flags != null)
        result += ` ${cmd.flags}`
    
    if(cmd.options != null)
        result += ` ${cmd.options}`
    return result;
}

export function emit(cmd:ToolCmd<Name>){
    console.log(render(cmd));
}

const src='<source>'
const dst='<target>'
export function script(){
    emit(robocopy(src,dst));
}


// export function copy(src:string,dst:string) {
//     return `robocopy D:\\VHD\\lang\\repos\\json I:\\lang\\repos\\json /e`
// }