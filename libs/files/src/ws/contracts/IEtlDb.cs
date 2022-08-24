//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEtlDb
    {
        IProjectWorkspace EtlSource(ProjectId src);

        DbArchive EtlTargets(ProjectId src);

        FS.FilePath EtlTable<T>(ProjectId project)
            where T : struct;
    }
}