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
}