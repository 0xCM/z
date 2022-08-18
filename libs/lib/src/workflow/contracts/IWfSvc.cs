//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfSvc : IAppService
    {
        WfEmit Emitter {get;}
    }

    public interface IWfSvc<S> : IWfSvc, IAppService<S>
        where S : IWfSvc<S>, new()
    {

    }
}