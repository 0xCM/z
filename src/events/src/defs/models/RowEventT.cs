//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct RowEvent<T> : IWfEvent<RowEvent<T>,T>
    {
        const string EventName = GlobalEvents.Row;

        const EventKind Kind = EventKind.Row;

        public EventId EventId {get;}

        public EventPayload<T> Payload {get;}

        public FlairKind Flair {get;}

        [MethodImpl(Inline)]
        public RowEvent(T data, FlairKind flair)
        {
            EventId = EventName;
            Payload = data;
            Flair = flair;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Payload.Format();

        public override string ToString()
            => Format();
    }
}