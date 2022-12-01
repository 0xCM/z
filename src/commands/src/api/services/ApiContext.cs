//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public class ApiContext : IApiContext
    {
        public readonly IWfChannel Channel;

        public readonly IApiDispatcher Dispatcher;

        public ApiContext(IApiService commander, IWfChannel channel, IApiDispatcher dispatcher)
        {
            Channel = channel;
            Dispatcher = dispatcher;
        }

        IWfChannel IApiContext.Channel
            => Channel;

        IApiDispatcher IApiContext.Dispatcher 
            => Dispatcher;
    }
}