//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ExecutionContext : IExecutionContext
    {
        public readonly IWfRuntime Wf;

        public readonly IWfChannel Channel;

        public ExecutionContext(IWfRuntime wf, IWfChannel channel)
        {
            Wf = wf;
            Channel = channel;
        }

        IWfRuntime IExecutionContext.Wf 
            => Wf;

        IWfChannel IExecutionContext.Channel 
            => Channel;
    }
}