//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using System.Linq;

    class IncludeResolver : Resolver<RelativeFilePath, FilePath>
    {
        readonly ConcurrentDictionary<FolderPath, FileIndex> Index = new();

        readonly ReadOnlySeq<FolderPath> Folders;

        readonly ReadOnlySeq<FilePath> _Resolutions;

        public IncludeResolver(EnvVar<EnvPath> paths)
        {
            Folders = paths.Value.Array();
            iter(Folders, path => Index.TryAdd(path, FS.index(path.EnumerateFiles(true))), true);
            _Resolutions = (from f in Folders from entry in Index.Values from path in entry.Paths select path).Array();
        }

        public override bool Resolve(RelativeFilePath src, out FilePath dst)
        {
            var result = false;
            dst = FilePath.Empty;
            foreach(var path in Resolutions())
            {
                if(path.Format().EndsWith(src.Format()))
                {
                    dst = path;
                    break;
                }
            }

            return result;
        }

        public ReadOnlySeq<FilePath> Resolutions() 
            => _Resolutions;
    }
}