//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using static WfArchives.CommandNames;

    [WfModule]
    public class WfArchives : WfModule<WfArchives>
    {
        public class CommandNames 
        {
            public const string FilesGather = "files/gather";

            public const string FilesCopy = "files/copy";

            public const string FilesPack = "files/pack";
        }

        [Cmd(FilesCopy)]
        public record struct CopyFiles(FolderPath Source, FolderPath Target) 
            : IWfFlow<CopyFiles,FolderPath,FolderPath> {}

        [Cmd(FilesPack)]
        public record struct PackFolder(FolderPath Source, FileUri Target) 
            : IWfFlow<PackFolder,FolderPath,FileUri> {}

        [Cmd(FilesGather)]
        public record struct GatherFiles(FolderPath Source, FolderPath Target, FileExt Ext) 
            : IWfFlow<GatherFiles,FolderPath,FolderPath> {}

        [MethodImpl(Inline), CmdFx(FilesCopy)]
        public static CopyFiles copy(FolderPath src, FolderPath dst)
            => new (src,dst);        

        [MethodImpl(Inline), CmdFx(FilesPack)]
        public static PackFolder pack(FolderPath src, FileUri dst)
            => new (src,dst);        

        [MethodImpl(Inline), CmdFx]
        public static GatherFiles gather(FolderPath src, FolderPath dst, FileExt ext)
            => new (src,dst,ext);

        [CmdOp(FilesGather)]
        public Task<ExecToken> Gather(IWfChannel channel, CmdArgs args)
        {            
            var cmd = gather(FS.dir(args[0]), FS.dir(args[1]), FileKind.Nuget.Ext());
            return Exec(channel, cmd);
        }

        Task<ExecToken> Exec(IWfChannel channel, GatherFiles cmd)
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
