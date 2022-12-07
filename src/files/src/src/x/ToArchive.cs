//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    partial class XTend
    {
        public static IDbArchive ToArchive(this FolderPath src)
            => new DbArchive(src);

        public static int CompareTo(this FileUri left, FileUri right)
            => left.ToFilePath().CompareTo(right.ToFilePath());
    }
}