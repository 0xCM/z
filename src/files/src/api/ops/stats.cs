//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        public static TextFileStats stats(FilePath src)
        {
            var dst = new TextFileStats();
            using var reader = src.Utf8Reader();
            var line = reader.ReadLine();
            while(line != null)
            {
                var length = (uint)line.Length;
                if(length > dst.MaxLineLength)
                    dst.MaxLineLength = length;
                dst.CharCount += length;
                dst.LineCount++;
                line = reader.ReadLine();
            }
            return dst;
        }
    }
}