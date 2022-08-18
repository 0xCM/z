//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct ProcessedFileEvent : ITerminalEvent<ProcessedFileEvent>
    {
        public const EventKind Kind = EventKind.ProcessedFile;

        public const string EventName = GlobalEvents.ProcessedFile;

        public EventId EventId {get;}

        public FS.FilePath SourcePath {get;}

        public FlairKind Flair => FlairKind.Processed;

        [MethodImpl(Inline)]
        public ProcessedFileEvent(Type host, FS.FilePath src)
        {
            EventId = EventId.define(host, Kind);
            SourcePath = src;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RpOps.PSx2, EventId, SourcePath.ToUri());

        public override string ToString()
            => Format();
    }
}