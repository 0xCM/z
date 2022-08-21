//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppDb : IEtlDb
    {
        IDbArchive Settings();        

        IDbArchive DbIn();

        IDbArchive DbRoot();

        IDbArchive DbIn(string scope);

        IDbArchive DbOut();

        IDbArchive DbOut(string scope);

        IDbArchive Logs();

        IDbArchive Logs(string scope);
    }
}