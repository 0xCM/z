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
    using static core;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(Sll), Closures(Closure)]
        public static Sll128<T> sll<T>(W128 w)
            where T : unmanaged
                => default(Sll128<T>);

        [MethodImpl(Inline), Factory(Sll), Closures(Closure)]
        public static VSll128<T> vsll<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VSll128<T>);

        [MethodImpl(Inline), Factory(Sll), Closures(Closure)]
        public static VSll256<T> vsll<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VSll256<T>);

        [MethodImpl(Inline), Factory(Sll), Closures(Closure)]
        public static Sll256<T> sll<T>(W256 w)
            where T : unmanaged
                => default(Sll256<T>);

        [MethodImpl(Inline), Factory(Sll), Closures(Closure)]
        public static Sll<T> sll<T>()
            where T : unmanaged
                => default(Sll<T>);

        [MethodImpl(Inline), Sll, Closures(Closure)]
        public static Span<T> sll<T>(ReadOnlySpan<T> src, byte count, Span<T> dst)
            where T : unmanaged
        {
            var len = dst.Length;
            ref readonly var input = ref first(src);
            ref var target = ref first(dst);
            for(var i = 0; i<len; i++)
                seek(target,i) = gmath.sll(skip(input,i), count);
            return dst;
        }

        [MethodImpl(Inline), Sll, Closures(Closure)]
        public static ref readonly SpanBlock128<T> sll<T>(in SpanBlock128<T> a, [Imm] byte count, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref sll<T>(w128).Invoke(a, count, dst);

        [MethodImpl(Inline), Sll, Closures(Closure)]
        public static ref readonly SpanBlock256<T> sll<T>(in SpanBlock256<T> a, [Imm] byte count, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref sll<T>(w256).Invoke(a, count, dst);
    }
}