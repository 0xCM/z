//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XTend
    {
        [Op]
        public static string DottedName(this Type src)
            => src.FullName.Replace(Chars.Plus, Chars.Dot);
    }
}