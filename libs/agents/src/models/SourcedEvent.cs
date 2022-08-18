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
        public readonly AgentEventId EventId;

        [MethodImpl(Inline)]
        public static SourcedEvent define(AgentEventId id)
            => new SourcedEvent(id);

        [MethodImpl(Inline)]
        public static SourcedEvent<T> define<T>(AgentEventId id, T data)
            where T : unmanaged
            => new SourcedEvent<T>(id, data);

        [MethodImpl(Inline)]
        public SourcedEvent(AgentEventId id)
            => EventId = id;
    }
}