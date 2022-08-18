//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a natural-length sequence of literal bit values
    /// </summary>
    public readonly struct LiteralLogixSeqExpr<N> : ILiteralLogixSeqExpr
        where N : unmanaged, ITypeNat
    {
        public Index<bit> Terms {get;}

        [MethodImpl(Inline)]
        public LiteralLogixSeqExpr(bit[] terms)
            => Terms = terms;

        public bit this[int index]
        {
            [MethodImpl(Inline)]
            get => Terms[index];

            [MethodImpl(Inline)]
            set => Terms[index] = value;
        }

        public int Length
            => Terms.Length;

        public string Format()
            => BitRender.gformat(Terms);

        public override string ToString()
            => Format();
    }
}