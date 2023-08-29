//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Event(Kind)]
public readonly struct DataEvent<T> : IEvent<DataEvent<T>>
{
    const string EventName = EventNames.Data;

    const EventKind Kind = EventKind.Data;

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

    public LogLevel EventLevel => LogLevel.Status;

    [MethodImpl(Inline)]
    public string Format()
        => string.Format("# {0}", Payload);

    public override string ToString()
        => Format();
}
