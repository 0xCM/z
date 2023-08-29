//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Event(Kind)]
public readonly struct CreatingEvent : IEvent<CreatingEvent>
{
    public const string EventName = EventNames.Creating;

    public const EventKind Kind = EventKind.Creating;

    public EventId EventId {get;}

    public Type HostType {get;}

    [MethodImpl(Inline)]
    public CreatingEvent(Type host)
    {
        EventId = EventId.define(host, Kind);
        HostType = host;
    }

    public FlairKind Flair => FlairKind.Creating;

    public LogLevel EventLevel => LogLevel.Status;

    public string Format()
        => string.Format(RP.PSx2, EventId, string.Format("Creating {0}", HostType.DisplayName()));

    public override string ToString()
        => Format();
}
