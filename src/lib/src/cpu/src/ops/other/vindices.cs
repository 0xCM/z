//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    partial struct cpu
    {
        [MethodImpl(Inline), Op]
        public static ushort vindices(Vector128<sbyte> src, sbyte match)
            => vmovemask(veq(src, vbroadcast(w128, match)));

        [MethodImpl(Inline), Op]
        public static ushort vindices(Vector128<byte> src, byte match)
            => vmovemask(veq(src, vbroadcast(w128,match)));

        [MethodImpl(Inline), Op]
        public static uint vindices(Vector256<sbyte> src, sbyte match)
            => vmovemask(veq(src, vbroadcast(w256, match)));

        [MethodImpl(Inline), Op]
        public static uint vindices(Vector256<byte> src, byte match)
            => vmovemask(veq(src, vbroadcast(w256, match)));
    }
}