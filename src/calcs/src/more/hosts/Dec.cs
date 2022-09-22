//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    partial struct CalcHosts
    {
        [Closures(AllNumeric), Dec]
        public readonly struct Dec<T> : IUnaryOp<T>, IUnarySpanOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly T Invoke(T a)
                => gmath.dec(a);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> src, Span<T> dst)
                => Calcs.dec(src,dst);
        }

        [NumericClosures(Integers), Dec]
        public readonly struct VDec128<T> : IUnaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x)
                => gcpu.vdec(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gmath.dec(a);
        }

        [NumericClosures(Integers), Dec]
        public readonly struct VDec256<T> : IUnaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x)
                => gcpu.vdec(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gmath.dec(a);
        }

        [NumericClosures(AllNumeric), Dec]
        public readonly struct Dec128<T> : IBlockedUnaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> src, in SpanBlock128<T> dst)
                => ref SpanBlocks.map(src, dst, Calcs.vdec<T>(w128));
        }

        [NumericClosures(AllNumeric), Dec]
        public readonly struct Dec256<T> : IBlockedUnaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> src, in SpanBlock256<T> dst)
                => ref SpanBlocks.map(src, dst, Calcs.vdec<T>(w256));
        }
    }
}