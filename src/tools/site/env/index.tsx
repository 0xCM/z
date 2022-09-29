//import * as Llvm from "./llvm"
export type Tools = 'tools'
export function Tools() : Tools {
    return 'tools'
}
export type Env = 'env'

export type Sdks = 'sdks'
export function Sdks()  : Sdks {
    return 'sdks'
}

export type Dist = 'dist'
export function Dist() : Dist{
    return `dist`
}

export type Lang = 'b:/lang'
export function Lang() : Lang {
    return 'b:/lang'
}

export type DevRoot = 'd:/dev'
export function DevRoot() : DevRoot{
    return 'd:/dev'
}

export type EnvRoot = `d:/${Env}`
export function EnvRoot() : EnvRoot {
    return 'd:/env'
}

export type DevTools = `b:/${Tools}`
export function DevTools() : DevTools {
    return `b:/tools`
}

export type DevTool<T extends string> = `${DevTools}/${T}`
export function DevTool<T extends string>(tool:T) : DevTool<T> {
    return `${DevTools()}/${tool}`
}

export type SdkRoot = `${EnvRoot}/${Sdks}`
export function SdkRoot() : SdkRoot {
    return `${EnvRoot()}/sdks`
}

export type LlvmSdk = `${SdkRoot}/llvm/sdk`

export function LlvmSdk() : LlvmSdk  {
    return `${SdkRoot()}/llvm/sdk`
}

export type LlvmSdkPath<L extends string> = `${LlvmSdk}/${L}`

export function LlvmSdkPath<L extends string>(part:L) : LlvmSdkPath<L>{
    return `${SdkRoot()}/llvm/sdk/${part}`
}

export type DotNetSdk = `${SdkRoot}/dotnet`
export type DotNetRoot = `${DotNetSdk}/root`
export type DotNetTools = `${DotNetSdk}/${Tools}`

export function DotNetSdk() : DotNetSdk {
    return `${SdkRoot()}/dotnet`
}

export function DotNetRoot() : DotNetRoot {
    return `${DotNetSdk()}/root`
}

export function DotNetTools() : DotNetTools {
    return `${DotNetSdk()}/${Tools()}`
}

export type Linguist = `${Lang}/linguist`
export type LinguistDist =`${Linguist}/${Dist}`
export type LinguistGrammars = `${LinguistDist}/grammars`

export function Linguist() : Linguist {
    return `${Lang()}/linguist`
}

export function LinguistDist() : LinguistDist {
    return `${Linguist()}/dist`
}

export function LinguistGrammars() : LinguistGrammars {
    return `${LinguistDist()}/grammars`
}
