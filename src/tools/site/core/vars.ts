import {Literal} from "./literals"
export type Var<N> = {
    name:N
}

export interface Bound<S,T> {
    src:S
    dst:T
}

export interface BoundVar<E extends Literal,N extends Literal,V> {
    env:E
    name:N
    value:V
}

export interface VarBinder<E extends Literal,N extends Literal,V>  {
    bind:(env:E,name:N,value:V) => BoundVar<E,N,V>
}

export function bind<E extends Literal,N extends Literal,V>(env:E,name:N,value:V) : BoundVar<E,N,V> {
    return {
        env,
        name,
        value
    }
}

export function Var<N>(name:N) : Var<N> {
    return {
        name,     
    }
}

export interface Reify<S,T,R> {
    reify(bound:Bound<S,T>):R
}

export interface Bind<S,T> {
    bind(src:S,dst:T) : Bound<S,T>
}
