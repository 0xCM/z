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
        public static BinaryCode unicode(string src)
            => Encoding.Unicode.GetBytes(src);

        [MethodImpl(Inline), Op]
        public static BinaryCode unicode(string src, EndianBig endian)
            => Encoding.BigEndianUnicode.GetBytes(src);
    }
}