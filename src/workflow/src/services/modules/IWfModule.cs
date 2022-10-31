//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfModule : IWfSvc
    {
        
    }

    public interface IWfModule<M> : IWfModule, IWfSvc<M>
        where M : IWfModule<M>, new()
    {

    }
}
