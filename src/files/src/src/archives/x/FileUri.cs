//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XFs
    {
        public static FilePath ToFilePath(this FileUri src)
            => new FilePath(src.LocalPath);
        
        public static FileName FileName(this FileUri src)
            => src.ToFilePath().FileName;
        
        public static FolderPath FolderPath(this FileUri src)
            => src.ToFilePath().FolderPath;

        public static FolderName FolderName(this FileUri src)
            => src.ToFilePath().FolderName;

        public static FileExt Extension(this FileUri src)
            => src.ToFilePath().Ext;

        public static FileKind FileKind(this FileUri src)
            => src.ToFilePath().FileKind();
    }
}