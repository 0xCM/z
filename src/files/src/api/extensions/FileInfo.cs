//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XTend
{
    public static FileInfo FileInfo(this FilePath src)
        => FS.info(src);
}
