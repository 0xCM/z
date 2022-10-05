export type Const<T> = T

export type Null<T=null> = Const<null>

export type EmptyString = Const<''>


export interface Node<N> {
    
}

export interface Action<K,A> extends Node<A>{
}

export type Mapper<S,T> = (src:S) => T;
