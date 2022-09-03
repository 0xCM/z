//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct ErrorEvent<T> : ILevelEvent<ErrorEvent<T>,T>, IErrorEvent
    {
        public const string EventName = GlobalEvents.Error;

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
            dst.AppendLine(string.Format(RpOps.PSx2, EventId, Origin));
            dst.AppendLine($"{Payload}");
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [Op]
        static void format(Exception e0, ErrorEvent<T> error, ITextEmitter dst)
        {
            const string ErrorTrace = "{0} | {1} | {2} | Outer | {3} | {4} | {5}";
            const string InnerTrace = "{0} | {1} | {2} | Inner | {3} | {4} | {5} | {6}";

            var exception = error.Payload;
            var eType = exception.GetType();
            var outer = sys.format(ErrorTrace, error.EventId, error.Payload, error.Origin, eType.Name, e0.Message, e0.StackTrace);
            dst.AppendLine(outer);

            int level = 0;

            var e1 = e0.InnerException;
            while (e1 != null)
            {
                dst.AppendLine(sys.format(InnerTrace, error.EventId, error.Payload, error.Origin, level, eType.Name, e1.Message, e1.StackTrace));
                e1 = e1.InnerException;
                level += 1;
            }
        }
    }
}