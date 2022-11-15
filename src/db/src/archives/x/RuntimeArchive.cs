//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FS;

    partial class XTend
    {
        public static IRuntimeArchive RuntimeArchive(this Assembly src)
            => Z0.RuntimeArchive.load(src);
    }
}