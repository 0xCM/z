import {uint32} from "./integers"

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

