//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Uniquely identifies an agent throughout a server complex
    /// </summary>
    public readonly struct AgentIdentity
    {
        /// <summary>
        /// Specifies the agent's defining assembly
        /// </summary>
        public readonly uint PartId;

        /// <summary>
        /// Specifies the agent's reifying type
        /// </summary>
        public readonly uint HostId;

        [MethodImpl(Inline)]
        public AgentIdentity(uint server, uint agent)
        {
            PartId = server;
            HostId = agent;
        }

        [MethodImpl(Inline)]
        public AgentIdentity(ulong id)
        {
            PartId = (uint)(id >> 32);
            HostId = (uint)(id);
        }

        /// <summary>
        /// Uniquely identifies an agent by composing the host on which it resides
        /// and the host-relative identifier
        /// </summary>
        public readonly ulong Identifier
        {
            [MethodImpl(Inline)]
            get => ((ulong)PartId << 32) | HostId;
        }

        public string Format()
            =>$"{PartId}/{HostId}";

        public override string ToString()
            => Format();

        /// <summary>
        /// Constructs an identity from server and agent id's
        /// </summary>
        /// <param name="loc">The agent server</param>
        /// <param name="time">The time of occurrence</param>
        [MethodImpl(Inline)]
        public static implicit operator AgentIdentity((uint server, uint agent) src)
            => new AgentIdentity(src.server,src.agent);

        [MethodImpl(Inline)]
        public static implicit operator ulong(AgentIdentity identity)
            => identity.Identifier;
    }
}