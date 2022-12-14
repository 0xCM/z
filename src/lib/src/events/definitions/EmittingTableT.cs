//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct EmittingTableEvent<T> : IInitialEvent<EmittingTableEvent<T>>
        where  T : struct
    {
        public const string EventName = GlobalEvents.EmittingTable;

        public const EventKind Kind = EventKind.EmittingTable;

        public EventId EventId {get;}

        public FilePath Target {get;}

        public readonly string HostName;

        public FlairKind Flair => FlairKind.Running;

        public TableId Table => TableId.identify<T>();

        [MethodImpl(Inline)]
        public EmittingTableEvent(Type host, FilePath dst)
        {
            HostName = host.DisplayName();
            EventId = EventId.define(host, Kind);
            Target = dst;
        }

        [MethodImpl(Inline)]
        public string Format()
            => RpOps.format(EventId, AppMsg.EmittingTable.Capture(Table, Target));

        public override string ToString()
            => Format();
    }
}