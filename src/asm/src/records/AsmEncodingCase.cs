//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(StructLayout,Pack=1), Record(TableId)]
    public struct AsmEncodingCase
    {
        public const string TableId = "asm.encoding.cases";

        [Render(6)]
        public uint Seq;

        [Render(18)]
        public AsmMnemonic Mnemonic;

        [Render(32)]
        public AsmOpCodeSpec OpCode;

        [Render(64)]
        public AsmSig Sig;

        [Render(64)]
        public asci64 Asm;

        [Render(1)]
        public AsmHexCode Encoding;

        public static AsmEncodingCase Empty => default;
    }
}