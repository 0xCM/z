export interface Bound<S,T> {
    src:S
    dst:T
}

export interface Bind<S,T> {
    bind(src:S,dst:T) : Bound<S,T>
}

export interface Reify<S,T,R> {
    reify(bound:Bound<S,T>):R
}