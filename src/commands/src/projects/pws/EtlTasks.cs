//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EtlTasks : IEtlDb
    {
        readonly AppDb AppDb;

        public EtlTasks(AppDb db)
        {
            AppDb = db;
        }

        public IProjectWorkspace EtlSource(ProjectId src)
            => Projects.load(AppDb.Dev($"llvm.models/{src}"), src);

        public FilePath EtlTable<T>(ProjectId project) where T : struct
            => EtlTargets(project).Table<T>(project.Format());

        public DbArchive EtlTargets(ProjectId src)
            => AppDb.DbOut().Scoped("projects").Scoped(src.Format());
    }
}