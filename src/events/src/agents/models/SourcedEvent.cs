//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies an application-level/logical event
    /// </summary>
    public readonly struct SourcedEvent
    {
        public readonly AgentEventKey EventId;

        [MethodImpl(Inline)]
        public static SourcedEvent define(AgentEventKey id)
            => new (id);

        [MethodImpl(Inline)]
        public static SourcedEvent<T> define<T>(AgentEventKey id, T data)
            where T : unmanaged
            => new (id, data);

        [MethodImpl(Inline)]
        public SourcedEvent(AgentEventKey id)
            => EventId = id;
    }
}