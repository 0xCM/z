//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct FileQuery
    {
        public FolderPath Source;

        public FileFilter Filter;
    }
}