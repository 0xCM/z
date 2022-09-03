//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCases
    {
        public readonly struct MemOpCase : IAsmCase
        {
            public readonly MemOp Op;

            public readonly string Asm;

            [MethodImpl(Inline)]
            public MemOpCase(MemOp op, string asm)
            {
                Op = op;
                Asm = asm;
            }

            public string Format()
                => Op.Format();


            public override string ToString()
                => Format();
        }
    }
}