//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDbArchive : IRootedArchive
    {
        IEnumerable<RelativeFilePath> Relative(IEnumerable<FilePath> src)
            => FS.relative(Root, src);

        IEnumerable<FileUri> Enumerate(string pattern, bool recursive = true)
            => DbArchive.enumerate(Root, pattern, recursive);

        IEnumerable<FileUri> Enumerate(bool recurse, params FileKind[] kinds)
            => DbArchive.enumerate(Root, recurse, kinds);

        IEnumerable<FileUri> Enumerate(bool recurse, params FileExt[] extensions)
            => DbArchive.enumerate(Root, recurse, extensions);

        DbArchive Metadata()
            => Targets("metadata");

        DbArchive Metadata(string scope)
            => Metadata().Targets(scope);

        IDbArchive Delete()
        {
            Root.Delete();
            return this;
        }

        IDbArchive Clear()
        {
            Root.Clear();
            return this;
        }

        string Name => Root.Name;
    }

    public interface IDbArchive<A> : IDbArchive
        where A : IDbArchive<A>
    {

    }
}