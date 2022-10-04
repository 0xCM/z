export type EmptyType<T=null> = T
export type TheEmpty<T> = T
export type EmptyString = EmptyType<''>


export interface Named<N> {
    name:N
}

export interface Valued<V> {
    value:V
}

export interface Kinded<K> {
    kind:K
}

export interface Node<N> extends Named<N> {
    
}


export interface Action<K,A> extends Node<A>, Kinded<K> {
}
