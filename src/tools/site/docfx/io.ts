import {Folder,FS,Literal} from "../core"

export type OutKind = | 'site' | 'view' | 'raw' | 'debug' | 'log' | 'obj'

export type Output<R extends Literal,P> = {
    root:Folder<R>
    project:P
    kind:OutKind
}

export type Input<R extends Literal,P> = {
    root:Folder<R>
    project:P
    def:File
}

export function input<R extends Literal,P>(root:Folder<R>,  project:P, def:File) : Input<R,P> {
    return {
        root,
        project,
        def
    }
}

export function output<R extends Literal,P>(root:Folder<R>, project:P, kind:OutKind) : Output<R,P> {
    return {
        root,
        project,
        kind
    }
}

export function outdir<R extends Literal,P>(src:Output<R,P>){
    return FS.folder(`${src.root}/${src.project}/${src.kind}`)
}

export function outfile<R extends Literal,P>(src:Output<R,P>){
    return FS.file(`${src.root}/${src.project}/${src.project}.${src.kind}`)    
}
