//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static WsAtoms;

    public interface IProjectWsObsolete : IWorkspaceObselete
    {
        ProjectId Project {get;}

        FS.FolderPath Home()
            => Root;

        FS.FolderPath IFileArchive.Subdir(string name)
            => Home() + FS.folder(name);

        FS.FolderPath IWorkspaceObselete.SrcDir()
            => Home() + FS.folder("src");

        FS.FolderPath IWorkspaceObselete.SrcDir(string scope)
            => SrcDir() + FS.folder(scope);

        FS.FolderPath IWorkspaceObselete.BuildOut()
            => Out();

        FS.FolderPath IWorkspaceObselete.ScriptDir()
            => Home() + FS.folder(scripts);

        FS.FilePath IFileArchive.TablePath<T>(string scope)
            where T : struct
                => Subdir(scope) + TableFile<T>();

        FS.Files ProjectFiles()
            => Home().Files(true).Array().Sort();

        FS.FolderPath Out()
            => Home() + FS.folder(output);

        FS.FolderPath Out(string scope)
            => Out() + FS.folder(scope);

        FS.Files OutFiles(FS.FileExt ext)
            => Out().Files(ext, true);

        FS.Files OutFiles(FileKind kind)
            => Out().Files(kind.Ext(), true);

        FS.FolderPath Logs()
            => Out() + FS.folder(logs);

        FS.FilePath Log(string id, FS.FileExt ext)
            => Logs() + FS.file(id,ext);

        FS.Files SrcFiles(FileKind kind, bool recurse = true)
            => SrcDir().Files(kind.Ext(), recurse);

        FS.Files SrcFiles(bool recurse = true)
            => SrcDir().Files(recurse);
    }
}