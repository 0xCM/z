//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct BabbleEvent<T> : ILevelEvent<BabbleEvent<T>,T>
    {
        public const string EventName = GlobalEvents.Babble;

        public const EventKind Kind = EventKind.Babble;

        public LogLevel EventLevel => LogLevel.Babble;

        public EventId EventId {get;}

        public EventPayload<T> Payload {get;}

        public FlairKind Flair => FlairKind.Babble;

        [MethodImpl(Inline)]
        public BabbleEvent(Type host, T msg)
        {
            EventId = EventId.define(host, Kind);
            Payload = msg;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RpOps.PSx2, EventId, Payload);

        public override string ToString()
            => Format();

    }
}