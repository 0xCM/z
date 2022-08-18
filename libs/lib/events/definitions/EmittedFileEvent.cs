// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct EmittedFileEvent : ITerminalEvent<EmittedFileEvent>
    {
        public const EventKind Kind = EventKind.EmittedFile;

        public FlairKind Flair => FlairKind.Ran;

        public EventId EventId {get;}

        public FS.FilePath Path {get;}

        public Count LineCount {get;}

        [MethodImpl(Inline)]
        public EmittedFileEvent(Type host, FS.FilePath dst, Count count = default)
        {
            EventId = EventId.define(host, Kind);
            LineCount = count;
            Path = dst;
        }

        public string Format()
            => LineCount != 0
            ? RpOps.format(EventId, AppMsg.EmittedFileLines.Capture(LineCount,Path))
            : RpOps.format(EventId, AppMsg.EmittedFile.Capture(Path));

        public override string ToString()
            => Format();
    }
}