//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static Index<string> ReadLines(this FS.FilePath src, bool skipBlank = false)
            => FS.readtext(src, TextEncodingKind.Utf8, skipBlank);

        [Op]
        public static Index<string> ReadLines(this FS.FilePath src, TextEncodingKind encoding, bool skipBlank = false)
            => FS.readtext(src, encoding, skipBlank);

        public static void ReadLines(this FS.FilePath src, Func<TextLine,bool> dst, TextEncodingKind encoding = TextEncodingKind.Utf8, bool skipBlank = true)
            => FS.readlines(src, dst, encoding, skipBlank);

        [Op]
        public static Index<TextLine> ReadNumberedLines(this FS.FilePath src, bool skipBlank = false)
            => FS.readlines(src, skipBlank);

        public static Index<TextLine> ReadNumberedLines(this FS.FilePath src, TextEncodingKind encoding, bool skipBlank = false)
            => FS.readlines(src,encoding, skipBlank);
    }
}