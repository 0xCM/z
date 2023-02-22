//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDbArchive : IRootedArchive
    {
        IEnumerable<FolderPath> Folders(bool recurse = false)
            => Root.Folders(recurse);

        IEnumerable<FolderPath> Folders(string match, bool recurse = false)
            => Root.Folders(match, recurse);

        IEnumerable<RelativeFilePath> Relative(IEnumerable<FilePath> src)
            => FS.relative(Root, src);

        IEnumerable<FilePath> Enumerate(string pattern, bool recursive = true)
            => FS.enumerate(Root, pattern, recursive);

        IEnumerable<FilePath> Enumerate(bool recurse, params FileKind[] kinds)
            => FS.enumerate(Root, recurse, kinds);

        IEnumerable<FilePath> Enumerate(bool recurse, params FileExt[] extensions)
            => FS.enumerate(Root, recurse, extensions);

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