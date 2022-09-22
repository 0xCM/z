//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FileFlows;
    
    partial class Tools
    {
        public static McCmd cmd(AsmToMcAsm kind, FilePath src, FilePath dst)
        {
            var cmd = McCmd.Empty;
            cmd.Source = src;
            cmd.Target = dst;
            cmd.Triple = "x86_64-pc-windows-msvc";
            cmd.X86AsmSyntax = "intel";
            cmd.OutputAsmVariant =  1;
            cmd.PrintImmHex = 1;
            cmd.MasmIntegers = 1;
            cmd.MasmHexFloats = 1;
            return cmd;
        }

        public static McCmd cmd(SToAsm kind, FilePath src, FilePath dst)
        {
            var cmd = McCmd.Empty;
            cmd.Source = src;
            cmd.Target = dst;
            cmd.FileType = "asm";
            cmd.Triple = "x86_64-pc-windows-msvc";
            cmd.MCpu = "cascadelake";
            cmd.OutputAsmVariant = 1;
            cmd.PrintImmHex = 1;
            return cmd;
        }
    }
}