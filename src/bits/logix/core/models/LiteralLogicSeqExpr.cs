//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a sequence of literal bit values
    /// </summary>
    public readonly struct LiteralLogicSeqExpr : ILiteralLogixSeqExpr
    {
        public Index<bit> Terms {get;}

        [MethodImpl(Inline)]
        public LiteralLogicSeqExpr(bit[] src)
            => Terms = src;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Terms.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Terms.IsNonEmpty;
        }

        public bit this[int index]
        {
            [MethodImpl(Inline)]
            get => Terms[index];

            [MethodImpl(Inline)]
            set => Terms[index] = value;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Terms.Length;
        }

        public string Format()
            => BitRender.gformat(Terms);

        public override string ToString()
            => Format();

        public static LiteralLogicSeqExpr Empty
        {
            [MethodImpl(Inline)]
            get => new LiteralLogicSeqExpr(sys.empty<bit>());
        }
    }
}