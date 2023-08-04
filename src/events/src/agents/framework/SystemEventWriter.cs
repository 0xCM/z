//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics.Tracing;

    [EventSource(Name = SourceName)]
    public sealed class SystemEventWriter : SourcedEventWriter, IAgentEventSink<PulseEvent>
    {
        public const string SourceName = "zsyn/system-events";

        public static readonly IAgentEventSink Log = new SystemEventWriter();

        internal SystemEventWriter()
        {

        }

        protected override void OnEventCommand(EventCommandEventArgs command)
            => term.inform($"Received the {command.Command} command");

        void Pulse(ulong EventKind, uint ServerId, uint AgentId, ulong Timestamp)
            => WriteEvent(1, EventKind, ServerId, AgentId, Timestamp);

        void AgentTransitioned(ulong EventKind, uint ServerId, uint AgentId, ulong Timestamp, byte[] Body)
            => WriteEvent(2, EventKind, ServerId, AgentId, Timestamp, Body);

        /// <summary>
        /// Writes a system heartbeat event
        /// </summary>
        /// <param name="e">The event to write</param>
        public void Receive(PulseEvent e)
            => Pulse(e.Identity.EventKind, e.Identity.Server, e.Identity.Agent, e.Identity.Timestamp);

        public void Receive(object o)
        {
            if(o is PulseEvent e)
                Receive(e);
        }

        public void AgentTransitioned(AgentTransition data)
            => AgentTransitioned(2, data.Agent.PartId, data.Agent.HostId, data.Timestamp, sys.bytes(data).ToArray());
    }
}