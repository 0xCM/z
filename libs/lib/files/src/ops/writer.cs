//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static StreamWriter writer(FS.FilePath dst, FileWriteMode mode, Encoding encoding)
            => new StreamWriter(dst.CreateParentIfMissing().Name.Format(), mode == FileWriteMode.Append, encoding);

        [Op]
        public static StreamWriter writer(FS.FilePath dst, TextEncodingKind encoding)
            => writer(dst, FileWriteMode.Overwrite, encoding.ToSystemEncoding());

        [Op]
        public static StreamWriter writer(FS.FilePath dst, FileWriteMode mode, TextEncodingKind encoding)
            => writer(dst, mode, encoding.ToSystemEncoding());
    }
}