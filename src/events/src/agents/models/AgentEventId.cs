//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines logical event identity
    /// </summary>
    public readonly struct AgentEventId
    {
        /// <summary>
        /// The originating server
        /// </summary>
        public readonly uint ServerId;

        /// <summary>
        /// The originating agent
        /// </summary>
        public readonly uint AgentId;

        /// <summary>
        /// Represents the time at which the event originated
        /// </summary>
        public readonly Timestamp Timestamp;

        /// <summary>
        /// The event classifier/discriminator
        /// </summary>
        public readonly ulong EventKind;

        /// <summary>
        /// Constructs an event identity from a (kind,server,agent,time) tuple
        /// </summary>
        [MethodImpl(Inline)]
        public static AgentEventId define(uint server, uint agent, Timestamp time, ulong kind)
            => new AgentEventId(server, agent, time, kind);

        [MethodImpl(Inline)]
        public AgentEventId(uint server, uint agent, Timestamp ts, ulong kind)
        {
            ServerId = server;
            AgentId = agent;
            Timestamp = ts;
            EventKind = kind;
        }

        public ulong Location
        {
            [MethodImpl(Inline)]
            get => ((ulong)ServerId << 32) & AgentId;
        }

        /// <summary>
        /// Specifies the spacetime event origin
        /// </summary>
        public AgentEventOrigin Origin
        {
            [MethodImpl(Inline)]
            get => (Location, Timestamp);
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out ulong kind, out uint server, out uint agent, out ulong time)
        {
            kind = EventKind;
            server = ServerId;
            agent = AgentId;
            time = Timestamp;
        }

        public override string ToString()
            => $"{EventKind}/{ServerId}/{AgentId}/{Timestamp}";
    }
}