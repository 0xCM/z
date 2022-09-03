//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static SFx;

    partial struct CalcHosts
    {
        [Closures(AllNumeric), Negate]
        public readonly struct VNegate128<T> : IUnaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x)
                => gcpu.vnegate(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gmath.negate(a);
        }

        [Closures(AllNumeric), Negate]
        public readonly struct VNegate256<T> : IUnaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x)
                => gcpu.vnegate(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gmath.negate(a);
        }

        [Closures(AllNumeric), Negate]
        public readonly struct Negate<T> : IUnaryOp<T>, IUnarySpanOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly T Invoke(T a)
                => gmath.negate(a);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> src, Span<T> dst)
                => Calcs.negate(src,dst);
        }

        [Closures(AllNumeric), Negate]
        public readonly struct Negate128<T> : IBlockedUnaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> a, in SpanBlock128<T> c)
                => ref map(a, c, Calcs.vnegate<T>(w128));
        }

        [Closures(AllNumeric), Negate]
        public readonly struct Negate256<T> : IBlockedUnaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> a, in SpanBlock256<T> c)
                => ref map(a, c, Calcs.vnegate<T>(w256));
        }
    }
}