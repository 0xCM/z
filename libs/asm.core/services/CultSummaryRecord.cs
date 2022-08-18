//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using W = AsmColWidths;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CultSummaryRecord
    {
        const string TableId = "cult.summary";

        [Render(W.LineNumber)]
        public uint LineNumber;

        [Render(W.InstForm)]
        public Identifier Id;

        [Render(W.Mnemonic)]
        public AsmMnemonic Mnemonic;

        [Render(W.InstSig)]
        public string Instruction;

        [Render(6)]
        public string Lat;

        [Render(6)]
        public string Rcp;
    }
}