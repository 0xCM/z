export * as Llvm from "./llvm"

import * as Llvm from "./llvm"

const Env = {
    LlvmSdk:Llvm.Sdk
}

export function env() {
    return Env
}