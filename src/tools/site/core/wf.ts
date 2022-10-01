export interface Arrow<S,T> {
    source:S
    target:T
}

export function arrow<S,T>(src:S, dst:T) : Arrow<S,T>
{
    return {
        source:src,
        target:dst
    }
}

export function format<S,T>(arrow:Arrow<S,T>){
    return `${arrow.source} -> ${arrow.target}`
}

export interface Flow<S,T> {
    Source:S
    Target:T
}

export interface Workflow<R,S,T> extends Flow<S,T> {
    run:R
}

export type Definition<T> = {
    term: T;
    meaning: string;
};

export function define<T>(term:T, meaning:string) : Definition<T> {
    return {
        term:term,
        meaning:meaning
    }
}

export type FunctionType<A> ={
    arity:A
}

export type Op<A,S> ={
    arity:A
    sig:S
}

export type Emitter<F> = {
    emit:F
}


export interface ISink<K,T> {
    kind:K

}

export interface ISource<K,T> {
    kind:K
    
}