//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppDb : IDbSettings, IEtlDb
    {
        IDbSources DbIn();

        IDbArchive DbRoot();

        IDbSources DbIn(string scope);

        IDbTargets DbOut();

        IDbTargets DbOut(string scope);

        IDbTargets Logs();

        IDbTargets Logs(string scope);
    }
}