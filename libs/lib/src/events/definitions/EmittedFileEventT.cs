// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct EmittedFileEvent<T> : ITerminalEvent<EmittedFileEvent<T>>
    {
        public const EventKind Kind = EventKind.EmittedFile;

        public FlairKind Flair => FlairKind.Ran;

        public EventId EventId {get;}

        public FS.FilePath Path {get;}

        public EventPayload<T> Payload {get;}


        [MethodImpl(Inline)]
        public EmittedFileEvent(Type host, FS.FilePath dst, T msg)
        {
            EventId = EventId.define(host, Kind);
            Payload = msg;
            Path = dst;
        }

        public string Format()
            => string.Format(RP.PSx2, EventId, Payload);

        public override string ToString()
            => Format();
    }
}