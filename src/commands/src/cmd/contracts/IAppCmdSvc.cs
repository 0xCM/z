//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppCmdSvc : IAppService, ICmdProvider, ICmdRunner, IRunnable
    {     
        IWfDispatcher Dispatcher {get;}    
    }
}