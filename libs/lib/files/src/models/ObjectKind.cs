//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [SymSource("files")]
        public enum ObjectKind : byte
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
            Uri

        }
    }
}