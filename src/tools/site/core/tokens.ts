import * as Utf7 from "./utf7"

export type Verbose = 'verbose'
export function Verbose() : Verbose {
    return 'verbose'
}

export type Version = 'version'
export function Version() : Version {
    return 'version'
}

export type Bin = 'bin'
export function Bin() : Bin {
    return 'bin'
}

export type Csv = 'csv'
export function Csv() : Csv {
    return 'csv'
}

export type Cache = 'cache'
export function Cache() : Cache {
    return 'cache'
}

export type CSharp = 'csharp'
export function CSharp() : CSharp {
    return 'csharp'
}

export type CsProj = 'csproj'
export function CsProj() : CsProj {
    return 'csproj'
}

export type Data = 'data'
export function Data() : Data {
    return 'data'
}

export type Dist = 'dist'
export function Dist() : Dist{
    return `dist`
}

export type Env = 'env'
export function Env() : Env {
    return 'env'
}

export type Gz = 'gz'
export function Gz() : Gz {
    return 'gz'
}

export type Lang = 'lang'
export function Lang() : Lang{
    return `lang`
}

export type Nuget = 'nuget'
export function Nuget() : Nuget {
    return 'nuget'
}

export type Tools = 'tools'
export function Tools() : Tools {
    return 'tools'
}

export type Tar = 'tar'
export function Tar() : Tar {
    return 'tar'
}

export type Sdks = 'sdks'
export function Sdks()  : Sdks {
    return 'sdks'
}

export type Sdk = 'sdk'
export function Sdk()  : Sdk {
    return 'sdk'
}

export type Pkg = 'pkg'
export function Pkg() : Pkg {
    return 'pkg'
}

export type _7z = '7z'
export function _7z() : _7z {
    return '7z'
}

export type Zip = 'zip'
export function Zip() : Zip {
    return 'zip'
}

export type Include = 'include'
export function Include() : Include {
    return 'include'
}

export type Lib = 'lib'
export function Lib() : Lib {
    return 'lib'
}

export type BSlash = Utf7.BSlash
export function BSlash() : BSlash{
    return '\\'
}

export type FSlash = Utf7.FSlash

export function FSlash() : FSlash{
    return '/'
}

export type Repeat = '...'

export function Repeat() : Repeat {
    return '...'
}

export type Mime = 'mime'
export function Mime() : Mime {
    return 'mime'
}


export function token<K,V>(key:K,val:V) {
    return 
`
export type ${key} = '${val}'
export function ${key}() : ${key} {
    return '${val}'
}
`
}

export const TokenDefs = [

    token("Bin", "bin"),
    token("Cache", "cache"),
    token("CSharp", "csharp"),
    token("CsProj", "csproj"),
    token("Data", "data"),
    token("Dist", "dist"),
    token("Env", "env"),
    token("Gz", "gz"),
    token("Lang", "lang"),
    token("Zip", "zip"),
]
