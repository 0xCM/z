//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct FS
{
    public static FilePath move(FilePath src, FilePath dst)
        => rename(src,dst);
}
