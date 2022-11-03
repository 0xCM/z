//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EtlTasks : IEtlDb
    {
        public static Task<ExecToken> robocopy(IWfChannel channel, FolderPath src, FolderPath dst)
        {
            var cmd = new CmdLine($"robocopy {src} {dst} /e");
            var args = Cmd.args(src, dst, "/e");            
            return ProcessControl.start(channel, FS.path("robocopy.exe"), args);
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