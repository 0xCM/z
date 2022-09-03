//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures an instant in time with respect to a server/agent,
    /// real or simulated
    /// </summary>
    public readonly struct AgentEventOrigin
    {
        /// <summary>
        /// Uniquely identifies the logical event source
        /// </summary>
        public readonly ulong Location;

        /// <summary>
        /// The time of occurrence, expressed as number of elapsed ticks
        /// from some fixed point in time
        /// </summary>
        public readonly Timestamp Timestamp;

        [MethodImpl(Inline)]
        public AgentEventOrigin(uint server, uint agent, Timestamp ts)
        {
            Location = ((ulong)server << 32) | agent;
            Timestamp = ts;
        }

        [MethodImpl(Inline)]
        public AgentEventOrigin(ulong location, Timestamp ts)
        {
            Location = location;
            Timestamp = ts;
        }

        /// <summary>
        /// The originating server
        /// </summary>
        public uint Server
        {
            [MethodImpl(Inline)]
            get => (uint)(Location >> 32);
        }

        /// <summary>
        /// The originating agent / application
        /// </summary>
        public uint Agent
        {
            [MethodImpl(Inline)]
            get => (uint) Location;
        }

        /// <summary>
        /// Constructs an origin from an ordered pair of location and timestamp
        /// </summary>
        /// <param name="loc">The location of occurrence</param>
        /// <param name="time">The time of occurrence</param>
        [MethodImpl(Inline)]
        public static implicit operator AgentEventOrigin((ulong loc, Timestamp time) src)
            => new AgentEventOrigin(src.loc,src.time);

        /// <summary>
        /// Constructs an origin from an ordered triple of server, agent and timestamp
        /// </summary>
        /// <param name="loc">The location of occurrence</param>
        /// <param name="time">The time of occurrence</param>
        [MethodImpl(Inline)]
        public static implicit operator AgentEventOrigin((uint server, uint agent, Timestamp time) src)
            => new AgentEventOrigin(src.server, src.agent, src.time);
    }
}