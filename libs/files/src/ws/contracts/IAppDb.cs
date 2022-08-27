//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppDb : IEtlDb
    {
        DbArchive Settings();        

        DbArchive DbIn();

        DbArchive DbRoot();

        DbArchive DbIn(string scope);

        DbArchive DbOut();

        DbArchive DbTargets(string scope);

        DbArchive Logs();

        DbArchive Logs(string scope);
    }
}