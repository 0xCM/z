//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class BuildArchive : IFileArchive
    {
        readonly IDbArchive Source;

        public BuildArchive(IDbArchive src)
        {
            Source = src;
        }

        public IEnumerable<FileUri> Files(params FileExt[] ext)
            => Source.Enumerate(true,ext);

        public FolderPath Root => Source.Root;
        
        
    }
}