//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class BitGrid
    {
        [MethodImpl(Inline)]
        public static int colidx<W>(int row, int col, W width = default)
            where W : unmanaged, ITypeWidth
                => ((int)Widths.type(width) * row) + col;

        [MethodImpl(Inline)]
        public static int colidx<M,N,W>(M row = default, N col = default, W width = default)
            where W : unmanaged, ITypeWidth
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => ((int)Widths.type(width) * nat32i(row)) + nat32i(col);
    }
}