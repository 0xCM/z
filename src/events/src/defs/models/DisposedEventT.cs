//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Event(Kind)]
public readonly struct Disposed<T> : IEvent<Disposed<T>>
{
    public const EventKind Kind = EventKind.Disposed;

    public EventId EventId {get;}

    public EventPayload<T> Payload {get;}

    public FlairKind Flair => FlairKind.Disposed;

    [MethodImpl(Inline)]
    public Disposed(Type host, T msg)
    {
        EventId = EventId.define(host, Kind);
        Payload = msg;
    }

    public LogLevel EventLevel => LogLevel.Babble;

    [MethodImpl(Inline)]
    public string Format()
        => string.Format(RP.PSx2, EventId, Payload);

    public override string ToString()
        => Format();
}
