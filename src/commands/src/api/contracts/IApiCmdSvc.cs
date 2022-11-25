//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiCmdSvc : IAppService, IApiCmdProvider, IRunLoop
    {     

    }

    public interface IApiCmdSvc<C> : IApiCmdSvc
        where C : IApiCmdSvc<C>,new()
    {
        
    }    
}