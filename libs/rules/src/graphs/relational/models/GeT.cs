//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Ge<T> : IFreeCmpPred<Ge<T>,T>
            where T : unmanaged
        {
            public readonly T Left;

            public readonly T Right;

            [MethodImpl(Inline)]
            public Ge(T a, T b)
            {
                Left = a;
                Right = b;
            }

            public bool IsEmpty => sys.bw64(Left) == 0 || sys.bw64(Right) == 0;

            public CmpPredKind Kind
                => CmpPredKind.GE;

            T IFreeCmpPred<Ge<T>,T>.Left
                => Left;

            T IFreeCmpPred<Ge<T>,T>.Right
                => Right;

            [MethodImpl(Inline)]
            public Ge<T> Create(T a0, T a1)
                => new Ge<T>(a0, a1);

            [MethodImpl(Inline)]
            public static implicit operator Ge<T>((T a, T b) src)
                => new Ge<T>(src.a, src.b);
        }
    }
}