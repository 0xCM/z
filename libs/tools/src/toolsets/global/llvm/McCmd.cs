//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Tools;

    partial class XTend
    {
        [MethodImpl(Inline)]
        public static McCmd Command(this LlvmMc tool, FilePath src, FilePath dst)
        {
            var cmd = new McCmd();
            cmd.Source = src;
            cmd.Target = dst;
            return cmd;
        }
    }

    [Cmd(ToolNames.llvm_mc), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct McCmd : IToolFlowCmd<McCmd,LlvmMc>
    {
        public McCmd()
        {

        }

        [CmdArg("<src>")]
        public FilePath Source = FilePath.Empty;

        [CmdArg("-o {0}")]
        public FilePath Target = FilePath.Empty;

        [CmdFlag("--assemble")]
        public bit Assemble = 0;

        [CmdArg("--filetype={0}")]
        public string FileType = EmptyString;

        [CmdArg("--target-abi={0}")]
        public string TargetAbi = EmptyString;

        [CmdArg("--triple={0}")]
        public string Triple = EmptyString;

        [CmdArg("--mcpu={0}")]
        public string MCpu = EmptyString;

        [CmdFlag("--incremental-linker-compatible")]
        public bit IncrementalLinkerCompatible = 0;

        [CmdArg("--x86-asm-syntax={0}")]
        public string X86AsmSyntax = EmptyString;

        [CmdArg("--output-asm-variant={0}")]
        public int OutputAsmVariant = -1;

        [CmdFlag("--print-imm-hex")]
        public bit PrintImmHex = 0;

        [CmdFlag("--masm-integers")]
        public bit MasmIntegers = 0;

        [CmdFlag("--masm-hexfloats")]
        public bit MasmHexFloats = 0;

        [CmdArg("--x86-align-branch-boundary={0}")]
        public int X86AlignBranchBoundary = -1;

        [CmdFlag("--x86-branches-within-32B-boundaries")]
        public bit X86BranchesWithin32bBoundaries = 0;

        [CmdFlag("--show-encoding")]
        public bit ShowEncoding = 0;

        [CmdFlag("--fdebug-compilation-dir={0}")]
        public FS.FolderPath DebugCompliationDir = FS.FolderPath.Empty;

        public LlvmMc Tool
            => Tools.llvm_mc;

        FilePath IFlowCmd<FilePath, FilePath>.Source
            => Source;

        FilePath IFlowCmd<FilePath, FilePath>.Target
            => Target;
        public static McCmd Empty => default;
    }
}