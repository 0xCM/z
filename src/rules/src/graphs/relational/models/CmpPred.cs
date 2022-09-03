//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        public readonly struct CmpPred : IFreeCmpPred<CmpPred>
        {
            public readonly IFreeExpr Left;

            public readonly IFreeExpr Right;

            public readonly CmpPredKind Kind;

            public readonly Sym<CmpPredKind> Symbol;

            public readonly uint Size;

            [MethodImpl(Inline)]
            public CmpPred(IFreeExpr a, IFreeExpr b, CmpPredKind kind)
            {
                Left = a;
                Right = b;
                Kind = kind;
                Size = a.Size;
                Symbol = Relations.symbol(Kind);
            }

            uint IFreeExpr.Size
                => Size;

            public bool Eval()
                => default;

            public string Format()
                => string.Concat("{0} {1} {2}", Left, Symbol, Right);

            public override string ToString()
                => Format();
        }
    }
}