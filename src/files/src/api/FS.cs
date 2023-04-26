//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct FS
    {
        [Op]
        public static string SearchPattern(FileExt[] src)
            => string.Join(";*.", src.Select(e => e.Name));
    }
}