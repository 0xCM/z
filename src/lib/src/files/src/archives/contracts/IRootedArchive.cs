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
            => Datasets.archive(DbFiles.Targets());

        DbArchive Sources(string scope)
            => Datasets.archive(DbFiles.Sources(scope));

        DbArchive Targets(string scope)
            => Datasets.archive(DbFiles.Targets(scope));

        DbArchive Scoped(string name)
            => Datasets.archive(DbFiles.Sources(name));

        FilePath Table<T>()
            where T : struct
                => DbFiles.Table<T>();

        FilePath Table<T>(ProjectId id)
            where T : struct
                => DbFiles.Table<T>(id);

        FilePath PrefixedTable<T>(string prefix)
            where T : struct
                => DbFiles.PrefixedTable<T>(prefix);

        Files Files()
            => DbFiles.Files(true);

        Files Files(bool recurse)
            => DbFiles.Files(recurse);

        Files Files(FileExt ext)
            => DbFiles.Files(ext);

        FolderPaths Folders(bool recurse = false)
            => Root.Folders(recurse);

        FolderPath Folder(string match)
            => Root.Folder(match);

        Files Files(FileKind kind)
            => DbFiles.Files(kind, true);

        Files Files(FileKind kind, bool recurse)
            => DbFiles.Files(kind, recurse);

        Files Files(params FileKind[] kinds)
            => DbFiles.Files(true, kinds);

        Files Files(string scope, params FileKind[] kinds)
            => DbFiles.Files(scope, true, kinds);

        FileName File(string name, FileKind kind)
            => DbFiles.File(name, kind);

        FilePath Path(string name, FileKind kind)
            => DbFiles.Path(name, kind);

        FilePath Path(FileName file)
            => DbFiles.Path(file);

        FilePath Path(string @class, string name, FileKind kind)
            => DbFiles.Path(@class, name, kind);

        string IExpr.Format()
            => DbFiles.Format();

        Deferred<_FileUri> Enumerate()
            => from f in DbFiles.Enumerate(true) select f.ToUri();
    }

    public interface IRootedArchive<R> : IRootedArchive
        where R : IRootedArchive<R>, new()
    {

    }
}