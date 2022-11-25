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

        IApiCmdSvc Commander {get;}
    }

    public interface IApiContext<C> : IApiContext
        where C : IApiCmdSvc<C>,new()
    {
        new C Commander {get;}

        IApiCmdSvc IApiContext.Commander
            => Commander;
    }
}