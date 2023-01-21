//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppDb 
    {
        DbArchive Settings();        

        DbArchive DbSources();

        DbArchive DbSources(string scope);

        DbArchive DbRoot();

        DbArchive DbTargets();

        DbArchive DbTargets(string scope);

        DbArchive Logs();

        DbArchive Logs(string scope);
    }
}