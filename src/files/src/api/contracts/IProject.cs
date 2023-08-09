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
        
        IDbArchive Targets()
            => Root.Scoped("build");

        IDbArchive Targets(string scope)
            => Targets().Scoped(scope);

        IEnumerable<FilePath> Files() 
            => Root.Files();

        IDbArchive Sources() 
            => Root.Scoped("src");

        IEnumerable<FilePath> SourceFiles(FileKind kind, bool recursive = true) 
            => Sources().Files(kind, recursive);

        IDbArchive Cmd() 
            => Root.Scoped("cmd");

        FilePath CmdScript(string name) 
            => Cmd().Path(FS.file(name, FileKind.Cmd));

        public FilePath TablePath<T>()
            => Targets().Path(FS.file(string.Format("{0}.{1}", Name, TableId.identify<T>()),FS.Csv));

        public FilePath TablePath<T>(string scope)
            => Targets().Path(FS.file(string.Format("{0}.{1}", Name, TableId.identify<T>()),FS.Csv));

    }
}