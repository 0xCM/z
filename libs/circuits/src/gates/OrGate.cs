//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Gated
    {
        public readonly struct OrGate : IBinaryGate
        {
            [MethodImpl(Inline)]
            public bit Invoke(bit x, bit y)
                => (x | y);
        }

        public readonly struct OrGate<T> : IBinaryGate<T>,  IBinaryGate<Vector128<T>>, IBinaryGate<Vector256<T>>, IBinaryGate<Vector512<T>>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public bit Invoke(bit x, bit y)
                => x | y;

            [MethodImpl(Inline)]
            public T Invoke(T x, T y)
                => gmath.or(x, y);

            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> a, Vector128<T> b)
                => gcpu.vor(a,b);

            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> a, Vector256<T> b)
                => gcpu.vor(a, b);

            [MethodImpl(Inline)]
            public Vector512<T> Invoke(Vector512<T> a, Vector512<T> b)
                => gcpu.vor(a, b);
        }
    }
}