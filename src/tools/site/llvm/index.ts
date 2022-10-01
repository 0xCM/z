
export * as CpuRunner from "./cpu-runner"
export * as ApiNotes from "./api-notes"
export * as Opt from "./opt"
import {ToolExe} from "../core"
import {ToolHelpCmd} from "../core"

export type LLvmHelp<T,A0=null,A1=null> = ToolHelpCmd<T,'--help',A0,A1>
export type LLvmHelpHidden<T,A0=null,A1=null> = ToolHelpCmd<T,'--help-hidden',A0,A1>
export type Pdll<R> = ToolExe<R,'mlir-pdll'>
export type MlirLspServer<R> = ToolExe<R,'mlir-lsp-server'>
export type MlirCpuRunner<R> = ToolExe<R, 'mlir-cpu-runner'>
export type Tools<R> = {
    lspServer:MlirLspServer<R>
    cpuRunner:MlirCpuRunner<R>
    pdll:Pdll<R>
}

console.log("Hello")