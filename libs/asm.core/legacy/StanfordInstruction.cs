//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using W = AsmColWidths;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct StanfordInstruction
    {
        const string TableId = "asm.stanford.instructions";

        [Render(W.Seq)]
        public ushort Seq;

        [Render(W.SymbolicOpCode)]
        public string OpCode;

        [Render(W.InstSig)]
        public string Instruction;

        [Render(16)]
        public string EncodingKind;

        [Render(16)]
        public string Properties;

        [Render(48)]
        public string ImplicitRead;

        [Render(48)]
        public string ImplicitWrite;

        [Render(48)]
        public string ImplicitUndef;

        [Render(12)]
        public string Useful;

        [Render(12)]
        public string Protected;

        [Render(12)]
        public string Mode64;

        [Render(12)]
        public string LegacyMode;

        [Render(12)]
        public string Cpuid;

        [Render(W.Mnemonic)]
        public string AttMnemonic;

        [Render(12)]
        public string Preferred;

        [Render(1)]
        public string Description;
    }
}