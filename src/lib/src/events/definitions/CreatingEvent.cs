//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct CreatingEvent : IInitialEvent<CreatingEvent>
    {
        public const string EventName = GlobalEvents.Creating;

        public const EventKind Kind = EventKind.Creating;

        public EventId EventId {get;}

        public FlairKind Flair => FlairKind.Creating;

        public Type HostType {get;}

        [MethodImpl(Inline)]
        public CreatingEvent(Type host)
        {
            EventId = EventId.define(host, Kind);
            HostType = host;
        }

        public string Format()
            => string.Format(RpOps.PSx2, EventId, string.Format("Creating {0}", HostType.DisplayName()));

        public override string ToString()
            => Format();
    }
}