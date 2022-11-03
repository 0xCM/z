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

        IWfDispatcher Dispatcher {get;}

        IAppCmdSvc Commander {get;}
    }

    public interface IWfContext<C> : IWfContext
        where C : IAppCmdSvc
    {
        new C Commander {get;}

        IAppCmdSvc IWfContext.Commander
            => Commander;
    }
}
