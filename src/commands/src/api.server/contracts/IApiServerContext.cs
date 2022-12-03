//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiServerContext
    {
        IWfChannel Channel {get;}

        IApiDispatcher Dispatcher {get;}

        IApiService Commander {get;}
    }

    public interface IApiServerContext<C> : IApiServerContext
        where C : IApiService<C>,new()
    {
        new C Commander {get;}

        IApiService IApiServerContext.Commander
            => Commander;

    }
}