//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO.Compression;

    using static sys;

    public class EtlTasks : IEtlDb
    {
        const string group = "db";

        public static Task<ExecToken> robocopy(IWfChannel channel, FolderPath src, FolderPath dst)
        {
            var cmd = new CmdLine($"robocopy {src} {dst} /e");
            var running = channel.Running(cmd);
            
            ExecToken run()
            {
                ProcessControl.start(cmd).Wait();
                return channel.Ran(running); 
            }

            return @try(run, e => channel.Completed(running, typeof(EtlTasks), e));
        }

        public static Task<ExecToken> zip(IWfChannel channel, FolderPath src, FilePath dst)
        {
            var uri = $"{app}://{group}/zip";
            var running = channel.Running(uri);

            ExecToken run()
            {
                ZipFile.CreateFromDirectory(src.Format(), dst.Format(), CompressionLevel.Fastest, true);
                return channel.Ran(running, uri); 
            }

            return @try(run, e => channel.Completed(running, typeof(EtlTasks), e));
        }


        readonly AppDb AppDb;

        public EtlTasks(AppDb db)
        {
            AppDb = db;
        }

        public IProjectWorkspace EtlSource(ProjectId src)
            => Projects.load(AppDb.Dev($"llvm.models/{src}").Root, src);

        public FilePath EtlTable<T>(ProjectId project) where T : struct
            => EtlTargets(project).Table<T>(project.Format());

        public DbArchive EtlTargets(ProjectId src)
            => AppDb.DbOut().Scoped("projects").Scoped(src.Format());
    }
}