//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct core
    {
        [MethodImpl(Inline), Op]
        public static Span<byte> replicate(MemoryRange src)
        {
            Span<byte> dst = alloc<byte>(src.ByteCount);
            copy(src, dst);
            return dst;
        }
    }
}