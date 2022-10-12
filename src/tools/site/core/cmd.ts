import {UriScheme} from "./uri"
import {Literal,Strings} from "./literals"
import {Edge} from "./links"
import { Named } from "./common"

export type CmdName<N extends Literal> = N

export type CmdList = {
    commands:Strings
}

export function cmdname<N extends Literal>(name:N) : CmdName<N> {
    return name;
}
export interface CmdOption<N,V=null>{
    name:N
    value?:V
}

export interface Cmd<N> extends Named<N> {
    
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

export interface CmdSet<P,N> {
    readonly name: P;
    Commands: Array<Cmd<N>>;
};

export interface CmdDef<K extends Literal,N extends Literal,S,T,O= null> extends Edge<K,S,T>, Named<N> {
    options?:O
}

export declare function DefineCmd<K extends Literal,N extends Literal,S,T,O>(kind:K, name:N, source:S, target:T, options?:O) : CmdDef<K,N,S,T,O>

function define<K extends Literal,N extends Literal,S,T,O>(kind:K, name:N, source:S, target:T, options?:O) : CmdDef<K,N,S,T,O> {
    return {
        kind,
        name,
        source,
        target,
        options
    }
}

export const CmdFactory = {
    define:define
}

//export interface CmdFactory<K extends Literal,S,T,O> {

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

export function cmd<N>(name: N) : Cmd<N>
{
    return {
        name: name
    }
}

export declare function commands<N>(names: Array<N>): Array<Cmd<N>>;

export declare function provider<P,T>(name: P, names: Array<Cmd<T>>): CmdSet<P,T>;

export function option<N,V>(name:N, value?:V) {
    return {
        name,
        value
    }
}
