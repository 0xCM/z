//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Commands;

    public class ArchiveExecutors
    {
        internal sealed class SymlinkExecutor : Executor<SymlinkExecutor, CreateSymLink, Symlink>
        {
            protected override Symlink Run(CmdContext context, CreateSymLink cmd)
            {
                var result = Symlink.Empty;
                if(cmd.Kind == Windows.SymLinkKind.File)
                    result = FS.symlink((FilePath)cmd.Source, (FilePath)cmd.Target, cmd.Overwrite);
                else
                    result = FS.symlink((FolderPath)cmd.Source, (FolderPath)cmd.Target, cmd.Overwrite);
                return result;                            
            }
        }
    }
}