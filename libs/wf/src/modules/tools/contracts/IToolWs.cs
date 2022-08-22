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
        
        DbArchive Location  {get;}

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

        DbArchive Docs()
            => Location.Sources(docs);

        DbArchive Scripts()
            => Location.Sources(scripts);

        FS.FilePath ConfigScript(string name, FileKind kind)
            => Location.Path(FS.file(name,kind));

        FS.FilePath Script(string name, FileKind kind)
            => Scripts().Path(name,kind);

        FS.FilePath Script(FS.FileName file)
            => Scripts().Path(file);
    }
}