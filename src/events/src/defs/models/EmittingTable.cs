//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Event(Kind)]
public readonly struct EmittingTableEvent : IEvent<EmittingTableEvent>
{
    public const string EventName = EventNames.EmittingTable;

    public const EventKind Kind = EventKind.EmittingTable;

    public EventId EventId {get;}

    public TableId TableId {get;}

    public FilePath Target {get;}

    public FlairKind Flair => FlairKind.Running;

    [MethodImpl(Inline)]
    public EmittingTableEvent(Type host, Type table, FilePath target)
    {
        EventId = EventId.define(host, Kind);
        TableId = TableId.identify(table);
        Target = target;
    }

    public LogLevel EventLevel => LogLevel.Status;

    public string Format()
        => TextPatterns.piped(EventId, AppMsgs.EmittingTable.Capture(TableId, Target));


    public override string ToString()
        => Format();
}
