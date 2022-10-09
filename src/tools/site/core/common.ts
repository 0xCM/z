export * from "./cmd"
export * from "./digital"
export * from "./expr"
export * from "./fs"
export * as FS from "./fs"
export * from "./nats"
export * from "./symbols"
export * from "./uri"
export * from "./common"
export * from "./tools"
export * as Tk from "./tokens"
export * as Wf from "./wf"
export * from "./literals"
export * from "./vars"
export * from "./context"
export * from "./lookup"
export * from "./names"
export * from "./kinds"
export * from "./values"
export * from "./kinds"
export * from "./locations"
export * from "./services"
export * as Grammar from "./grammar"

export type Const<T> = T

export type Null<T=null> = Const<null>

export type EmptyString = Const<''>


export interface Node<N> {
    
}

export interface Action<K,A> extends Node<A>{
}

export type Mapper<S,T> = (src:S) => T;
