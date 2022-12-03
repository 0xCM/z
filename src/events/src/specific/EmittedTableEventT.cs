//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public class EmittedTableEvent<T> : ITerminalEvent<EmittedTableEvent<T>>
        where  T : struct
    {
        public const EventKind Kind = EventKind.EmittedTable;

        public EventId EventId {get;}

        public Count RowCount {get;}

        public FilePath Target {get;}

        public TableId TableId => TableId.identify(typeof(T));

        public FlairKind Flair => FlairKind.Ran;

        public TableId Table
            => TableId.identify<T>();

        public EmittedTableEvent()
        {
            EventId = EventId.Empty;
            RowCount = 0;
            Target = FilePath.Empty;
        }

        [MethodImpl(Inline)]
        public EmittedTableEvent(Type host, Count count, FilePath target)
        {
            EventId = EventId.define(host, Kind);
            RowCount = count;
            Target = target;
        }

        public string Format()
            => RP.format(EventId, AppMsg.EmittedTable.Capture(TableId, RowCount, Target));


        public override string ToString()
            => Format();

        public static implicit operator EmittedTableEvent(EmittedTableEvent<T> src)
            => new EmittedTableEvent(src.EventId, src.TableId, src.RowCount, src.Target);
    }
}