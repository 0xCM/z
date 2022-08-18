//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class text
    {
        [Op]
        public static TextRow row(string src, char delimiter)
            => !string.IsNullOrEmpty(src) ? src.SplitClean(delimiter).Select(x => new TextBlock(x)) : TextRow.Empty;
    }
}