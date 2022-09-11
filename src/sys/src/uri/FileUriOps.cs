//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class FileUriOps : UriOps<FileUriOps,FileUri>
    {
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
        public static FileUri CreateParentIfMissing(this FileUri src)
        {
            if(src.IsEmpty)
                sys.@throw("The source path is unspecified");

            var dir = System.IO.Path.GetDirectoryName(src.LocalPath);
            if(!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return src;
        }

        [Op]
        public static StreamWriter AsciWriter(this FileUri dst, bool append = false)
            => FileUriOps.asci(dst, append ? FileWriteMode.Append : FileWriteMode.Overwrite);

        [Op]
        public static StreamWriter UnicodeWriter(this FileUri dst, bool append = false)
            => FileUriOps.unicode(dst, append ? FileWriteMode.Append : FileWriteMode.Overwrite);

        [Op]
        public static StreamWriter Utf8Writer(this FileUri dst, bool append = false)
            => FileUriOps.utf8(dst, append ? FileWriteMode.Append : FileWriteMode.Overwrite);
    }    
}