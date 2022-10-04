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

// export type BuildPrefix = 'z0'
// export type Literals = `literals`
// export type Interop = `interop`
// export type Sys = `sys`
// export type ClrMsil = `clr.msil`
// export type Bit = `bit`
// export type Text = `text`
// export type Imagine = `imagine`
// export type ClrModels = `clr.models`
// export type ClrQuery = `clr.query`
// export type Lib = 'lib'

// export type ProjectName =
//     | Literals
//     | Interop
//     | Sys
//     | ClrMsil
//     | Bit
//     | Text
//     | Imagine
//     | ClrModels
//     | ClrQuery

//export type ProjectRefs = ProjectFiles<BuildPrefix,ProjectName,ProjectKind>

// export type ProjectDeps = {
//     refs:ProjectRefs
// }

// export type Project = {
//     name:Lib
//     deps:ProjectDeps
//     files:string[]
// }


// const literals:Literals = `literals`
// const interop:Interop = `interop`
// const msil:ClrMsil=`clr.msil`
// const sys:Sys = `sys`
// const bit:Bit = `bit`
// const text:Text = 'text'
// const imagine:Imagine = 'imagine'
// const clrmodels:ClrModels = 'clr.models'
// const clrquery:ClrQuery = 'clr.query'
// const lib:Lib = 'lib'
// const prefix:BuildPrefix = 'z0'

// const refs:ProjectRefs = [
//     file(prefix, literals, T.CsProj()),
//     file(prefix, interop, T.CsProj()),
//     file(prefix, msil, T.CsProj()),
//     file(prefix, sys, T.CsProj()),
//     file(prefix, bit, T.CsProj()),
//     file(prefix, text, T.CsProj()),
//     file(prefix, imagine, T.CsProj()),
//     file(prefix, clrmodels, T.CsProj()),
//     file(prefix, clrquery, T.CsProj()),
// ]

// const deps:ProjectDeps = {
//     refs:refs
// }

// export const project:Project = {
//     name:lib,
//     deps:deps,
//     files:filenames(refs)
    
// }

// export function emit(){
//     console.log(JSON.stringify(project,null, ' '))
// }

// emit()

