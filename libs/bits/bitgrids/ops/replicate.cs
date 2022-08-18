//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitGrid
    {
        [MethodImpl(Inline), Replicate, NumericClosures(Closure)]
        public static BitSpanBlocks256<T> replicate<T>(BitSpanBlocks256<T> src)
            where T : unmanaged
                => new BitSpanBlocks256<T>(src.Data.Replicate(), src.RowCount, src.ColCount);

        public static BitGrid<M,N,T> replicate<M,N,T>(in BitGrid<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitGrid<M,N,T>(src.Data.Replicate());

        [MethodImpl(Inline)]
        public static BitGrid32<M,N,T> replicate<M,N,T>(BitGrid32<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitGrid32<M,N,T>(src.Data);

        [MethodImpl(Inline)]
        public static BitGrid64<M,N,T> replicate<M,N,T>(BitGrid64<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitGrid64<M,N,T>(src.Data);

        [MethodImpl(Inline)]
        public static BitGrid128<M,N,T> replicate<M,N,T>(in BitGrid128<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => src.Data;

        [MethodImpl(Inline)]
        public static BitGrid256<M,N,T> replicate<M,N,T>(in BitGrid256<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitGrid256<M,N,T>(src.Data);
    }
}