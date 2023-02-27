//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq.Expressions;

    [ApiHost]
    public class SourcedEvents
    {
        [MethodImpl(Inline), Op]
        public static IAgent sink(AgentContext context, AgentIdentity id)
            => new TraceEventSink(context,id);

        [MethodImpl(Inline), Op]
        public static PulseEvent pulse(uint server, uint agent, Timestamp ts)
            => new PulseEvent(new AgentEventId(server, agent, ts, SourcedEventKinds.Pulse));

        [MethodImpl(Inline), Op]
        public static PulseEmitter emitter(IAgentContext context, AgentIdentity identity, PulseEmitterConfig config)
            => new PulseEmitter(context, identity, config);

        public static T payload<T>(TraceEvent e, string name)
            => (T)e.PayloadByName(name);

        public static dynamic payload<T>(TraceEvent e, Expression<Func<T,dynamic>> selector)
            => e.PayloadByName(selector.GetAccessedProperty().Name);

        public static AgentEventId identify(TraceEvent data)
                => Z0.AgentEventId.define(
                payload<uint>(data, "ServerId"),
                payload<uint>(data, "AgentId"),
                payload<Timestamp>(data, "Timestamp"),
                payload<ulong>(data, "EventKind")
                );

        public static A adapter<A>(TraceEvent e)
            where A : TraceEventAdapter<A>, new()
        {
            var adapter = new A();
            adapter.Subject = e;
            return adapter;
        }
    }
}