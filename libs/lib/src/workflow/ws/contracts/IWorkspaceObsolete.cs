//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static WsAtoms;

    public interface IWorkspaceObselete : IFileArchive
    {
        string Name {get;}

        FS.FolderPath SrcDir()
            => Root + FS.folder(src);

        FS.FolderPath SrcDir(string scope)
            => SrcDir() + FS.folder(scope);

        FS.FolderPath BuildOut()
            => Root + FS.folder(".out");

        FS.FolderPath ScriptDir()
            => Root + FS.folder(scripts);

        FS.FilePath Script(string name)
            => ScriptDir() + FS.file(name, FS.Cmd);
    }
}