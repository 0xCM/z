//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class FileQuery
    {
        public FolderPath Source;

        public FileFilter Filter;

        public FileQuery()
        {
            Source = FolderPath.Empty;
            Filter = FileFilter.Empty;
        }

        public static FileQuery Empty => new();
    }
}