export {}

export type ToolCmd<T> = {
    tool:T
    source:string
    target:string
    flags?:string
    options?:string
}

export namespace ToolCmd {

    export function cmd0<T>(tool:T) {
        return `${tool}`
    }

    export function cmd1<T,A>(tool:T, a:A) {
        return `${cmd0(tool)} ${a}`
    }

    export function cmd2<T,A,B>(tool:T, a:A, b:B) {
        return `${cmd1(tool,a)} ${b}`
    }

    export function cmd3<T,A,B,C>(tool:T, a:A, b:B, c:C) {
        return `${cmd2(tool,a,b)} ${c}`
    }   
}

export type ToolId = `robocopy`

export const Docs = 'https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/robocopy'

export function usage<T>(tool:T){
    return `${tool} <source> <target> [<file>[ ...]] [<options>]`
}

export function robocopy(src:string, dst:string, flags= "/e", options?:string) : ToolCmd<ToolId> {
    return {
        tool:'robocopy',
        source:src,
        target:dst,
        flags:flags,
        options:options
    }
}

export function render(cmd:ToolCmd<ToolId>){
    let base = `${cmd.tool} ${cmd.source} ${cmd.target}`
    var result = base;
    if(cmd.flags != null)
        result += ` ${cmd.flags}`
    
    if(cmd.options != null)
        result += ` ${cmd.options}`
    return result;
}

export function emit(cmd:ToolCmd<ToolId>){
    console.log(render(cmd));
}

const src='<source>'
const dst='<target>'
function main(){
    emit(robocopy(src,dst));
}


main()