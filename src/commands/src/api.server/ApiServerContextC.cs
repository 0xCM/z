//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class ApiServerContext<C> : ApiServerContext, IApiServerContext<C>
        where C : IApiService<C>,new()
    {
        public ApiServerContext(C commander, IWfChannel channel, IApiDispatcher dispatcher)
            : base(commander, channel, dispatcher)
        {
            Commander = commander;
        }

        public new readonly C Commander;

        C IApiServerContext<C>.Commander
            => Commander;
    }
}