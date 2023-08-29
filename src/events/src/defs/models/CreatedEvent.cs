//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Event(Kind)]
public readonly struct CreatedEvent : IEvent<CreatedEvent>
{
    public const string EventName = EventNames.Created;

    public const EventKind Kind = EventKind.Created;

    public EventId EventId {get;}

    public Type HostType {get;}

    [MethodImpl(Inline)]
    public CreatedEvent(Type host)
    {
        EventId = EventId.define(host, Kind);
        HostType = host;
    }

    [MethodImpl(Inline)]
    public CreatedEvent(CreatingEvent prior)
    {
        EventId = prior.EventId;
        HostType = prior.HostType;
    }

    public FlairKind Flair  => FlairKind.Created;


    public LogLevel EventLevel => LogLevel.Status;

    public string Format()
        => string.Format(RP.PSx2, EventId, string.Format("Created {0}", HostType.DisplayName()));

    public override string ToString()
        => Format();
}