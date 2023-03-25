//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProjectWorkspace : IDbArchive
    {
        FileIndex FileIndex {get;}

        ProjectId ProjectId 
            => Name;

        IDbArchive Home() 
            => this;

        IEnumerable<FilePath> SourceFiles(bool recurse = true)
            => Scoped("src").Files(recurse);

        IEnumerable<FilePath> SourceFiles(FileKind kind, bool recurse = true)
            => Scoped("src").Files(kind, recurse);

        FolderPath SrcDir()
            => Scoped("src").Root;

        FolderPath SrcDir(string name)
            => Scoped($"src/{name}");

        IEnumerable<FilePath> CmdScripts()
            => Scoped("cmd").Files(FileKind.Cmd);

        FilePath CmdScript(string name)
            => Scoped("cmd").Path(name, FileKind.Cmd);

        FolderPath BuildOut()
            => Scoped("build").Root;

        IEnumerable<FilePath> OutFiles(FileKind kind)
            => Scoped("build").Files(kind);
    }
}