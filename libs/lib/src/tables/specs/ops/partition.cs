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

    partial struct DataLayouts
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static LayoutPart<T> part<T>(uint index, T kind, ulong i0, ulong i1)
            where T : unmanaged
                => new LayoutPart<T>(identify(index, kind), i0, i1);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void part<T>(ref LayoutPart<T> lead, ref uint index, T kind, ulong offset, ByteSize size)
            where T : unmanaged
        {
            var left = offset*8;
            var right = size.Bits + left - 1;
            seek(lead, index) = part(index, kind, left, right);
            index++;
        }
    }
}