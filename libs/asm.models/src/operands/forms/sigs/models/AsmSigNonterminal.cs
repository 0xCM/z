//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [Record(TableId)]
    public struct AsmSigNonterminal
    {
        public const string TableId = "sdm.sigs.nonterminal";

        public const byte FieldCount = 4;

        public AsmSigToken Source;

        public AsmSigToken Term1;

        public AsmSigToken Term2;

        public AsmSigToken Term3;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount] {12,12,12,12};
    }
}