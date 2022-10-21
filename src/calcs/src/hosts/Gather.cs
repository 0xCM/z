//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        [Closures(UnsignedInts), Gather]
        public readonly struct BvGather<T> : IBvBinaryOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly ScalarBits<T> Invoke(ScalarBits<T> a, ScalarBits<T> b)
                => BitVectors.gather(a,b);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.gather(a,b);
        }
    }
}