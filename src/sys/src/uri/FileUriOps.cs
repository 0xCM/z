//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class FileUriOps : UriOps<FileUriOps,FileUri>
    {
        public static FileUri lineref(FileUri src, LineNumber line)        
            => new FileUri(string.Format("{0}#{1}", src, line));

        [Op]
        public static StreamReader reader(FileUri src, TextEncodingKind encoding)
            => reader(src, encoding.ToSystemEncoding());

        [Op]
        public static StreamReader reader(FileUri src, Encoding encoding)
            => new StreamReader(src.LocalPath, encoding);

        public static StreamWriter writer(FileUri dst, FileWriteMode mode, Encoding encoding)
            => new StreamWriter(dst.CreateParentIfMissing().LocalPath, mode == FileWriteMode.Append, encoding);

        public static StreamWriter asci(FileUri dst, FileWriteMode mode = FileWriteMode.Overwrite)
            => new StreamWriter(dst.CreateParentIfMissing().LocalPath, mode == FileWriteMode.Append, Encoding.ASCII);

        public static StreamWriter utf8(FileUri dst, FileWriteMode mode = FileWriteMode.Overwrite)
            => new StreamWriter(dst.CreateParentIfMissing().LocalPath, mode == FileWriteMode.Append, Encoding.UTF8);

        public static StreamWriter unicode(FileUri dst, FileWriteMode mode = FileWriteMode.Overwrite)
            => new StreamWriter(dst.CreateParentIfMissing().LocalPath, mode == FileWriteMode.Append, Encoding.Unicode);
    }

    partial class XTend
    {
        public static FileUri LineRef(this FileUri src, LineNumber line)
            => FileUriOps.lineref(src,line);
        public static FileUri CreateParentIfMissing(this FileUri src)
        {
            if(src.IsEmpty)
                sys.@throw("The source path is unspecified");

            var dir = System.IO.Path.GetDirectoryName(src.LocalPath);
            if(!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return src;
        }

        public static StreamReader Utf8Reader(this FileUri src)
            => FileUriOps.reader(src, UTF8);

        public static StreamReader AsciReader(this FileUri src)
            => FileUriOps.reader(src, TextEncodingKind.Asci);

        public static StreamReader UnicodeReader(this FileUri src)
            => FileUriOps.reader(src, TextEncodingKind.Unicode);

        public static StreamWriter AsciWriter(this FileUri dst, bool append = false)
            => FileUriOps.asci(dst, append ? FileWriteMode.Append : FileWriteMode.Overwrite);

        public static StreamWriter UnicodeWriter(this FileUri dst, bool append = false)
            => FileUriOps.unicode(dst, append ? FileWriteMode.Append : FileWriteMode.Overwrite);

        public static StreamWriter Utf8Writer(this FileUri dst, bool append = false)
            => FileUriOps.utf8(dst, append ? FileWriteMode.Append : FileWriteMode.Overwrite);
    }    
}