//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct CreatedEvent : ITerminalEvent<CreatedEvent>
    {
        public const string EventName = GlobalEvents.Created;

        public const EventKind Kind = EventKind.Created;

        public FlairKind Flair  => FlairKind.Created;

        public EventId EventId {get;}

        public Type HostType {get;}

        [MethodImpl(Inline)]
        public CreatedEvent(Type host)
        {
            EventId = EventId.define(host, Kind);
            HostType = host;
        }

        [MethodImpl(Inline)]
        public CreatedEvent(CreatingEvent prior)
        {
            EventId = prior.EventId;
            HostType = prior.HostType;
        }

        public string Format()
            => string.Format(RP.PSx2, EventId, string.Format("Created {0}", HostType.DisplayName()));

        public override string ToString()
            => Format();

    }
}