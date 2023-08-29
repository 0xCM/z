//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Event(Kind)]
public readonly struct EmittedTableEvent : IEvent<EmittedTableEvent>
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

    public LogLevel EventLevel => LogLevel.Status;

    public string Format()
        => RP.format(EventId, AppMsgs.EmittedTable.Capture(TableId, RowCount, Target));

    public override string ToString()
        => Format();
}
