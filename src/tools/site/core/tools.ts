import { ExecutorName,Cmd } from "./cmd"
import { Literal } from "./literals"

export type Actor<N extends Literal> = {
    name:N
}

export function actor<T extends Literal>(name:T) : Actor<T> {
    return {
        name
    }
}

export type ToolInfo = {
    name:string
    root:string
    exec:string
}

export type ToolInfos = Array<ToolInfo>

export type ToolId<T> = {
    tool:T
}

export type ToolDef<T,R,E> = {
    name:T
    root:R
    exec:E
}

export function toolpath<T,R,H extends ExecutorName>(src:ToolDef<T,R,H>) : string{
    return `${src.root}/${src.name}.${src.exec}`
}

export function toolspec<T,R,E>(src:ToolDef<T,R,E>) : ToolInfo {
    return {
        name:`${src.name}`,
        root:`${src.root}`,
        exec:`${src.exec}`
    }
}

export function tooldef<T,R,E>(name:T, root:R, exec:E) : ToolDef<T,R,E> {
    return {
        name,
        root,
        exec
    }
}

export interface ToolConfig<T,G,D,P> {
    tool:T
    group:G,
    dist:D,
    path:P
}

export type ToolName<N> = {
    ToolName:N
}

export type Tools<N> = Array<ToolId<N>>


export type HelpDoc<T extends Literal,C>  = {
    tool:Actor<T>,
    content:C
}


export function help<T extends Literal,C>(tool:Actor<T>,content:C) : HelpDoc<T,C> {
    return {
        tool,
        content
    }
  }

export type ToolHelpCmd<T,A0=null, A1=null, A2=null> = {
    tool:T
    args:[a0?:A0, a1?:A1, a2?:A2]
}


export type ToolHelp<T extends Literal,C> = {
    tool:Actor<T>
    docs:Array<HelpDoc<T,C>>
}

export interface ToolCmd<T extends Literal,C extends Literal> extends Cmd<C> {

}

export type CmdFlag<F> = {
    name:F
    enabled:boolean
}


function cmd0<T>(tool:T) {
    return `${tool}`
}

function cmd1<T,A>(tool:T, a:A) {
    return `${cmd0(tool)} ${a}`
}

function cmd2<T,A,B>(tool:T, a:A, b:B) {
    return `${cmd1(tool,a)} ${b}`
}

function cmd3<T,A,B,C>(tool:T, a:A, b:B, c:C) {
    return `${cmd2(tool,a,b)} ${c}`
}   

export const ToolCmd = {
    c0:cmd0,
    c1:cmd1,
    c2:cmd2,
    c3:cmd3
}

export interface ToolExe<R,T> {
    root:R
    tool:T
}
