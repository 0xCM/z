//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct StanfordFormInfo
    {
        const string TableId = "asm.stanford.forms.info";

        [Render(8)]
        public uint Seq;

        [Render(32)]
        public TextBlock OpCode;

        [Render(32)]
        public AsmSigInfo Sig;

        [Render(1)]
        public AsmFormInfo FormExpr;
    }
}