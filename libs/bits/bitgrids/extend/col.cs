//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XTend
    {
        [MethodImpl(Inline)]
        public static ScalarBits<N16,ushort> Col<T>(this BitGrid64<N16,N4,T> g, int index)
            where T : unmanaged
                => BitGrid.col(g,index);

        [MethodImpl(Inline)]
        public static ScalarBits<N4,byte> Col<T>(this BitGrid64<N4,N16,T> g, int index)
            where T : unmanaged
                => BitGrid.col(g,index);
    }
}