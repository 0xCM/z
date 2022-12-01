//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiContext
    {
        IWfChannel Channel {get;}

        IApiDispatcher Dispatcher {get;}
    }

    public interface IApiContext<C> : IApiContext
        where C : IApiService<C>,new()
    {
        C Commander {get;}

    }
}