//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct DisposedEvent : ITerminalEvent<DisposedEvent>
    {
        public const string EventName = GlobalEvents.Disposed;

        public const EventKind Kind = EventKind.Disposed;

        public EventId EventId {get;}

        public FlairKind Flair => FlairKind.Disposed;

        [MethodImpl(Inline)]
        public DisposedEvent(Type host)
        {
            EventId = EventId.define(host, Kind);
        }

        public string Format()
            => EventId.Format();

        public override string ToString()
            => Format();
    }
}