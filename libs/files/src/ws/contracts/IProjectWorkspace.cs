//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProjectWorkspace : IWorkspace
    {
        ProjectId ProjectId  => Name;

        IDbArchive Home() => new DbArchive(Root);

        FS.Files SourceFiles(bool recurse = true)
            => Home().Sources("src").Files(recurse);

        FS.Files SourceFiles(FileKind kind, bool recurse = true)
            => Home().Sources("src").Files(kind, recurse);

        FS.FolderPath SrcDir()
            => Home().Sources("src").Root;

        FS.FolderPath SrcDir(string name)
            => SrcDir() + FS.folder(Name);

        FS.Files Scripts()
            => Home().Sources("scripts").Files();

        FS.FilePath Script(string name)
            => Home().Sources("scripts").Path(name, FileKind.Cmd);

        FS.Files ProjectFiles()
            => Home().Root.AllFiles;
        
        FS.FolderPath BuildOut()
            => Root + FS.folder(".out");

        FS.Files OutFiles(FileKind kind)
            => Home().Sources(".out").Files(kind);
    }
}