//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProject
    {
        @string Name {get;}

        IDbArchive Root {get;}
        
        IEnumerable<FilePath> Files() 
            => Root.Files();

        IDbArchive Build() 
            => Root.Scoped("build");

        IEnumerable<FilePath> BuildFiles(FileKind kind) 
            => Build().Files(kind);

        IDbArchive Source() 
            => Root.Scoped("src");

        IEnumerable<FilePath> SourceFiles() 
            => Source().Files();

        IEnumerable<FilePath> SourceFiles(FileKind kind, bool recursive = true) 
            => Source().Files(kind, recursive);

        IDbArchive Vendor() 
            => Root.Scoped("vendor");

        IDbArchive Cmd() 
            => Root.Scoped("cmd");

        FilePath CmdScript(string name) 
            => Cmd().Path(FS.file(name, FileKind.Cmd));
    }
}