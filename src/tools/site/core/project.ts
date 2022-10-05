import {Root} from "./root"

import * as Tk from "./tokens"

export type ProjectKind =
    | Tk.CsProj

export type ProjectFile<K,N> = {
    kind:K
    name:N
}

export type ProjectRoot<B> = Root<'project',B>

export type ProjectFiles<N,K> = Array<ProjectFile<N,K>>

export function file<K,N>(kind:K, name:N) : ProjectFile<K,N> {
    return {
        kind,
        name,
    }
}

export function filename<N,K>(src:ProjectFile<N,K>) {
    return `${src.name}.${src.kind}`
}

export function filenames<N,K>(src:ProjectFiles<N,K>) {
    return src.map(filename);
}
