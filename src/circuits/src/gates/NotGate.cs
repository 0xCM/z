//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Gated
    {
        public readonly struct NotGate<T> : IUnaryGate<T>, IUnaryGate<Vector128<T>>, IUnaryGate<Vector256<T>>, IUnaryGate<Vector512<T>>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public bit Invoke(bit input)
                => !input;

            [MethodImpl(Inline)]
            public T Invoke(T x)
                => gmath.not(x);

            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x)
                => vgcpu.vnot(x);

            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x)
                => vgcpu.vnot(x);

            [MethodImpl(Inline)]
            public Vector512<T> Invoke(Vector512<T> x)
                => vgcpu.vnot(x);
        }
    }
}