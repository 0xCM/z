//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a pulse/tick/heartbeat relative to some frequency
    /// </summary>
    public readonly struct PulseEvent
    {
        public AgentEventKey Identity {get;}

        internal PulseEvent(AgentEventKey id)
            => Identity = id;
    }
}