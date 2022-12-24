//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IChanneled : IService
    {
        IWfChannel Channel {get;}
    }

    public interface IChanneled<C> : IChanneled, IService<C>
        where C : IChanneled<C>, new()
    {

    }
}