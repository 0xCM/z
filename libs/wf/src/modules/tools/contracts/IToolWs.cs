//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    public interface IToolWs : INamed
    {
        Tool Tool {get;}
        
        IDbArchive Location  {get;}

        bool INullity.IsEmpty
            => Tool.IsEmpty;

        string IExpr.Format()
            => Tool.Format();

        Hash32 IHashed.Hash
            => Tool.Hash;
            
        Name INamed.Name 
            => Location.Root.FolderName.Format();
            
        FS.FilePath EnvPath()
            => Location.Path(Tool.Name, FileKind.Env);

        IDbArchive Docs()
            => new DbArchive(Location.Sources(docs));

        IDbArchive Scripts()
            => new DbArchive(Location.Sources(scripts));

        FS.FilePath ConfigScript(string name, FileKind kind)
            => Location.Path(FS.file(name,kind));

        FS.FilePath Script(string name, FileKind kind)
            => Scripts().Path(name,kind);

        FS.FilePath Script(FS.FileName file)
            => Scripts().Path(file);
    }
}