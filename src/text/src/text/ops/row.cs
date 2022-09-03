//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [Op]
        public static TextRow row(string src, char delimiter)
            => !string.IsNullOrEmpty(src) ? src.SplitClean(delimiter).Select(x => new TextBlock(x)) : TextRow.Empty;
    }
}