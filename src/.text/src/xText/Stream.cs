//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.IO;

    partial class XText
    {
        [TextUtility]
        public static StringReader Reader(this string src)
            => new StringReader(src);

        [TextUtility]
        public static MemoryStream Stream(this string src, Encoding encoding = null)
            => text.stream(src, encoding);
    }
}