//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WfContext<C> : WfContext 
        where C : IAppCmdSvc
    {
        public WfContext(C commander, IWfChannel channel, IWfRuntime wf, IWfDispatcher dispatcher)
            : base(commander, channel, wf, dispatcher)
        {
            Commander = commander;
        }

        public new readonly C Commander;
    }
}