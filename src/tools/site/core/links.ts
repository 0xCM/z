import { EmptyString} from "./common"
import {Kinded} from "./kinds"

export interface Node<N> {
    name:N   
}

export interface Action<K,A> extends Node<A>{
}

export interface Flow<S,T> {
    source:S
    target:T
}

export interface Edge<K,S,T> extends Kinded<K>, Flow<S,T>{
}

export type Link<K,N> = Edge<K,N,N>

export function link<K,F>(kind:K, source:F, target:F) : Link<K,F> {
    return {
        kind,
        source,
        target
    }
}


export function edge<K,S,T>(kind:K, source:S, target:T) : Edge<K,S,T> {
    return {
        kind,
        source,
        target
    }
}

export type Path<A,B=null,C=null,D=null,E=null,F=null,G=null,H=null> = {
    a:A
    b?:B
    c?:C
    d?:D
    e?:E
    f?:F
    g?:G
    h?:H
}

export function path<A, B=null, C=null, D=null, E=null, F=null, G=null, H=null> (
    a:A, b?:B, c?:C, d?:D, e?:E, f?:F, g?:G, h?:H) : Path<A,B,C,D,E,F,G,H> {    
        return {
            a:a,
            b:b,
            c:c,
            d:d,
            e:e,
            f:f,
            g:g,
            h:h
        }
}

export function format<A,B,C,D,E,F,G,H>(sep:string, src:Path<A,B,C,D,E,F,G,H>) {
    const empty:EmptyString = ''
    return `${src.a}` 
        + (src.b == undefined ? empty : sep + src.b)
        + (src.c == undefined ? empty : sep + src.c)
        + (src.d == undefined ? empty : sep + src.d)
        + (src.e == undefined ? empty : sep + src.e)
        + (src.f == undefined ? empty : sep + src.f)
        + (src.g == undefined ? empty : sep + src.g)
        + (src.h == undefined ? empty : sep + src.h)
}
