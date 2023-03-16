//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Events;

    public class EventSignal
    {
        readonly Type Source;

        readonly IEventSink Sink;

        [MethodImpl(Inline)]
        public EventSignal(IEventSink sink, Type src)
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
            var e = running(Source);
            Raise(e);
            return e;
        }

        public RunningEvent<T> Running<T>(T data)
        {
            var e = running(Source, data);
            Raise(e);
            return e;
        }

        public RanEvent<T> Ran<T>(T msg)
        {
            var ev = ran(Source, msg);
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

        public CreatedEvent<T> Created<T>(T data, Type host)
        {
            var ev = created(data, host);
            Raise(ev);
            return ev;
        }

        public CreatedEvent<T> Created<T>(T data, CreatingEvent prior)
        {
            var ev = created(data, prior);
            Raise(ev);
            return ev;
        }

        public EmittingTableEvent EmittingTable(Type table, FilePath dst)
        {
            var ev = emittingTable(Source, table, dst);
            Raise(ev);
            return ev;
        }

        public EmittingTableEvent<T> EmittingTable<T>(FilePath dst)
        {
            var ev = emittingTable<T>(Source, dst);
            Raise(ev);
            return ev;
        }

        public EmittedTableEvent<T> EmittedTable<T>(Count count, FilePath dst)
        {
            var e = emittedTable<T>(Source, count, dst);
            Raise(e);
            return e;
        }

        public EmittedTableEvent EmittedTable(Type table, Count count, FilePath dst)
        {
            var ev = emittedTable(Source, TableId.identify(table), count, dst);
            Raise(ev);
            return ev;
        }

        public EmittingFileEvent EmittingFile(FilePath dst)
        {
            var ev = emittingFile(Source, dst);
            Raise(ev);
            return ev;
        }

        public EmittedFileEvent EmittedFile(Count count, FilePath dst)
        {
            var ev = emittedFile(Source, dst, count);
            Raise(ev);
            return ev;
        }

        public EmittedFileEvent EmittedFile(FileEmission ran)
        {
            var ev = emittedFile(Source, ran.Target);
            Raise(ev);
            return ev;
        }

        public EmittedFileEvent<T> EmittedFile<T>(FilePath dst, T msg)
        {
            var ev = emittedFile(Source, dst, msg);
            Raise(ev);
            return ev;
        }

        public StatusEvent<T> Status<T>(T data, FlairKind flair = FlairKind.Status)
        {
            var ev = status(Source, data, flair);
            Raise(ev);
            return ev;
        }

        public BabbleEvent<T> Babble<T>(T data)
        {
            var ev = babble(Source, data);
            Raise(ev);
            return ev;
        }

        public ErrorEvent<string> Error(Exception e, EventOrigin origin)
        {
            var ev = error(Source, e, origin);
            Raise(ev);
            return ev;
        }

        public ErrorEvent<T> Error<T>(T msg, EventOrigin origin)
        {
            var ev = error(Source, msg, origin);
            Raise(ev);
            return ev;
        }

        public WarnEvent<T> Warn<T>(T msg, EventOrigin origin)
        {
            var ev = warn(Source, msg, origin);
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