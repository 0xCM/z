//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO.Compression;

    using static sys;

    public class Db 
    {
        const string group = "db";

        static Type Host => typeof(Db);

        public static SymLinkCmd symlink(FolderPath src, FolderPath dst)
            => new SymLinkCmd(SymLinkCmd.Flag.Directory, src.ToUri(), dst.ToUri());

        [Op]
        static CmdLine cmd(string spec)
            => string.Format("cmd.exe /c {0}", spec);

        public static CmdProcess robocopy(FolderPath src, FolderPath dst)
        {
            var spec = $"robocopy {src} {dst} /e";
            return CmdProcess.create(cmd(spec));
        }

        public static Task<ExecToken> zip(IWfChannel channel, ArchiveCmd cmd)
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
    }
}