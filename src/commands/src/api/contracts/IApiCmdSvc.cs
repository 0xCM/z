//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRunLoop
    {
        void Loop();
    }
    
    public interface IApiCmdSvc : IAppService, IApiCmdProvider, IRunLoop
    {     
        IApiDispatcher Dispatcher {get;}    
    }
}