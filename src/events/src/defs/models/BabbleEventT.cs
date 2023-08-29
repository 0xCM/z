//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Event(Kind)]
public readonly struct BabbleEvent<T> : IEvent<BabbleEvent<T>>
{
    public const string EventName = EventNames.Babble;

    public const EventKind Kind = EventKind.Babble;

    public EventId EventId {get;}

    public EventPayload<T> Payload {get;}

    [MethodImpl(Inline)]
    public BabbleEvent(Type host, T msg)
    {
        EventId = EventId.define(host, Kind);
        Payload = msg;
    }

    public LogLevel EventLevel => LogLevel.Babble;

    public FlairKind Flair => FlairKind.Babble;

    [MethodImpl(Inline)]
    public string Format()
        => string.Format(RP.PSx2, EventId, Payload);

    public override string ToString()
        => Format();
}
