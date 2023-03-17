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
        public static BinaryWriter BinaryWriter(this FilePath dst)
            => new BinaryWriter(File.Open(dst.EnsureParentExists().Name, FileMode.Create), Encoding.ASCII);

        [Op]
        public static StreamWriter Writer(this FilePath dst, bool append)
            => FS.writer(dst, append ? FileWriteMode.Append : FileWriteMode.Overwrite, Encoding.UTF8);

        [Op]
        public static StreamWriter Writer(this FilePath dst)
            => FS.writer(dst, FileWriteMode.Overwrite, Encoding.UTF8);

        [Op]
        public static StreamWriter Writer(this FilePath dst, Encoding encoding)
            => FS.writer(dst, FileWriteMode.Overwrite, encoding);

        [Op]
        public static StreamWriter Writer(this FilePath dst, Encoding encoding, bool append)
            => FS.writer(dst, append ? FileWriteMode.Append : FileWriteMode.Overwrite, encoding);

        [Op]
        public static StreamWriter Writer(this FilePath dst, TextEncodingKind encoding, bool append = false)
            => encoding switch {
                TextEncodingKind.Asci => FileWriters.asci(dst, append ? FileWriteMode.Append : FileWriteMode.Overwrite),
                TextEncodingKind.Utf8 => FileWriters.utf8(dst, append ? FileWriteMode.Append : FileWriteMode.Overwrite),
                TextEncodingKind.Unicode => FileWriters.unicode(dst, append ? FileWriteMode.Append : FileWriteMode.Overwrite),
                _ => FileWriters.unicode(dst, append ? FileWriteMode.Append : FileWriteMode.Overwrite)
            };

        [Op]
        public static StreamWriter AsciWriter(this FilePath dst, bool append = false)
            => FileWriters.asci(dst, append ? FileWriteMode.Append : FileWriteMode.Overwrite);

        [Op]
        public static StreamWriter UnicodeWriter(this FilePath dst, bool append = false)
            => FileWriters.unicode(dst, append ? FileWriteMode.Append : FileWriteMode.Overwrite);

        [Op]
        public static StreamWriter Utf8Writer(this FilePath dst, bool append = false)
            => FileWriters.utf8(dst, append ? FileWriteMode.Append : FileWriteMode.Overwrite);

        [Op]
        public static void AppendLines(this FilePath dst, string src)
            => File.AppendAllLines(dst.EnsureParentExists().Name, sys.array(src), Encoding.UTF8);

        [Op]
        public static void AppendLines(this FilePath dst, string src, Encoding encoding)
            => File.AppendAllLines(dst.EnsureParentExists().Name, sys.array(src), encoding);
    }
}