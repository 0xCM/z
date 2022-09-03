//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static HexFormatSpecs;
    using static sys;

    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static uint postspec(ref uint i, Span<char> dst)
        {
            seek(dst,i++) = PostSpecChar;
            return 2;
        }

        public static bool postspec(string src)
            => src.TrimEnd().EndsWith(PostSpec);
    }
}