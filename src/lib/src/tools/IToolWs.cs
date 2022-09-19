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
            
        @string INamed.Name 
            => Location.Root.FolderName.Format();
            
        FilePath CfgPath()
            => Location.Path(Tool.Name, FileKind.Cfg);

        DbArchive Docs()
            => Location.Sources(docs);

        DbArchive Scripts()
            => Location.Sources(scripts);

        FilePath ConfigScript(string name, FileKind kind)
            => Location.Path(FS.file(name,kind));

        FilePath Script(string name, FileKind kind)
            => Scripts().Path(name,kind);

        FilePath Script(FileName file)
            => Scripts().Path(file);
    }
}