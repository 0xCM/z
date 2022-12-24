//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct EmittingFileEvent : IInitialEvent<EmittingFileEvent>
    {
        public const EventKind Kind = EventKind.EmittingFile;

        public EventId EventId {get;}

        public FilePath Target {get;}

        public FlairKind Flair => FlairKind.Running;

        [MethodImpl(Inline)]
        public EmittingFileEvent(Type host, FilePath dst)
        {
            EventId = EventId.define(host, Kind);
            Target = dst;
        }

        public string Format()
            => RP.format(EventId, AppMsg.EmittingFile.Capture(Target));
    }
}