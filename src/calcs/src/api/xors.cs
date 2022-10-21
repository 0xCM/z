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
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(Xors), Closures(Integers)]
        public static Xors128<T> xors<T>(W128 w)
            where T : unmanaged
                => default(Xors128<T>);

        [MethodImpl(Inline), Factory(Xors), Closures(Integers)]
        public static Xors256<T> xors<T>(W256 w)
            where T : unmanaged
                => default(Xors256<T>);

        [MethodImpl(Inline), Xors, Closures(Closure)]
        public static ref readonly SpanBlock128<T> xors<T>(in SpanBlock128<T> a, [Imm] byte count, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref xors<T>(w128).Invoke(a, count, dst);

        [MethodImpl(Inline), Xors, Closures(Closure)]
        public static ref readonly SpanBlock256<T> xors<T>(in SpanBlock256<T> a, [Imm] byte count, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref xors<T>(w256).Invoke(a, count, dst);
    }
}