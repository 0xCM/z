export type Const<T> = T

export type Null<T=null> = Const<null>

export type EmptyString = Const<''>

export type List<T> = Array<T>

export type Mapper<S,T> = (src:S) => T;

export interface Named<N> {
    name:N
}

export interface Provider<C,P> {
    provide<C,P>(context:C): P
}

