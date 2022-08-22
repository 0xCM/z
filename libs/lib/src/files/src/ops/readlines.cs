//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct FS
    {
        [Op]
        public static Index<TextLine> readlines(FilePath src, bool skipBlank = false)
            => readlines(src, TextEncodingKind.Utf8, skipBlank);

        public static Index<TextLine> readlines(FS.FilePath src, TextEncodingKind encoding, bool skipBlank = false)
        {
            using var reader = src.Reader(encoding);
            var buffer = list<TextLine>();
            var content = reader.ReadLine();
            var number = 1u;
            while(content != null)
            {
                if(skipBlank)
                {
                    if(!text.blank(content))
                        buffer.Add(text.line(number++, content));

                }
                else
                    buffer.Add(text.line(number++, content));

                content = reader.ReadLine();
            }

            return buffer.ToArray();
        }

        public static void readlines(FS.FilePath src, Func<TextLine,bool> dst, TextEncodingKind encoding, bool skipBlank = false)
        {
            using var reader = src.Reader(encoding);
            var content = reader.ReadLine();
            var number = 1u;
            var @continue  = true;
            while(content != null && @continue)
            {
                if(skipBlank)
                {
                    if(!text.blank(content))
                        @continue = dst(text.line(number++, content));

                }
                else
                    @continue = dst(text.line(number++, content));

                content = reader.ReadLine();
            }
        }
    }
}