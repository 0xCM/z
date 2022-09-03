//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Defines a logical server
    /// </summary>
    public class AgentServer : Agent
    {
        AgentServerConfig Config {get;}

        AgentProcess Worker {get; }

        internal AgentServer(IAgentContext context, AgentServerConfig config)
            : base(context, (config.ServerId, 0u))
        {
            Config = config;
            var pulse =  SourcedEvents.emitter(context,
                AgentIdentityPool.NextAgentId(PartId),
                new PulseEmitterConfig(new TimeSpan(0,0,1)));
            Worker = Agents.process(context, PartId, config.CoreNumber, new IAgent[]{pulse});
        }

        protected override async void OnStart()
            => await Worker.Start();

        protected override async void OnStop()
            => await Worker.Stop();
    }
}