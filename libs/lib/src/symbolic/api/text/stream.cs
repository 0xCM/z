//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;
    using System.Text;

    using static Root;

    partial class text
    {
        [Op]
        public static MemoryStream stream(string data, Encoding? encoding = null)
            => new MemoryStream((encoding ?? Encoding.UTF8).GetBytes(data));
    }
}