//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsmSyntaxOps
    {
        public readonly AsmSyntaxRow Row;

        public readonly Index<string> Ops;

        [MethodImpl(Inline)]
        public AsmSyntaxOps(AsmSyntaxRow row, string[] ops)
        {
            Row = row;
            Ops = ops;
        }
    }
}