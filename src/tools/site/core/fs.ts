import { EmptyString, Null } from "./common"
import {uint32} from "./integers"
import {ForwardSlash,BackSlash} from "./tokens"
import {Upper,Colon} from "./utf7"

export type PathSep = EmptyString | BackSlash | ForwardSlash

export function sep(kind:PathSep) {
    var sep :PathSep = ''
    switch(kind)
    {
        case '/':
            sep = '/'
        break;
        case '\\':
            sep = '\\'
        break;
    }
    return `${sep}`
}

export type Drive<D extends Upper> = `${D}${Colon}`

export type _Drive = 
    | ''
    | `A:` 
    | 'B:' 
    | 'C:' 
    | 'D:' 
    | 'E:' 
    | 'F:' 
    | 'G:' 
    | 'H:' 
    | 'I:' 
    | 'J:' 
    | 'K:' 
    | 'L:' 
    | 'M:' 
    | 'N:' 
    | 'N:' 
    | 'O:'
    | 'P:'
    | 'Q:'
    | 'R:'
    | 'S:'
    | 'T:'
    | 'U:' 
    | 'V:' 
    | 'W:'
    | 'X:'
    | 'Y:'
    | 'Z:'
    
export type Volume<V> = V

export type Mount<P,R> = {
        protocol:P
        root:R
    }
    
export type WslMount<M> = Mount<`\\\\wsl$`,M>

export type NtfsMount<P extends _Drive,R> = Mount<P,R>

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

export type File<F> = F

export type Edge<K,S,T> = {
    kind:K
    source:S
    target:T
}

export type Link<L,F> = Edge<L,F,F>

export type FileLink<K,F> = Link<K,File<F>>


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
export function file<F>(file:F) : File<F> {
    return file
}

export type Folder<P> = P

export function folder<P>(src:P) : Folder<P> {
    return src
}

export type Archive<K,R> = {
    kind:K
    root:R
}

export type ArchiveKind = 
    | 'git'
    | 'zip'
    | 'fs'
    | 'tar'

export type FileArchive<R> = Archive<0,R>


export type LineSpan<S,T> ={
    source:S
    min:uint32<T>
    max:uint32<T>
}

export function lines<S,T>(source:S, min:uint32<T>, max:uint32<T>) : LineSpan<S,T> {
    return {
        source,
        min,
        max
    }
}