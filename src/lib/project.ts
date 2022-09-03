export type CSharp = 'csharp'
export type CsProj = 'csproj'

export const csproj:CsProj = 'csproj'

export type ProjectKind =
    | CsProj

export type ProjectFile<P,N,K> = {
    prefix:P
    name:N
    kind:K
}

export type ProjectFiles<P,N,K> = Array<ProjectFile<P,N,K>>


export function file<P,N,K>(prefix:P, name:N, kind:K) : ProjectFile<P,N,K> {
    return {
        prefix,
        name,
        kind
    }
}

export function filename<P,N,K>(src:ProjectFile<P,N,K>) {
    return `${src.prefix}.${src.name}.${src.kind}`
}

export function filenames<P,N,K>(src:ProjectFiles<P,N,K>) {
    return src.map(filename);
}

export type BuildPrefix = 'z0'
export type Literals = `literals`
export type Interop = `interop`
export type Sys = `sys`
export type ClrMsil = `clr.msil`
export type Bit = `bit`
export type Text = `text`
export type Imagine = `imagine`
export type ClrModels = `clr.models`
export type ClrQuery = `clr.query`
export type Lib = 'lib'

export type ProjectName =
    | Literals
    | Interop
    | Sys
    | ClrMsil
    | Bit
    | Text
    | Imagine
    | ClrModels
    | ClrQuery

export type ProjectRefs = ProjectFiles<BuildPrefix,ProjectName,ProjectKind>

export type ProjectDeps = {
    refs:ProjectRefs
}

export type Project = {
    name:Lib
    deps:ProjectDeps
    files:string[]
}


const literals:Literals = `literals`
const interop:Interop = `interop`
const msil:ClrMsil=`clr.msil`
const sys:Sys = `sys`
const bit:Bit = `bit`
const text:Text = 'text'
const imagine:Imagine = 'imagine'
const clrmodels:ClrModels = 'clr.models'
const clrquery:ClrQuery = 'clr.query'
const lib:Lib = 'lib'
const prefix:BuildPrefix = 'z0'

const refs:ProjectRefs = [
    file(prefix, literals, csproj),
    file(prefix, interop, csproj),
    file(prefix, msil, csproj),
    file(prefix, sys, csproj),
    file(prefix, bit, csproj),
    file(prefix, text, csproj),
    file(prefix, imagine, csproj),
    file(prefix, clrmodels, csproj),
    file(prefix, clrquery, csproj),
]

const deps:ProjectDeps = {
    refs:refs
}

export const project:Project = {
    name:lib,
    deps:deps,
    files:filenames(refs)
    
}

export function emit(){
    console.log(JSON.stringify(project,null, ' '))
}

emit()

