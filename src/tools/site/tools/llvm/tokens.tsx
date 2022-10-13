export type Clang = 'clang'
export function Clang() : Clang {
    return 'clang'
}

export type MlirCpuRunner = 'mlir-cpu-runner'
export function MlirCpuRunner() : MlirCpuRunner {
    return 'mlir-cpu-runner'
}

export type LlvmTool =
    | 'bugpoint'
    | 'clang-apply-replacements'
    | 'clang-ast-dump'
    | 'clang-check'
    | 'clang-cl'
    | 'clang-cpp'
    | 'clang-diff'
    | 'clang-doc'
    | 'clang-extdef-mapping'
    | 'clang-format'
    | 'clang-fuzzer-dictionary'
    | MlirCpuRunner
    | 'mlir-lsp-server'
    | 'mlir-pdll'
    | 'mlir-opt'
    | ''


export type LlvmTest =
    | 'apinotes-test'
    | 'c-arcmt-test'
    | 'c-index-test'
    | 'clang-import-test'

export type LlvmGroup = | '' | 'clang' | 'mlir' | 'lldb' | 'llvm'
