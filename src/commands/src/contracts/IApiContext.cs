//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiContext
    {
        ICmdDispatcher Dispatcher {get;}

        IApiService Commander {get;}
    }
}