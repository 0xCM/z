import {SdkRoot} from "./root"

export type LlvmSdk = `${SdkRoot}/llvm/sdk`

export function LlvmSdk() : LlvmSdk  {
    return `${SdkRoot()}/llvm/sdk`
}

export type LlvmSdkPath<L extends string> = `${LlvmSdk}/${L}`

export function LlvmSdkPath<L extends string>(part:L) : LlvmSdkPath<L>{
    return `${SdkRoot()}/llvm/sdk/${part}`
}
