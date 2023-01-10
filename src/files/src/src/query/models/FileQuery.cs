//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class FileQuery
    {
        public FolderPath Root;

        public FileFilter Filter;

        public FileQuery()
        {
            Root = FolderPath.Empty;
            Filter = FileFilter.Empty;
        }

        public static FileQuery Empty => new();
    }
}