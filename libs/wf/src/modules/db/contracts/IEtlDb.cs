//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEtlDb
    {
        IProjectWorkspace EtlSource(ProjectId src);

        IDbTargets EtlTargets(ProjectId src);

        FS.FilePath EtlTable<T>(ProjectId project)
            where T : struct;
    }
}