//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Ngt<T> : IFreeCmpPred<Ngt<T>,T>
            where T : unmanaged
        {
            public readonly T Left;

            public readonly T Right;

            public bool IsEmpty => sys.bw64(Left) == 0 || sys.bw64(Right) == 0;

            [MethodImpl(Inline)]
            public Ngt(T a, T b)
            {
                Left = a;
                Right = b;
            }

            T IFreeCmpPred<Ngt<T>,T>.Left
                => Left;

            T IFreeCmpPred<Ngt<T>,T>.Right
                => Right;

            public CmpPredKind Kind
                => CmpPredKind.NGT;

            [MethodImpl(Inline)]
            public Ngt<T> Create(T a0, T a1)
                => new Ngt<T>(a0, a1);

            [MethodImpl(Inline)]
            public static implicit operator Ngt<T>((T a, T b) src)
                => new Ngt<T>(src.a, src.b);
        }
    }
}