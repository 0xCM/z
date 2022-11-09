//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct RunningEvent<T> : IInitialEvent<RunningEvent<T>>
    {
        public const string EventName = GlobalEvents.Running;

        public const EventKind Kind = EventKind.Running;

        public static EventLevel Level => FlairKind.Status;

        public EventId EventId {get;}

        public StepId StepId => default;

        public EventPayload<T> Payload {get;}

        public FlairKind Flair => FlairKind.Running;

        public Type Host {get;}

        [MethodImpl(Inline)]
        public RunningEvent(Type host, T msg)
        {
            EventId = EventId.define(host, Kind);
            Host = host;
            Payload = msg;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RP.PSx2, EventId, Payload);

        public override string ToString()
            => Format();
    }
}