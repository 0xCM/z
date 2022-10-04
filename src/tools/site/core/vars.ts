export type Var<N,V> = {
    name:N
}

export interface Bound<S,T> {
    src:S
    dst:T
}

export interface BoundVar<E,N,V> {
    env:E
    name:N
    value:V
}

export interface VarBinder<E,N,V>  {
    bind:(env:E,name:N,value:V) => BoundVar<E,N,V>
}

export function bind<E,N,V>(env:E,name:N,value:V) : BoundVar<E,N,V> {
    return {
        env,
        name,
        value
    }
}


export function Var<N,V=null>(name:N) : Var<N,V> {
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
