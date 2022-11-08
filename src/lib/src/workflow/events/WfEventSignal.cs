//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Events;

    public class WfEventSignal
    {
        readonly WfHost Source;

        readonly IEventSink Sink;

        [MethodImpl(Inline)]
        internal WfEventSignal(IEventSink sink, WfHost src)
        {
            Source = src;
            Sink = sink;
        }

        public EventId Raise<E>(in E e)
            where E : IEvent
        {
            Sink.Deposit(e);
            return e.EventId;
        }

        public RunningEvent Running()
        {
            var e = running(Source.Type);
            Raise(e);
            return e;
        }

        public RunningEvent<T> Running<T>(T data)
        {
            var e = running(Source.Type, data);
            Raise(e);
            return e;
        }

        public RanEvent<T> Ran<T>(T msg)
        {
            var ev = ran(Source.Type, msg);
            Raise(ev);
            return ev;
        }

        public RanEvent<T> Ran<T>(RunningEvent<T> prior, T msg)
        {
            var ev = ran(prior,msg);
            Raise(ev);
            return ev;
        }

        public CreatingEvent Creating(Type host)
        {
            var ev = creating(host);
            Raise(ev);
            return ev;
        }

        public CreatedEvent Created(Type host)
        {
            var ev = created(host);
            Raise(ev);
            return ev;
        }

        public EmittingTableEvent EmittingTable(Type table, FilePath dst)
        {
            var ev = emittingTable(Source.Type, table, dst);
            Raise(ev);
            return ev;
        }

        public EmittingTableEvent<T> EmittingTable<T>(FilePath dst)
            where T : struct
        {
            var ev = emittingTable<T>(Source.Type, dst);
            Raise(ev);
            return ev;
        }

        public EmittedTableEvent<T> EmittedTable<T>(Count count, FilePath dst)
            where T : struct
        {
            var e = emittedTable<T>(Source.Type, count, dst);
            Raise(e);
            return e;
        }

        public EmittedTableEvent EmittedTable(Type table, Count count, FilePath dst)
        {
            var ev = emittedTable(Source.Type, TableId.identify(table), count, dst);
            Raise(ev);
            return ev;
        }

        public EmittingFileEvent EmittingFile(FilePath dst)
        {
            var ev = emittingFile(Source.Type, dst);
            Raise(ev);
            return ev;
        }

        public EmittedFileEvent EmittedFile(Count count, FilePath dst)
        {
            var ev = emittedFile(Source.Type, dst, count);
            Raise(ev);
            return ev;
        }

        public EmittedFileEvent EmittedFile(FileWritten ran)
        {
            var ev = emittedFile(Source.Type, ran.Target);
            Raise(ev);
            return ev;
        }

        public EmittedFileEvent<T> EmittedFile<T>(FilePath dst, T msg)
        {
            var ev = emittedFile(Source.Type, dst, msg);
            Raise(ev);
            return ev;
        }

        public StatusEvent<T> Status<T>(T data, FlairKind flair = FlairKind.Status)
        {
            var ev = status(Source.Type, data, flair);
            Raise(ev);
            return ev;
        }

        public BabbleEvent<T> Babble<T>(T data)
        {
            var ev = babble(Source.Type, data);
            Raise(ev);
            return ev;
        }

        public ErrorEvent<string> Error(Exception e, EventOrigin origin)
        {
            var ev = error(Source.Type, e, origin);
            Raise(ev);
            return ev;
        }

        public ErrorEvent<T> Error<T>(T msg, EventOrigin origin)
        {
            var ev = error(Source.Type, msg, origin);
            Raise(ev);
            return ev;
        }

        public WarnEvent<T> Warn<T>(T msg, EventOrigin origin)
        {
            var ev = warn(Source.Type, msg, origin);
            Raise(ev);
            return ev;
        }

        public DataEvent<T> Data<T>(T data, FlairKind flair)
        {
            var ev = Events.data(data, flair);
            Raise(ev);
            return ev;
        }

        public DataEvent<T> Data<T>(T data)
        {
            var ev = Events.data(data);
            Raise(ev);
            return ev;
        }

        public RowEvent<T> Row<T>(T data)
        {
            var ev = Events.row(data);
            Raise(ev);
            return ev;
        }

        public RowEvent<T> Row<T>(T data, FlairKind flair)
        {
            var ev = Events.row(data, flair);
            Raise(ev);
            return ev;
        }
    }
}