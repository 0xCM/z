// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Event(Kind)]
public readonly struct EmittedFileEvent<T> : IEvent<EmittedFileEvent<T>>
{
    public const EventKind Kind = EventKind.EmittedFile;

    public EventId EventId {get;}

    public FilePath Path {get;}

    public EventPayload<T> Payload {get;}

    [MethodImpl(Inline)]
    public EmittedFileEvent(Type host, FilePath dst, T msg)
    {
        EventId = EventId.define(host, Kind);
        Payload = msg;
        Path = dst;
    }

    public FlairKind Flair => FlairKind.Ran;

    public LogLevel EventLevel => LogLevel.Status;

    public string Format()
        => string.Format(RP.PSx2, EventId, Payload);

    public override string ToString()
        => Format();
}
