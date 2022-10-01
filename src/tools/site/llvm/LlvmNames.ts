
export type LlvmGroup = | '' | 'clang' | 'mlir' | 'lldb' | 'llvm'

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
    | 'mlir-cpu-runner'
    | 'mlir-lsp-server'
    | 'mlir-pdll'
    | 'mlir-opt'
    | ''


export type LlvmTest =
    | 'apinotes-test'
    | 'c-arcmt-test'
    | 'c-index-test'
    | 'clang-import-test'
