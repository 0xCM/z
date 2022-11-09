//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct StatusEvent<T> : ILevelEvent<StatusEvent<T>>
    {
        public const string EventName = GlobalEvents.Status;

        public const EventKind Kind = EventKind.Status;

        public LogLevel EventLevel => LogLevel.Status;

        public EventId EventId {get;}

        public EventPayload<T> Payload {get;}

        public FlairKind Flair {get;}

        [MethodImpl(Inline)]
        public StatusEvent(Type host, T msg, FlairKind flair)
        {
            EventId = EventId.define(host, Kind);
            Payload = msg;
            Flair = flair;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RP.PSx2, EventId, Payload);

        public override string ToString()
            => Format();

    }
}