
export * from "./literals"

export type List<T> = Array<T>

export type Mapper<S,T> = (src:S) => T;

export interface Provider<C,P> {
    provide<C,P>(context:C): P
}

