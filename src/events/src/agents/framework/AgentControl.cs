//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public class AgentControl : AgentControl<AgentControl,IAgentContext>, IAgentControl
    {
        public AgentControl()
        {

        }

        protected override async Task Configure(IAgentContext context)
            => await sys.start(() => SummaryStats = new AgentStats(context.Members.Count()));

        Task IAgentControl.Configure(IAgentContext context)
            => Configure(context);
    }
}