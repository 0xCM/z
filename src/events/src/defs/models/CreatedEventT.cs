//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Event(Kind)]
public readonly struct CreatedEvent<T> : IEvent<CreatedEvent<T>>
{
    public const EventKind Kind = EventKind.Created;

    public FlairKind Flair => FlairKind.Created;

    public EventId EventId {get;}

    public Type HostType {get;}

    public EventPayload<T> Payload {get;}

    [MethodImpl(Inline)]
    public CreatedEvent(T data, Type host)
    {
        EventId = EventId.define(host, Kind);
        Payload = data;
        HostType = host;
    }

    [MethodImpl(Inline)]
    public CreatedEvent(T data, CreatingEvent prior)
    {
        Payload = data;
        EventId = prior.EventId;
        HostType = prior.HostType;
    }

    public LogLevel EventLevel => LogLevel.Status;

    public string Format()
        => string.Format(RP.PSx2, EventId, string.Format("Created {0}", Payload));

    public override string ToString()
        => Format();

}
