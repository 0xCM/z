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

    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static unsafe Span<byte> Bytes(this ushort src)
            => bytes(src);
    }
}