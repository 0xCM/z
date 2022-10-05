import {UriScheme} from "./uri"
import {Valued} from "./values"

export interface CmdOption<N,V> extends Valued<V>{
    
}

export interface Cmd<C>  {
    cmd:C
}

export interface CmdAlias<C,A> extends Cmd<C> {
    alias:A
}

export interface ToolExe<R,T> {
    root:R
    tool:T
}

export type CmdUri = {
    scheme:UriScheme<"cmd">
}

export type ToolGroupName =
    | "tools"
    | "system"

export type ApiGroupName =
    | "api"
    | "db"

export type GroupName =
    | ToolGroupName
    | ApiGroupName

export type Group<G> = {
    group:G
}


export type ExecutorName = | 'exe' | 'python' | 'cmd' | 'pwsh'

export type CmdOptionDef<N,K> = {
    name:N
    kind:K
}

export type CmdFlagDef<F> = {
    name:F
}

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


export interface CmdSet<P,N> {
    readonly name: P;
    Commands: Array<Cmd<N>>;
};


export function cmd<N>(name: N) : Cmd<N>
{
    return {
        cmd: name
    }
}

export declare function commands<N>(names: Array<N>): Array<Cmd<N>>;

export declare function provider<P,T>(name: P, names: Array<Cmd<T>>): CmdSet<P,T>;
