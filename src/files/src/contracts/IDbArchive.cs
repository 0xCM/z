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

        IEnumerable<FolderPath> Folders(bool recurse, string match)
            => Root.Folders(match, recurse);

        IEnumerable<RelativeFilePath> Relative(IEnumerable<FilePath> src)
            => FS.relative(Root, src);

        IEnumerable<FilePath> Enumerate(bool recurse)
            => FS.enumerate(Root, "*", recurse);

        IEnumerable<FilePath> Enumerate(bool recurse, string pattern)
            => FS.enumerate(Root, pattern, recurse);

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