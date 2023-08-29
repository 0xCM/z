//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class SourcedEvents
    {
        [MethodImpl(Inline), Op]
        public static PulseEvent pulse(uint server, uint agent, Timestamp ts)
            => new (new AgentEventKey(server, agent, ts, SourcedEventKinds.Pulse));

        [MethodImpl(Inline), Op]
        public static PulseEmitter emitter(IAgentContext context, AgentIdentity identity, PulseEmitterConfig config)
            => new (context, identity, config);

        public static T payload<T>(TraceEvent e, string name)
            => (T)e.PayloadByName(name);

        public static A adapter<A>(TraceEvent e)
            where A : TraceEventAdapter<A>, new()
        {
            var adapter = new A{
                Subject = e
            };
            return adapter;
        }
    }
}