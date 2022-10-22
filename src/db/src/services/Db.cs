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

        public static Task<ExecToken> robocopy(IWfChannel channel, FolderPath src, FolderPath dst)
            => ProcessControl.start(channel, $"robocopy {src} {dst} /e");

        public static Task<ExecToken> zip(IWfChannel channel, FolderPath src, FilePath dst)
        {
            var uri = $"{app}://{group}/zip";
            var running = channel.Running(uri);

            ExecToken run()
            {
                ZipFile.CreateFromDirectory(src.Format(), dst.Format(), CompressionLevel.Fastest, true);
                return channel.Ran(running, uri); 
            }

            return @try(run, e => channel.Completed(running, typeof(Db), e));                                                    
        }
    }
}