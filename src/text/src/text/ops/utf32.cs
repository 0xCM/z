//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    using static Root;

    partial class text
    {
        [MethodImpl(Inline), Op]
        public static BinaryCode utf32(string src)
            => Encoding.UTF32.GetBytes(src);

        [MethodImpl(Inline), Op]
        public static string utf32(ReadOnlySpan<byte> src)
            => Encoding.UTF32.GetString(src);
    }
}