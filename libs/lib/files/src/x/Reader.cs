//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    partial class XTend
    {
        /// <summary>
        /// Creates a reader initialized with the source file; caller-disposal required
        /// </summary>
        /// <param name="src">The file path</param>
        [Op]
        public static StreamReader Utf8Reader(this FS.FilePath src)
            => FS.reader(src, Encoding.UTF8);

        [Op]
        public static StreamReader Reader(this FS.FilePath src, TextEncodingKind encoding)
            => FS.reader(src, encoding);

        [Op]
        public static StreamReader AsciReader(this FS.FilePath src)
            => FS.reader(src, Encoding.ASCII);

        [Op]
        public static StreamReader UnicodeReader(this FS.FilePath src)
            => FS.reader(src, Encoding.Unicode);
    }
}