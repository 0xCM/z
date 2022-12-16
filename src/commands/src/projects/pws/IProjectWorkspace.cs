//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProjectWorkspace : IDbArchive
    {
        ProjectId ProjectId  => Name;

        IDbArchive Home() 
            => this;

        Files SourceFiles(bool recurse = true)
            => Home().Sources("src").Files(recurse);

        Files SourceFiles(FileKind kind, bool recurse = true)
            => Home().Sources("src").Files(kind, recurse);

        FolderPath SrcDir()
            => Home().Sources("src").Root;

        FolderPath SrcDir(string name)
            => SrcDir() + FS.folder(Name);

        Files Scripts()
            => Home().Sources("scripts").Files();

        FilePath Script(string name)
            => Home().Sources("scripts").Path(name, FileKind.Cmd);

        Files ProjectFiles()
            => Home().Root.AllFiles;
        
        FolderPath BuildOut()
            => Scoped(".out").Root;

        Files OutFiles(FileKind kind)
            => Home().Sources(".out").Files(kind);
    }
}