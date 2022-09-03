//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        [StructLayout(StructLayout)]
        public readonly struct Neq<T> : IFreeCmpPred<Neq<T>,T>
            where T : unmanaged
        {
            public readonly T Left;

            public readonly T Right;

            public bool IsEmpty => sys.bw64(Left) == 0 || sys.bw64(Right) == 0;

            [MethodImpl(Inline)]
            public Neq(T a, T b)
            {
                Left = a;
                Right = b;
            }

            T IFreeCmpPred<Neq<T>,T>.Left
                => Left;

            T IFreeCmpPred<Neq<T>,T>.Right
                => Right;

            public CmpPredKind Kind
                => CmpPredKind.NEQ;

            [MethodImpl(Inline)]
            public Neq<T> Create(T a0, T a1)
                => new Neq<T>(a0,a1);

            [MethodImpl(Inline)]
            public static implicit operator Neq<T>((T a, T b) src)
                => new Neq<T>(src.a, src.b);
        }
    }
}