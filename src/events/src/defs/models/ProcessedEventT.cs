//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public class ProcessedEvent<T> : ITerminalEvent<ProcessedEvent<T>>
    {
        public const string EventName = GlobalEvents.Processed;

        public const EventKind Kind = EventKind.Processed;

        public EventId EventId {get;}

        public EventPayload<T> Payload {get;}

        public FlairKind Flair => FlairKind.Processed;

        public ProcessedEvent()
        {
            EventId = EventId.Empty;
            Payload = EventPayload<T>.Empty;
        }


        [MethodImpl (Inline)]
        public ProcessedEvent(StepId step, T payload)
        {
            EventId = EventId.define(EventName, step);
            Payload = payload;
        }

        [MethodImpl (Inline)]
        public string Format()
            => string.Format(RP.PSx2, EventId, Payload);

        public override string ToString()
            => Format();
    }
}