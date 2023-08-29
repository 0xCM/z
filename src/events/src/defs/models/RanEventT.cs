//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct RanEvent<T> : IEvent<RanEvent<T>>
    {
        const EventKind Kind = EventKind.Ran;

        public FlairKind Flair => FlairKind.Ran;

        public EventId EventId {get;}

        public EventPayload<T> Payload {get;}

        public Type Host {get;}

        public LogLevel EventLevel => LogLevel.Status;

        [MethodImpl(Inline)]
        public RanEvent(Type host, T msg)
        {
            EventId = EventId.define(host, Kind);
            Payload = msg;
            Host = host;
        }

        [MethodImpl(Inline)]
        public RanEvent(RunningEvent<T> e, T msg = default)
        {
            EventId = e.EventId;
            Host = e.Host;
            Payload = msg;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RP.PSx2, EventId, Payload);


        public override string ToString()
            => Format();
    }
}