//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRootedArchive : IExistential, ILocatable<FolderPath>
    {
        FolderPath Root {get;}

        bool INullity.IsEmpty
            => Root.IsEmpty;

        bool INullity.IsNonEmpty
            => Root.IsNonEmpty;

        FolderPath ILocatable<FolderPath>.Location
            => Root;

        bool IExistential.Exists
            => Root.Exists;

        DbArchive DbFiles => Root;

        DbArchive Logs()
            => Targets("logs");

        DbArchive Sources()
            => DbFiles.Sources();

        DbArchive Targets()
            => DbFiles.Targets();

        DbArchive Sources(string scope)
            => DbFiles.Sources(scope);

        DbArchive Targets(string scope)
            => DbFiles.Targets(scope);

        DbArchive Scoped(string name)
            => DbFiles.Sources(name);

        FilePath Table<T>()
            => DbFiles.Table<T>();

        FilePath Table<T>(ProjectId id)
                => DbFiles.Table<T>(id);

        FilePath PrefixedTable<T>(string prefix)
            => DbFiles.PrefixedTable<T>(prefix);

        IEnumerable<FilePath> Files()
            => DbFiles.Files(true);

        IEnumerable<FilePath> Files(bool recurse)
            => DbFiles.Files(recurse);

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
            => DbFiles.Files(recurse, ext);

        FileName File(string name, FileKind kind)
            => DbFiles.File(name, kind);

        FilePath Path(string name, FileKind kind)
            => DbFiles.Path(name, kind);

        FolderPath Folder(string match)
            => Root.Folder(match);

        FilePath Path(FileName file)
            => DbFiles.Path(file);

        FilePath Path(string name, FileExt ext)
            => DbFiles.Path(name, ext);

        FilePath Path(string @class, string name, FileKind kind)
            => DbFiles.Path(@class, name, kind);

        string IExpr.Format()
            => DbFiles.Format();
    }

    public interface IRootedArchive<R> : IRootedArchive
        where R : IRootedArchive<R>, new()
    {

    }
}