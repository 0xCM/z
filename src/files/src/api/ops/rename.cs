//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct FS
{
    public static FilePath rename(FilePath src, FilePath dst)
    {
        File.Move(src.Format(), dst.Format());
        return dst;
    }
}
