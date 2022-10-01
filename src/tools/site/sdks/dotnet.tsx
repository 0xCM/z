import {SdkRoot} from "./root"
import {Tools} from "../core/tokens"

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
