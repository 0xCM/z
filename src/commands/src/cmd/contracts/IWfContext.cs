//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfContext
    {
        IWfChannel Channel {get;}

        IWfRuntime Runtime {get;}

        IApiDispatcher Dispatcher {get;}

        IApiCmdSvc Commander {get;}
    }

    public interface IWfContext<C> : IWfContext
        where C : IApiCmdSvc
    {
        new C Commander {get;}

        IApiCmdSvc IWfContext.Commander
            => Commander;
    }
}
