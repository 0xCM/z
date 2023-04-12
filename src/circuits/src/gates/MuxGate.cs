//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Gated
    {
        public readonly struct MuxGate<T> : ITernaryGate<T>, ITernaryGate<Vector128<T>>, ITernaryGate<Vector256<T>>, ITernaryGate<Vector512<T>>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public bit Invoke(bit a, bit b, bit c)
                => a ? b : c;

            [MethodImpl(Inline)]
            public T Invoke(T a, T b, T c)
                => gmath.select(a,b,c);

            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y, Vector128<T> z)
                => vgcpu.vselect(x,y,z);

            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y, Vector256<T> z)
                => vgcpu.vselect(x,y,z);

            [MethodImpl(Inline)]
            public Vector512<T> Invoke(Vector512<T> x, Vector512<T> y, Vector512<T> z)
                => vgcpu.vselect(x,y,z);
        }
    }
}