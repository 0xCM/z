//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource("files")]
    public enum FileObjectKind : byte
    {
        None = 0,

        [Symbol("vol")]
        Volume,

        [Symbol("drive")]
        Drive,

        [Symbol("dir")]
        Directory,

        [Symbol("folder")]
        FolderName,

        [Symbol("filename")]
        FileName,

        [Symbol("path")]
        FilePath,

        [Symbol("ext")]
        FileExt,

        [Symbol("uri")]
        Uri,

        [Symbol("symlink/file")]
        FileRef,

        [Symbol("symlink/folder")]
        FolderRef,
    }
}