//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static BinaryReader BinaryReader(this FilePath src)
            => new BinaryReader(File.Open(src.Format(), FileMode.Open, FileAccess.Read, FileShare.Read));

        [Op]
        public static AsciLineReader AsciLineReader(this FilePath src)
            => new AsciLineReader(src.AsciReader());
            
        /// <summary>
        /// Creates a reader initialized with the source file; caller-disposal required
        /// </summary>
        /// <param name="src">The file path</param>
        [Op]
        public static StreamReader Utf8Reader(this FilePath src)
            => FS.reader(src, Encoding.UTF8);

        [Op]
        public static StreamReader Reader(this FilePath src, TextEncodingKind encoding)
            => FS.reader(src, encoding);

        [Op]
        public static StreamReader AsciReader(this FilePath src)
            => FS.reader(src, Encoding.ASCII);

        [Op]
        public static StreamReader UnicodeReader(this FilePath src)
            => FS.reader(src, Encoding.Unicode);
                    
        [Op]
        public static LineReader Utf8LineReader(this FilePath src)
            => new LineReader(src.Utf8Reader());

        [Op]
        public static LineReader LineReader(this FilePath src, TextEncodingKind encoding)
            => src.Reader(encoding).ToLineReader();
    }
}