
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    partial struct CalcHosts
    {
        [Closures(Integers)]
        public readonly struct VXorNot128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => vgcpu.vxornot(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.xornot(a,b);
        }

        [NumericClosures(Integers)]
        public readonly struct VXorNot256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => vgcpu.vxornot(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.xornot(a,b);
        }

        [Closures(Integers), XorNot]
        public readonly struct XorNot128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock128<T> Invoke(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vxornot<T>(w128));
        }

        [Closures(Integers), XorNot]
        public readonly struct XorNot256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock256<T> Invoke(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vxornot<T>(w256));
        }
    }
}