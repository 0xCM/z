//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct InPair<T>
        where T : unmanaged
    {
        public readonly T A;

        public readonly T B;

        [MethodImpl(Inline)]
        public InPair(T x, T y)
        {
            A = x;
            B = y;
        }

        [MethodImpl(Inline)]
        public static implicit operator (T x, T y)(InPair<T> src)
            => (src.A, src.B);

        [MethodImpl(Inline)]
        public static implicit operator InPair<T>(OutPair<T> src)
            => new (src.A,src.B);

        [MethodImpl(Inline)]
        public static implicit operator InPair<T> ((T x, T y) src)
            => new (src.x, src.y);
    }

}