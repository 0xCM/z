//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct DataEvent<T> : IWfEvent<DataEvent<T>,T>
    {
        public const string EventName = GlobalEvents.Data;

        public const EventKind Kind = EventKind.Data;

        public EventId EventId {get;}

        public EventPayload<T> Payload {get;}

        public FlairKind Flair {get;}

        [MethodImpl(Inline)]
        public DataEvent(T data)
        {
            EventId = EventName;
            Payload = data;
            Flair = FlairKind.Data;
        }

        [MethodImpl(Inline)]
        public DataEvent(T data, FlairKind flair)
        {
            EventId = EventName;
            Payload = data;
            Flair = flair;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format("# {0}", Payload);

        public override string ToString()
            => Format();

    }
}