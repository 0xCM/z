//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct WarnEvent<T> : ILevelEvent<WarnEvent<T>,T>
    {
        public const string EventName = GlobalEvents.Warning;

        public LogLevel EventLevel => LogLevel.Warning;

        public const EventKind Kind = EventKind.Warning;

        public EventId EventId {get;}

        public EventPayload<T> Payload {get;}

        public FlairKind Flair => FlairKind.Warning;

        [MethodImpl(Inline)]
        public WarnEvent(Type host, T msg)
        {
            EventId = EventId.define(host, Kind);
            Payload = msg;
        }
        public string Format()
            => string.Format(RP.PSx2, EventId, Payload);

        public override string ToString()
            => Format();
    }
}