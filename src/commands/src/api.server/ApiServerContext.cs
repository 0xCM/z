//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public class ApiServerContext : IApiServerContext
    {
        public readonly IWfChannel Channel;

        public readonly IApiDispatcher Dispatcher;

        public readonly IApiService Commander;

        public ApiServerContext(IApiService commander, IWfChannel channel, IApiDispatcher dispatcher)
        {
            Commander = commander;
            Channel = channel;
            Dispatcher = dispatcher;
        }

        IApiService IApiServerContext.Commander 
            => Commander;

        IWfChannel IApiServerContext.Channel
            => Channel;

        IApiDispatcher IApiServerContext.Dispatcher 
            => Dispatcher;
    }
}