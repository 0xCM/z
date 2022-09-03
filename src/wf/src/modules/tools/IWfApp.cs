//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfApp : IAppService
    {
        void Run();

        void Run(string[] args);
    }

    public interface IWfApp<A> : IAppService<A>, IWfApp
        where A : IWfApp<A>, new()
    {

    }
}