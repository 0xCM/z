//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static FilePath[] exclude(FilePath[] src, string pattern)
            => src.Where(x => !contains(x.Name, pattern));
    }
}