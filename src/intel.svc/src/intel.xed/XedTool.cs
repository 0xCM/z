//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public class XedTool
    {
        const string group = "xedtool";

        [SymSource(group)]
        public enum InputKind : byte
        {
            None = 0,

            [Symbol("i", "A pecoff file")]
            PeCoffFile,

            [Symbol("ir", "A raw unformatted binary file")]
            RawBinFile,

            [Symbol("ih", "A raw unformatted ASCII hex file")]
            HexFile,

            [Symbol("d", "A sequence of hex-formatted bytes")]
            HexText,
        }
        
        [SymSource(group)]
        public enum Verbosity : byte
        {
            [Symbol("0", "Quiet")]
            Level0,

            [Symbol("1", "Errors")]
            Level1,

            [Symbol("2", "Info")]
            Level2,

            [Symbol("3", "Trace")]
            Level3,

            [Symbol("5", "Very verbose")]
            Level5,
        }

        [LiteralProvider]
        public struct EncodeRequestModels
        {
            public const string Req00 = "POP/64 RSI";

            public const string Req01 = "MOV/64 R9 RDX";

            public const string Req02 = "AND/64 RSP SIMM:f0";

            public const string Req03 = "JLE BRDISP:11223344";

            public const string Req04 = "INSB";

            public const string Req05 = "INSW/16";

            public const string Req06 = "PUSHF/16";

            public const string Req07 = "PUSHFQ/64";

            public const string Req08 = "POPF/16";

            public const string Req09 = "POPFQ/64";

            public const string Req0A = "CMPSB";

            public const string Req0A_Info = "CMPSB MODE:2, SMODE:2";

            public const string Req0B = "CMPSW/16";

            public const string Req0B_Info="CMPSW EOSZ:1, MODE:2, SMODE:2";

            public const string Req0C = "CMPSD";

            public const string Req0C_Info = "CMPSD MODE:2, SMODE:2";

            public const string Req0D = "CMPSQ/64";

            public const string Req0D_Info = "CMPSQ EOSZ:3, MODE:2, SMODE:2";

            public const string Req0E = "sqrtss xmm0 mem4:eax";

            public const string Req0F = "JRCXZ BRDISP:1E";

            public const string Req10 = "rdfsbase/64 rax";

            public const string Req11 = "rdfsbase eax";

            public const string Req12 = "KMOVQ k0 rax";

            public const string Req13 = "KMOVQ k0 MEM8:ebx";

            public const string Req14 = "KMOVQ rax k0";

            public const string Req15 = "KMOVQ k1 k0";

            public const string Req16 = "KMOVQ k1 k0";

            public const string Req17 = "KMOVQ MEM8:ebx k0";

            public const string Req18 = "KMOVQ MEM8:rbx k0";

            public const string Req18_Info = "KMOVQ MEM0:qword ptr [RBX], MEM_WIDTH:8, MODE:2, REG0:K0, SMODE:2";

            public const string Req19 = "KMOVQ MEM8:ebx k0";

            public const string Req19_Info = "KMOVQ EASZ:2, MEM0:qword ptr [EBX], MEM_WIDTH:8, MODE:2, REG0:K0, SMODE:2";

            public const string Req1A = "vpshaw xmm7 MEM16:ecx xmm6";

            public const string Req1A_Info="VPSHAW EASZ:2, MEM0:xmmword ptr [ECX], MEM_WIDTH:16, MODE:2, REG0:XMM7, REG1:XMM6, SMODE:2";
        }

        [StructLayout(LayoutKind.Sequential, Pack=1), Cmd(CmdName)]
        public struct XedToolCmd
        {
            const string CmdName = "xedtool.cmd";

            [CmdArg("<src>")]
            public FilePath Source;

            [CmdArg("<dst>")]
            public FilePath Target;

            [CmdArg("-{0}")]
            public InputKind InputKind;

            [CmdArg("-v {0}")]
            public Verbosity Verbosity;

            [CmdArg("-{0}")]
            public string Mode;
        }
    }
}