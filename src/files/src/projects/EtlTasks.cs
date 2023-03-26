//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EtlTasks
    {
        readonly AppDb AppDb;

        public EtlTasks(AppDb db)
        {
            AppDb = db;
        }

        // public IProjectWorkspace EtlSource(IDbArchive src)
        //     => Projects.load(src);

        public FilePath EtlTable<T>(ProjectId project) where T : struct
            => EtlTargets(project).Table<T>(project.Format());

        public DbArchive EtlTargets(ProjectId src)
            => AppDb.DbTargets().Scoped("projects").Scoped(src.Format());
    }
}