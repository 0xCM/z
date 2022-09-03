//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static string pattern(params FileExt[] src)
            => string.Join(Chars.Pipe, src.Select(x => x.SearchPattern));
    }
}