//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Tools;

    [Cmd(ToolNames.llc), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct LlcCmd : IToolFlowCmd<LlcCmd,Llc>
    {
        [CmdArg("<src>")]
        public FilePath Source;

        [CmdArg("-o {0}")]
        public FilePath Target;

        [CmdArg("--filetype={0}")]
        public string FileType;

        [CmdArg("--target-abi={0}")]
        public string TargetAbi;

        [CmdArg("--mtriple={0}")]
        public string Triple;

        [CmdArg("--x86-asm-syntax={0}")]
        public string X86AsmSyntax;

        [CmdFlag("--verify-machineinstrs")]
        public bit VerifyMachineInstructions;

        [CmdFlag("--asm-verbose")]
        public bit AsmVerbose;

        [CmdArg("{0}")]
        public string OptimizationLevel;

        [CmdFlag("--incremental-linker-compatible")]
        public bit IncrementalLinkerCompatible;

        [CmdArg("--mattr={0}")]
        public string Mattr;

        public Llc Tool
            => Tools.llc;

        FilePath IFlowCmd<FilePath, FilePath>.Source
            => Source;

        FilePath IFlowCmd<FilePath, FilePath>.Target
            => Target;
    }
}