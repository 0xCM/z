//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    partial struct CalcHosts
    {
        [Closures(AllNumeric), Nonz]
        public readonly struct VNonZ128<T> : IUnaryPred128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public bit Invoke(Vector128<T> x)
                => gcpu.vnonz(x);

            [MethodImpl(Inline)]
            public bit Invoke(T a)
                => gmath.nonz(a);
        }

        [Closures(AllNumeric), Nonz]
        public readonly struct VNonZ256<T> : IUnaryPred256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public bit Invoke(Vector256<T> x)
                => gcpu.vnonz(x);

            [MethodImpl(Inline)]
            public bit Invoke(T a)
                => gmath.nonz(a);
        }

        [Closures(AllNumeric), Nonz]
        public readonly struct Nonz<T> : IFunc<T,bit>, IUnarySpanPred<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public bit Invoke(T a)
                => gmath.nonz(a);

            [MethodImpl(Inline)]
            public Span<bit> Invoke(ReadOnlySpan<T> src, Span<bit> dst)
                => gcalc.apply(this, src, dst);
        }

        [Closures(AllNumeric), Nonz]
        public readonly struct NonZ128<T> : IBlockedUnaryPred128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Span<bit> Invoke(SpanBlock128<T> src, Span<bit> dst)
                => SpanBlocks.map(src, dst, Calcs.vnonz<T>(w128));
        }

        [Closures(AllNumeric), Nonz]
        public readonly struct NonZ256<T> : IBlockedUnaryPred256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Span<bit> Invoke(SpanBlock256<T> src, Span<bit> dst)
                => SpanBlocks.map(src, dst, Calcs.vnonz<T>(w256));
        }
    }
}