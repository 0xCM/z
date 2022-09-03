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

    partial class gbits
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit readbit<T>(in T src, uint bitpos)
            where T : unmanaged
                => gbits.test(skip(src, bitpos / width<T>()), (byte)(bitpos % core.width<T>()));
    }
}