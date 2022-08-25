//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    partial struct FS
    {
        public static ListedFiles listing(FS.FolderPath src, bool recurse)
            => src.Files(recurse).Select(listing).Array();

        public static ListedFiles listing(FS.FolderPath src, bool recurse, params FileKind[] kinds)
            => src.Files(recurse,kinds).Select(listing).Array();

        public static ListedFiles listing(ReadOnlySpan<FilePath> src)
            => src.Select(listing);

        public static ListedFile listing(FilePath src)
        {
            var dst = new ListedFile();
            var info = new FileInfo(src.Name);
            dst.Size = ((ByteSize)info.Length).Kb;
            dst.CreateTS = info.CreationTime;
            dst.UpdateTS = info.LastWriteTime;
            dst.Path = src;
            dst.Attributes = info.Attributes;
            return dst;
        }
    }
}