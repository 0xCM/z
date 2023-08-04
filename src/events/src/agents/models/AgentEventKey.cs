//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines logical event identity
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct AgentEventKey
    {
        /// <summary>
        /// Constructs an event identity from a (kind,server,agent,time) tuple
        /// </summary>
        [MethodImpl(Inline)]
        public static AgentEventKey define(uint server, uint agent, Timestamp time, ulong kind)
            => new (server, agent, time, kind);

        public readonly AgentEventOrigin Origin;

        /// <summary>
        /// The event classifier/discriminator
        /// </summary>
        public readonly ulong EventKind;

        [MethodImpl(Inline)]
        public AgentEventKey(uint server, uint agent, Timestamp ts, ulong kind)
        {
            Origin = new(server,agent, ts);
            EventKind = kind;
        }

        public uint Server => Origin.Server;

        public uint Agent => Origin.Agent;

        public Timestamp Timestamp => Origin.Timestamp;
        public override string ToString()
            => $"{EventKind}/{Server}/{Agent}/{Timestamp}";
    }
}