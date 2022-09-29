export type SdkRoot = 'file://d:/env/sdks/llvm/sdk'
export type SdkPath<L extends string> = `${SdkRoot}/${L}`
function sdkpath<L extends string>(part:L) : SdkPath<L>{
    return `file://d:/env/sdks/llvm/sdk/${part}`
}

export const Sdk = {
    root:'file://d:/env/sdks/llvm/sdk',
    path:sdkpath
}