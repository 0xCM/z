//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class intel
    {
        public struct CmpPred128<T>
            where T : unmanaged
        {
            public readonly CmpPredKind Kind;

            public readonly __m128i<T> A;

            public readonly __m128i<T> B;

            [MethodImpl(Inline)]
            public CmpPred128(CmpPredKind kind, __m128i<T> a, __m128i<T> b)
            {
                Kind = kind;
                A = a;
                B = b;
            }

            public string Format()
            {
                var syms = Symbols.index<CmpPredKind>();
                var sym = syms[Kind].Expr;
                return string.Format("{0} {1} {2}", A, sym, B);
            }

            public override string ToString()
                => Format();
        }
    }
}