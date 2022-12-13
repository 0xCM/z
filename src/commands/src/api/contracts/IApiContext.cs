//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiContext
    {
        IWfChannel Channel {get;}

        ICmdDispatcher Dispatcher {get;}

        IApiService Commander {get;}
    }

    public interface IApiContext<C> : IApiContext
        where C : IApiService<C>,new()
    {
        new C Commander {get;}

        IApiService IApiContext.Commander
            => Commander;
    }
}