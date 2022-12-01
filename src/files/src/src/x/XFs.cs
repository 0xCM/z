//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public static partial class XFs
    {
    }

    public static partial class XTend
    {
        [Op]
        public static LineReader Utf8LineReader(this FilePath src)
            => new LineReader(src.Utf8Reader());

        [Op]
        public static LineReader LineReader(this FilePath src, TextEncodingKind encoding)
            => src.Reader(encoding).ToLineReader();
    }
}