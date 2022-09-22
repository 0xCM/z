//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XFs
    {
        public static FilePath ToFilePath(this FileUri src)
            => new FilePath(src.LocalPath);
    }
}