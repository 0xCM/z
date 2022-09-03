//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly struct TableSpans
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T entry<T>(in TableSpan<N256,N256,T> src, byte i, byte j)
            where T : unmanaged
                => ref src[i,j];

        [MethodImpl(Inline)]
        public static TableSpan<M,N,T> alloc<M,N,T>(M m = default, N n = default, T fill = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new TableSpan<M,N,T>(fill);

        [MethodImpl(Inline)]
        public static TableSpan<M,N,T> load<M,N,T>(ref T src, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new TableSpan<M,N,T>(ref src);

        [MethodImpl(Inline)]
        public static TableSpan<M,N,T> load<M,N,T>(Span<T> src, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => TableSpan<M,N,T>.CheckedTransfer(src);
    }
}