//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IToolWs : INullity, IExpr, IHashed
    {
        Tool Tool {get;}
        
        IDbArchive Root  {get;}

        bool INullity.IsEmpty
            => Tool.IsEmpty;

        Hash32 IHashed.Hash
            => Tool.Hash;
                        
        FilePath CfgPath()
            => Root.Path(Tool.Name, FileKind.Cfg);

        DbArchive Docs()
            => Root.Sources("docs");

        DbArchive Scripts()
            => Root.Sources("scripts");

        FilePath ConfigScript(string name, FileKind kind)
            => Root.Path(FS.file(name,kind));

        FilePath Script(string name, FileKind kind)
            => Scripts().Path(name,kind);

        FilePath Script(FileName file)
            => Scripts().Path(file);
    }
}