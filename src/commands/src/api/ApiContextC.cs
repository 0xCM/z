//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiContext<C> : ApiContext 
        where C : IApiCmdSvc
    {
        public ApiContext(C commander, IWfChannel channel, IWfRuntime wf, IApiDispatcher dispatcher)
            : base(commander, channel, wf, dispatcher)
        {
            Commander = commander;
        }

        public new readonly C Commander;
    }
}