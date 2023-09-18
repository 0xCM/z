//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct EmittingTableEvent<T> : IEvent<EmittingTableEvent<T>>
    {
        public const string EventName = EventNames.EmittingTable;

        public const EventKind Kind = EventKind.EmittingTable;

        public EventId EventId {get;}

        public FilePath Target {get;}

        public readonly string HostName;

        public FlairKind Flair => FlairKind.Running;

        public TableId Table => Tables.identify<T>();

        [MethodImpl(Inline)]
        public EmittingTableEvent(Type host, FilePath dst)
        {
            HostName = host.DisplayName();
            EventId = EventId.define(host, Kind);
            Target = dst;
        }

        public LogLevel EventLevel => LogLevel.Status;

        [MethodImpl(Inline)]
        public string Format()
            => TextPatterns.piped(EventId, AppMsgs.EmittingTable.Capture(Table, Target));

        public override string ToString()
            => Format();
    }
}