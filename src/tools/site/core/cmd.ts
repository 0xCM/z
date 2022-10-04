import {UriScheme} from "./uri"
import {Named,Valued} from "./common"

export interface CmdOption<N,V> extends Named<N>, Valued<V>{
    
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


export interface CmdSet<P,N> extends Named<P> {
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


// export type sdm = "sdm";
// export type xed = "xed";
// export type llvm = "llvm";
// export declare const SdmCmd: CmdSet<sdm,string>;
// export declare const XedCmd: CmdSet<xed,string>;
// export declare const LlvmCmd: CmdSet<llvm,string>;
// export declare const Commands: {
//     Sdm: CmdSet<"sdm", string>;
//     Xed: CmdSet<"xed", string>;
//     Llvm: CmdSet<"llvm", string>;
// };


// export type CmdSpecs<K,C> = Array<CmdSpec<K,C>>


// export interface CmdActionSpec<F,N> {
//     Flag:F
//     Name:N
//     Intent?:string
// }
