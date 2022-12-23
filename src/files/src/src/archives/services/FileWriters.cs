//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    public readonly struct FileWriters
    {
        public static SeqEmitter<char> stdout()
            => new SeqEmitter<char>(Console.Out, false);

        public static StreamWriter asci(FilePath dst, FileWriteMode mode = FileWriteMode.Overwrite)
            => new StreamWriter(dst.CreateParentIfMissing().Name.Format(), mode == FileWriteMode.Append, Encoding.ASCII);

        public static StreamWriter utf8(FilePath dst, FileWriteMode mode = FileWriteMode.Overwrite)
            => new StreamWriter(dst.CreateParentIfMissing().Name.Format(), mode == FileWriteMode.Append, Encoding.UTF8);

        public static StreamWriter unicode(FilePath dst, FileWriteMode mode = FileWriteMode.Overwrite)
            => new StreamWriter(dst.CreateParentIfMissing().Name.Format(), mode == FileWriteMode.Append, Encoding.Unicode);
    }
}