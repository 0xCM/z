//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a logical server
    /// </summary>
    public class AgentServer : AgentMachine
    {
        AgentProcess Worker {get; }

        internal AgentServer(IAgentContext context, AgentServerConfig config)
            : base(context, (config.ServerId, 0u))
        {
            var pulse =  SourcedEvents.emitter(context,
                AgentIdentityPool.NextAgentId(Part),
                new PulseEmitterConfig(new TimeSpan(0,0,1)));
            Worker = Agents.process(context, Part, config.CoreNumber, pulse);
        }

        protected override async Task Starting()
            => await Worker.Start();

        protected override async Task Stopping()
            => await Worker.Stop();
    }
}