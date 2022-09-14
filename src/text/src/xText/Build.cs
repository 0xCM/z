//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        [Op]
        public static LineReader Utf8LineReader(this FileUri src)
            => new LineReader(FileUriOps.reader(src, UTF8));

        [MethodImpl(Inline), Op]
        public static LineReader ToLineReader(this StreamReader src)
            => new LineReader(src);

        [TextUtility]
        public static StringBuilder Build(this string src)
            => new StringBuilder(src);
    }
}