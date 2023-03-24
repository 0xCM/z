//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public class ApiContext : IApiContext
    {
        public readonly ICmdDispatcher Dispatcher;

        public readonly IApiService Commander;

        public ApiContext(IApiService commander, IWfChannel channel, ICmdDispatcher dispatcher)
        {
            Commander = commander;
            Dispatcher = dispatcher;
        }

        IApiService IApiContext.Commander 
            => Commander;

        ICmdDispatcher IApiContext.Dispatcher 
            => Dispatcher;
    }
}