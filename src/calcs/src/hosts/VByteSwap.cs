//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        public readonly struct VByteSwap128<T> : IUnaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x)
                => vgcpu.vbyteswap(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gbits.byteswap(a);
        }

        public readonly struct VByteSwap256<T> : IUnaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x)
                => vgcpu.vbyteswap(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gbits.byteswap(a);
        }
    }
}