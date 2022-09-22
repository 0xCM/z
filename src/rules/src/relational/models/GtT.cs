//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Gt<T> : IFreeCmpPred<Gt<T>,T>
            where T : unmanaged
        {
            public readonly T Left;

            public readonly T Right;

            public bool IsEmpty => sys.bw64(Left) == 0 || sys.bw64(Right) == 0;

            [MethodImpl(Inline)]
            public Gt(T a, T b)
            {
                Left = a;
                Right = b;
            }

            T IFreeCmpPred<Gt<T>,T>.Left
                => Left;

            T IFreeCmpPred<Gt<T>,T>.Right
                => Right;

            public CmpPredKind Kind
                => CmpPredKind.GT;

            [MethodImpl(Inline)]
            public Gt<T> Create(T a0, T a1)
                => new Gt<T>(a0, a1);

            [MethodImpl(Inline)]
            public static implicit operator Gt<T>((T a, T b) src)
                => new Gt<T>(src.a, src.b);
        }
    }
}