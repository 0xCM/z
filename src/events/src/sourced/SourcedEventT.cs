//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents an application-level/logical event with which data specific to an event class is associated
    /// </summary>
    public readonly struct SourcedEvent<T>
        where T : unmanaged
    {
        /// <summary>
        /// Reconstitutes an event from a sequence of bytes
        /// </summary>
        [MethodImpl(Inline)]
        public static SourcedEvent<T> materialize(Span<byte> src)
            => MemoryMarshal.Read<SourcedEvent<T>>(src);


        public readonly AgentEventKey EventId;

        /// <summary>
        /// Data specific to an event class
        /// </summary>
        public readonly T Payload;

        [MethodImpl(Inline)]
        public SourcedEvent(AgentEventKey id, T data)
        {
            EventId = id;
            Payload = data;
        }

        [MethodImpl(Inline)]
        public static implicit operator SourcedEvent(SourcedEvent<T> src)
            => new (src.EventId);        
    }
}