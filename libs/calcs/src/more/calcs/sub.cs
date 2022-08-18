//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static CalcHosts;
    using static SFx;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(Sub), Closures(Closure)]
        public static Sub<T> sub<T>()
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Factory(Sub), Closures(UnsignedInts)]
        public static BvSub<T> bvsub<T>()
            where T : unmanaged
                => sfunc<BvSub<T>>();

        [MethodImpl(Inline), Factory(Sub), Closures(Closure)]
        public static Sub128<T> sub<T>(W128 w)
            where T : unmanaged
                => default(Sub128<T>);

        [MethodImpl(Inline), Factory(Sub), Closures(Closure)]
        public static Sub256<T> sub<T>(W256 w)
            where T : unmanaged
                => default(Sub256<T>);

        [MethodImpl(Inline), Factory(Sub), Closures(Closure)]
        public static VSub128<T> vsub<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VSub128<T>);

        [MethodImpl(Inline), Factory(Sub), Closures(Closure)]
        public static VSub256<T> vsub<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VSub256<T>);

        [MethodImpl(Inline), Sub, Closures(Closure)]
        public static Span<T> sub<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(sub<T>(), a, b, dst);

        [MethodImpl(Inline), Sub, Closures(Closure)]
        public static ref readonly SpanBlock128<T> sub<T>(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref sub<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), Sub, Closures(Closure)]
        public static ref readonly SpanBlock256<T> sub<T>(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref sub<T>(w256).Invoke(a, b, dst);

        /// <summary>
        /// Computes z[i] := x[i] - y[i] for i = 0...N-1
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="z">The target vector</param>
        /// <typeparam name="N">The length type</typeparam>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline)]
        public static ref Block256<N,T> sub<N,T>(Block256<N,T> x, Block256<N,T> y, ref Block256<N,T> z)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            sub(x.Data, y.Data, z.Data);
            return ref z;
        }
    }
}