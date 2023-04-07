//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDbArchive : IRootedArchive
    {
        RelativeFilePath Relative(FilePath src)
            => FS.relative(Root,src);

        IEnumerable<RelativeFilePath> Relative(IEnumerable<FilePath> src)
            => FS.relative(Root,src);

        IEnumerable<FolderPath> Folders(bool recurse = false)
            => Root.Folders(recurse);

        IEnumerable<FolderPath> Folders(bool recurse, string match)
            => Root.Folders(match, recurse);

        IEnumerable<FilePath> Enumerate(bool recurse)
            => FS.files(Root, "*", recurse);

        IEnumerable<FilePath> Enumerate(bool recurse, string pattern)
            => FS.files(Root, pattern, recurse);

        IEnumerable<FilePath> Enumerate(bool recurse, params FileKind[] kinds)
             => FS.files(Root, recurse, kinds);

        IEnumerable<FilePath> Enumerate(bool recurse, params FileExt[] extensions)
             => FS.files(Root, recurse, extensions);

        DbArchive Metadata()
            => Targets("metadata");

        DbArchive Metadata(string scope)
            => Metadata().Targets(scope);

        DbArchive Nested(FolderPath src)
            => DbFiles.Nested(src);

        DbArchive Nested(IDbArchive src)
            => DbFiles.Nested(src.Root);

        DbArchive Nested(string scope, FolderPath src)
            => DbFiles.Nested(scope, src);

        DbArchive Nested(string scope, IDbArchive src)
            => DbFiles.Nested(scope, src.Root);

        FilePath Table<T>()
            => DbFiles.Table<T>();

        FilePath Table<T>(ProjectId id)
            => DbFiles.Table<T>(id);

        FilePath PrefixedTable<T>(string prefix)
            => DbFiles.PrefixedTable<T>(prefix);

        IEnumerable<FilePath> Files()
            => Root.Files(true);

        IEnumerable<FilePath> Files(bool recurse)
            => Root.Files(recurse);

        IEnumerable<FilePath> Files(bool recurse, string pattern)
            => FS.files(Root, pattern, recurse);

        IEnumerable<FilePath> Files(FileExt ext)
            => DbFiles.Files(ext);

        IEnumerable<FilePath> Files(FileKind kind)
            => DbFiles.Files(kind, true);

        IEnumerable<FilePath> Files(FileKind kind, bool recurse)
            => DbFiles.Files(kind, recurse);

        IEnumerable<FilePath> Files(params FileKind[] kinds)
            => DbFiles.Files(true, kinds);

        IEnumerable<FilePath> Files(string scope, params FileKind[] kinds)
            => DbFiles.Files(scope, true, kinds);

        IEnumerable<FilePath> Files(bool recurse, params FileExt[] ext)
            => FS.files(Root, recurse, ext);
            
        IEnumerable<FilePath> Files(bool recurse, params FileKind[] kinds)
             => FS.files(Root, recurse, kinds);

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