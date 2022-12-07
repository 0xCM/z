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

        public readonly IApiService Commander;

        public ApiContext(IApiService commander, IWfChannel channel, IApiDispatcher dispatcher)
        {
            Commander = commander;
            Channel = channel;
            Dispatcher = dispatcher;
        }

        IApiService IApiContext.Commander 
            => Commander;

        IWfChannel IApiContext.Channel
            => Channel;

        IApiDispatcher IApiContext.Dispatcher 
            => Dispatcher;
    }
}