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

        IEnumerable<FilePath> SourceFiles(bool recurse = true)
            => Home().Sources("src").Files(recurse);

        IEnumerable<FilePath> SourceFiles(FileKind kind, bool recurse = true)
            => Home().Sources("src").Files(kind, recurse);

        FolderPath SrcDir()
            => Home().Sources("src").Root;

        FolderPath SrcDir(string name)
            => SrcDir() + FS.folder(Name);

        IEnumerable<FilePath> Scripts()
            => Home().Sources("scripts").Files();

        FilePath Script(string name)
            => Home().Sources("scripts").Path(name, FileKind.Cmd);

        IEnumerable<FilePath> ProjectFiles()
            => Home().Root.AllFiles;
        
        FolderPath BuildOut()
            => Scoped(".out").Root;

        IEnumerable<FilePath> OutFiles(FileKind kind)
            => Home().Sources(".out").Files(kind);
    }
}