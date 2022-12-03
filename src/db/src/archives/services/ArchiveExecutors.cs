//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Commands;

    public class ArchiveExecutors
    {
        internal sealed class Symlink : Executor<Symlink, CreateSymLink>
        {
            protected override ExecToken Run(IWfChannel channel, CmdContext context, CreateSymLink cmd)
            {
                var flow = channel.Executing(cmd);
                var result = Outcome.Success;
                if(cmd.Kind == Windows.SymLinkKind.File)
                    result = FS.symlink((FilePath)cmd.Source, (FilePath)cmd.Target, cmd.Overwrite);
                else
                    result = FS.symlink((FolderPath)cmd.Source, (FolderPath)cmd.Target, cmd.Overwrite);
                return channel.Executed(flow, result ? $"{cmd.Source} -> {cmd.Target}" : result.Format());                
            }
        }
    }
}