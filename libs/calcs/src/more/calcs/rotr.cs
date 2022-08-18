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
        [MethodImpl(Inline), Factory(Rotr), Closures(Integers)]
        public static VRotr128<T> vrotr<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VRotr128<T>);

        [MethodImpl(Inline), Factory(Rotr), Closures(Integers)]
        public static VRotr256<T> vrotr<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VRotr256<T>);

        [MethodImpl(Inline), Factory(Rotr), Closures(Integers)]
        public static Rotr128<T> rotr<T>(W128 w)
            where T : unmanaged
                => default(Rotr128<T>);

        [MethodImpl(Inline), Factory(Rotr), Closures(Integers)]
        public static Rotr256<T> rotr<T>(W256 w)
            where T : unmanaged
                => default(Rotr256<T>);

        [MethodImpl(Inline), Rotr, Closures(Integers)]
        public static ref readonly SpanBlock128<T> rotr<T>(in SpanBlock128<T> a, [Imm] byte count, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref rotr<T>(w128).Invoke(a, count, dst);

        [MethodImpl(Inline), Rotr, Closures(Integers)]
        public static ref readonly SpanBlock256<T> rotr<T>(in SpanBlock256<T> a, [Imm] byte count, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref rotr<T>(w256).Invoke(a, count, dst);
    }
}