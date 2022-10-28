//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static WfCmdDefs;
    using static sys;

    [ApiHost]
    public class WfCmdDefs
    {
        [Cmd("copy")]
        public record struct CopyFiles(FolderPath Source, FolderPath Target) 
            : IWfFlow<CopyFiles,FolderPath,FolderPath> {}

        [MethodImpl(Inline), CmdFx]
        public static CopyFiles copy(FolderPath src, FolderPath dst)
            => new (src,dst);        

        [Cmd("pack")]
        public record struct PackFolder(FolderPath Source, FileUri Target) 
            : IWfFlow<PackFolder,FolderPath,FileUri> {}

        [MethodImpl(Inline), CmdFx]
        public static PackFolder pack(FolderPath src, FileUri dst)
            => new (src,dst);        

        [Cmd("files/gather")]
        public record struct GatherFiles(FolderPath Source, FolderPath Target, FileExt Ext) 
            : IWfFlow<GatherFiles,FolderPath,FolderPath> {}

        [MethodImpl(Inline), CmdFx]
        public static GatherFiles gather(FolderPath src, FolderPath dst, FileExt ext)
            => new (src,dst,ext);
    }

    public class WfCmdExec
    {
        public static Task<ExecToken> exec(IWfChannel channel, GatherFiles cmd)
        {
            ExecToken exec()
            {
                var flow = channel.Running(cmd);
                var paths = cmd.Source.Files(cmd.Ext,true);
                iter(paths, src => {
                    var dst = src.CopyTo(cmd.Target);
                    channel.Babble($"Copied {src} -> {dst}");
                });
                return channel.Ran(flow);
            }

            return start(exec);            
        }

    }
}