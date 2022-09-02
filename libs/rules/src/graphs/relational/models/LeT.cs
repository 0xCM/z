//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Le<T> : IFreeCmpPred<Le<T>,T>
            where T : unmanaged
        {
            public readonly T Left;

            public readonly T Right;

            public bool IsEmpty => sys.bw64(Left) == 0 || sys.bw64(Right) == 0;

            [MethodImpl(Inline)]
            public Le(T a, T b)
            {
                Left = a;
                Right = b;
            }

            T IFreeCmpPred<Le<T>,T>.Left
                => Left;

            T IFreeCmpPred<Le<T>,T>.Right
                => Right;

            public CmpPredKind Kind
                => CmpPredKind.LE;

            [MethodImpl(Inline)]
            public Le<T> Create(T a0, T a1)
                => new Le<T>(a0, a1);

            [MethodImpl(Inline)]
            public static implicit operator Le<T>((T a, T b) src)
                => new Le<T>(src.a, src.b);
        }
    }
}