//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a pulse/tick/heartbeat relative to some frequency
    /// </summary>
    public readonly struct PulseEvent : IAgentEvent
    {
        public AgentEventId Identity {get;}

        internal PulseEvent(AgentEventId id)
            => Identity = id;
    }
}