//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class Agents : WfSvc<Agents>
    {
        public static IAgentControl control(IAgentContext context)
            => AgentControl.create(context);

        public AgentRunner Runner()
        {
            var log = new SystemEventWriter();
            var signal = Events.signal(Wf.EventSink, GetType());
            var runner = new AgentRunner(signal, new AgentContext(log));
            return runner;
        }

        /// <summary>
        /// Creates and configures, but does not start, a server process
        /// </summary>
        /// <param name="context">The context to which the server process will be assigned</param>
        /// <param name="server">The server id</param>
        /// <param name="agents">The agents to be managed on behalf of the server</param>
        public static AgentProcess process(IAgentContext context, uint server, uint core, params IAgent[] agents)
            => new AgentProcess(context, server, core, agents);

        public static AgentServer server(IAgentContext context, AgentServerConfig config)
            => new AgentServer(context, config);

        /// <summary>
        /// Starts a new complex or returns the existing complex
        /// </summary>
        /// <param name="context">The context that the complex will inherit</param>
        /// <param name="servers"></param>
        public static async Task<AgentComplex> complex(AgentContext context)
        {
            if(AgentComplex.Complex.IsSome())
                return AgentComplex.Complex.ValueOrDefault();

            var servers = 40;
            var complex = new AgentComplex(context);
            var configs = list<AgentServerConfig>();
            var processors = Environment.ProcessorCount;

            term.inform($"Server complex using {processors} processor cores");

            for(uint i = 0, corenum = 1; i <= servers; i++, corenum++)
            {
                var sid = AgentIdentityPool.NextServerId();
                var config = new AgentServerConfig(sid, $"Server{sid}", corenum);
                term.babble($"Defined configuration for {config}");
                configs.Add(config);
                if(corenum == processors)
                    corenum = 0;
            }

            var eventSink = SourcedEvents.sink(context, (complex.PartId, complex.HostId));
            complex.Configure(configs, eventSink);
            await complex.Start();
            AgentComplex.Complex = complex;
            return complex;
        }
    }
}