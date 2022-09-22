//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO.Compression;

    using static sys;

    public sealed record class Db : ApiSet<Db>
    {
        const string group = "db";

        static Type Host => typeof(Db);

        [Api]
        public static CmdProcess robocopy(FolderPath src, FolderPath dst)
        {
            var spec = $"robocopy {src} {dst} /e";
            var cmd = Cmd.cmd(spec);
            return CmdProcess.create(cmd);
        }

        [Api]
        public static Task<ExecToken> zip(ArchiveCmd cmd, WfEmit channel)
        {
            var uri = $"{app}://{group}/{cmd}";
            var running = channel.Running(uri);

            ExecToken run()
            {
                ZipFile.CreateFromDirectory(cmd.Source.Format(), cmd.Target.Format(), CompressionLevel.Fastest, true);
                return channel.Ran(running, uri); 
            }

            return @try(run, e => channel.Completed(running, Host, e));                                                    
        }

        [Api]
        public static Task<ExecToken> purge(FolderPath src, RelativePath scope, WfEmit channel)
        {
            var uri = $"{app}://{group}/purge?src={src}&scope={scope}";
            var running = channel.Running(uri);
            var scoped = src + scope;
            var actor = "rmdir";
            var flags = "/s/q";
            var spec = Cmd.cmd($"{actor} {scoped.Format(PathSeparator.BS,true)} {flags}");
            return ProcExec.start(spec,channel);           
        }
    }
}