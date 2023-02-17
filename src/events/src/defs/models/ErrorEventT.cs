//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct ErrorEvent<T> : ILevelEvent<ErrorEvent<T>,T>, IErrorEvent
    {
        public const EventKind Kind = EventKind.Error;

        public LogLevel EventLevel => LogLevel.Error;

        public FlairKind Flair => FlairKind.Error;

        public EventId EventId {get;}

        public Option<Exception> Exception {get;}

        public EventOrigin Origin {get;}

        public EventPayload<T> Payload {get;}

        [MethodImpl(Inline)]
        public ErrorEvent(Type host, T msg, EventOrigin source)
        {
            EventId = EventId.define(host, Kind);
            Exception = Option.none<Exception>();
            Payload = msg;
            Origin = source;
        }

        [MethodImpl(Inline)]
        public ErrorEvent(Type host, Exception error, T msg, EventOrigin source)
        {
            EventId = EventId.define(host, Kind);
            Exception = error;
            Payload = msg;
            Origin = source;
        }

        public string Format()
        {
            var dst = text.emitter();
            dst.AppendLine(string.Format(RP.PSx2, EventId, Origin));
            dst.AppendLine($"{Payload}");
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}