//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    partial struct FS
    {
        public static Index<string> readtext(FS.FilePath src, TextEncodingKind encoding, bool skipBlank = false)
        {
            using var reader = src.Reader(encoding);
            var buffer = list<string>();
            var content = reader.ReadLine();
            while(content != null)
            {
                if(skipBlank)
                {
                    if(!text.blank(content))
                        buffer.Add(content);
                }
                else
                    buffer.Add(content);

                content = reader.ReadLine();
            }

            return buffer.ToArray();
        }
    }
}