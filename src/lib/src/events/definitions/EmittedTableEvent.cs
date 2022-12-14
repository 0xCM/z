//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    [Event(Kind)]
    public readonly struct EmittedTableEvent : ITerminalEvent<EmittedTableEvent>
    {
        public const EventKind Kind = EventKind.EmittedTable;

        public EventId EventId {get;}

        public TableId TableId {get;}

        public Count RowCount {get;}

        public FilePath Target {get;}

        public FlairKind Flair => FlairKind.Ran;

        [MethodImpl(Inline)]
        public EmittedTableEvent(EventId id, TableId table, Count count, FilePath dst)
        {
            EventId = id;
            TableId = table;
            RowCount = count;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public EmittedTableEvent(Type host, TableId table, Count count, FilePath target)
        {
            EventId = EventId.define(host, Kind);
            TableId = table;
            RowCount = 0;
            Target = target;
        }

        public string Format()
            => RpOps.format(EventId, AppMsg.EmittedTable.Capture(TableId, RowCount, Target));

        public override string ToString()
            => Format();
    }
}