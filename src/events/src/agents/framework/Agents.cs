//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class Agents
    {
        public static AgentContext context(IAgentEventSink sink, params IAgentMachine[] machines)
        {
            var context = new AgentContext(sink);
            sys.iter(machines,context.Register);
            return context;
        }

        public static T payload<T>(TraceEvent e, string name)
            => (T)e.PayloadByName(name);

        public static AgentEventKey key(TraceEvent data)
                => AgentEventKey.define(
                payload<uint>(data, "ServerId"),
                payload<uint>(data, "AgentId"),
                payload<Timestamp>(data, "Timestamp"),
                payload<ulong>(data, "EventKind")
                );

        public static IAgentControl control(IAgentContext context)
            => AgentControl.create(context);

        [MethodImpl(Inline), Op]
        public static IAgentMachine tracer(AgentContext context, AgentIdentity id)
            => new AgentTracer(context,id);

        /// <summary>
        /// Creates and configures, but does not start, a server process
        /// </summary>
        /// <param name="context">The context to which the server process will be assigned</param>
        /// <param name="server">The server id</param>
        /// <param name="agents">The agents to be managed on behalf of the server</param>
        public static AgentProcess process(IAgentContext context, uint server, uint core, params IAgentMachine[] agents)
            => new (context, server, core, agents);

        public static AgentServer server(IAgentContext context, AgentServerConfig config)
            => new (context, config);

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

            var eventSink = tracer(context, (complex.Part, complex.HostId));
            complex.Configure(configs, eventSink);
            await complex.Start();
            AgentComplex.Complex = complex;
            return complex;
        }
    }
}