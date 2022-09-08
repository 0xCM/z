//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[SymSource("parts")]
public enum PartId : byte
{
    None = 0,

    [Symbol("part")]
    Part,

    [Symbol("root")]
    Root,

    [Symbol("asm.operands")]
    AsmOperands,

    [Symbol("asm.svc")]
    AsmSvc,

    [Symbol("api.svc")]
    ApiSvc,

    [Symbol("process")]
    Process,

    [Symbol("asm.prototypes")]
    AsmPrototypes,

    [Symbol("hex")]
    Hex,

    [Symbol("asm.checks")]
    AsmChecks,

    [Symbol("asm")]
    Asm,

    [Symbol("asm.core")]
    AsmCore,

    [Symbol("blocks")]
    Blocks,

    [Symbol("asm.models")]
    AsmModels,

    [Symbol("agents")]
    Agents,

    [Symbol("symbols")]
    Symbols,

    [Symbol("cmd.models")]
    CmdModels,

    [Symbol("cmd.specs")]
    CmdSpecs,

    [Symbol("cmd.exec")]
    CmdExec,

    [Symbol("memory.checks")]
    MemoryChecks,

    [Symbol("cmd.svc")]
    CmdSvc,

    [Symbol("cmd.flows")]
    CmdFlows,

    [Symbol("cmd.checks")]
    CmdChecks,

    [Symbol("cmd.tools")]
    CmdTools,

    [Symbol("shell")]
    Shell,

    [Symbol("shell.cmd")]
    ShellCmd,

    [Symbol("files")]
    Files,

    [Symbol("validity")]
    Validity,

    [Symbol("polyrand")]
    Polyrand,

    [Symbol("test.checks")]
    Checks,

    [Symbol("machines.x86")]
    X86Machine,

    [Symbol("assets")]
    Assets,

    [Symbol("numbers")]
    Numbers,

    [Symbol("cli")]
    Cli,

    [Symbol("builds")]
    Builds,

    [Symbol("clr.checks")]
    ClrChecks,

    [Symbol("clr.query")]
    ClrQuery,

    [Symbol("clr.cil")]
    ClrCil,

    [Symbol("llvm.tools")]
    LlvmTools,

    [Symbol("llvm.models")]
    LlvmModels,

    [Symbol("llvm.svc")]
    LlvmSvc,

    [Symbol("llvm.checks")]
    LlvmChecks,

    [Symbol("coff")]
    Coff,
    
    [Symbol("calcs")]
    Calcs,

    [Symbol("circuits")]
    Circuits,

    [Symbol("zcmd")]
    ZCmd,

    [Symbol("tuples")]
    Tuples,

    [Symbol("text")]
    Text,

    [Symbol("dynamic")]
    Dynamic,

    [Symbol("tools")]
    Tools,

    [Symbol("ts")]
    Ts,

    [Symbol("tools.shell")]
    ToolShell,

    [Symbol("interop")]
    Interop,

    [Symbol("test.units")]
    TestUnits,

    [Symbol("bits")]
    Bits,

    [Symbol("deprecated")]
    Deprecated,

    [Symbol("nats")]
    Nats,

    [Symbol("libm")]
    LibM,

    [Symbol("libs")]
    Libs,

    [Symbol("glue")]
    Glue,

    [Symbol("mkl")]
    Mkl,

    [Symbol("lang")]
    Lang,


    [Symbol("dynamic.linq")]
    DynamicLinq,

    [Symbol("capture")]
    Capture,

    [Symbol("evaluate")]
    Evaluate,

    [Symbol("render")]
    Render,

    [Symbol("native")]
    Native,

    [Symbol("queues")]
    Queues,

    [Symbol("diagnosics")]
    Diagnostics,

    [Symbol("cpu")]
    Cpu,

    [Symbol("cpu.test")]
    CpuTest,

    [Symbol("archives.core")]
    Archives,

    [Symbol("memory")]
    Memory,

    [Symbol("memory.svc")]
    MemorySvc,

    [Symbol("memory.models")]
    MemoryModels,

    [Symbol("monadic")]
    Monadic,

    [Symbol("db")]
    Db,

    [Symbol("db.shell")]
    DbShell,

    [Symbol("db.sqlite")]
    DbSqlite,

    [Symbol("literals")]
    Literals,

    [Symbol("lib")]
    Lib,

    [Symbol("math")]
    Math,

    [Symbol("gmath")]
    Gmath,

    [Symbol("fsm")]
    Fsm,

    [Symbol("bit")]
    Bit,

    [Symbol("intel.svc")]
    IntelSvc,

    [Symbol("commands")]
    Commands,

    [Symbol("api.code")]
    ApiCode,

    [Symbol("api.md")]
    ApiMd,

    [Symbol("api.cmd")]
    ApiCmd,

    [Symbol("api.checks")]
    ApiChecks,

    [Symbol("api.contracts")]
    ApiContracts,

    [Symbol("api.identity")]
    ApiIdentity,

    [Symbol("alloc")]
    Alloc,

    [Symbol("rules")]
    Rules,

    [Symbol("containers")]
    Containers,

    [Symbol("containers.checks")]
    ContainerChecks,

    [Symbol("emath")]
    EMath,

    [Symbol("events")]
    Events,

    [Symbol("symbolics")]
    Symbolics,

    [Symbol("digital")]
    Digital,

    [Symbol("models")]
    Models,

    [Symbol("wf")]
    Wf,

    [Symbol("imagine")]
    Imagine,

    [Symbol("heaps")]
    Heaps,

    [Symbol("sys")]
    Sys,

    [Symbol("linq")]
    Linq,

    [Symbol("sos.cmd")]
    SosCmd,

    [Symbol("wf.shell")]
    WfShell,

    [Symbol("codegen.common")]
    CgCommon,

    [Symbol("codegen.intel")]
    CgIntel,

    [Symbol("codegen.llvm")]
    CgLlvm,

    [Symbol("cg.libs")]
    CgLibs,

    [Symbol("gen.shell")]
    CgShell,

    [Symbol("intel.shell")]
    IntelShell,

    [Symbol("xed.shell")]
    XedShell,

    [Symbol("cmd.shell")]
    CmdShell,

    [Symbol("codegen.test")]
    CgTest,

    [Symbol("calc.checks")]
    CalcChecks,

    [Symbol("test.runner")]
    TestRunner,

    [Symbol("machines")]
    Machines,

    [Symbol("llvm.tool")]
    LlvmTool,

    [Symbol("cmd")]
    Cmd,

    [Symbol("contral")]
    Control,

    [Symbol("machine")]
    Machine,

    [Symbol("workers")]
    Workers,

    [Symbol("lang.emit")]
    LangEmit,

    [Symbol("z")]
    Z, 
}