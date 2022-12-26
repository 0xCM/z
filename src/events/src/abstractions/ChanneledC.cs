//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Events;

    public abstract class Channeled<C> : Channeled, IChanneled<C>
        where C : Channeled<C>, new()
    {
        public static C create(IWfChannel channel)
            => new C().Factory(channel);

        static C connect(IWfChannel channel)
        {
            var service = new C();
            service.Connect(channel);
            return service;
        }

        public static C create(IWfChannel channel, Action<C> initializer)
        {
            var dst = create(channel);
            initializer(dst);
            return dst;
        }

        public virtual Func<IWfChannel,C> Factory => connect;

        protected Channeled(IWfChannel channel)
            : base(channel)
        {
        }

        protected Channeled()
        {

        }
    }    

    class Channeling : IWfChannel
    {
        TokenDispenser Tokens;

        readonly IWfEmissions Emissions;

        readonly IEventSink EventSink;

        public EventId Raise<E>(E e)
            where E : IEvent
        {
            EventSink.Deposit(e);
            return e.EventId;
        }

        [MethodImpl(Inline)]
        public ExecToken NextExecToken()
            => Tokens.Open();

        Type Host => EventSink.Host;

        public void Data<T>(T data, FlairKind flair)
            => Raise(Events.data(data, flair));

        public void Data<T>(T data)
            => Raise(Events.data(data));

        public void Data<T>(AppEventSource host, T data)
            => signal(EventSink).Data(data);

        public void Data<T>(AppEventSource host, T data, FlairKind flair)
            => signal(EventSink).Data(data, flair);

        public void Row<T>(T data)
            => Raise(Events.row(data));

        public void Row<T>(T data, FlairKind flair)
            => Raise(Events.row(data, flair));

        public void Write<T>(T content)
            => Data(content);

        public void Write<T>(T content, FlairKind flair)
            => Data(content);

        public void Write(string content, FlairKind flair)
            => Data(content);

        public void Write<T>(string name, T value)
            => Data($"{name}:{value}");

        public ExecToken Completed(ExecFlow src, bool success = true)
            => Tokens.Close(src.Token, success);

        public ExecToken Completed(FileEmission src)
            => Tokens.Close(src.Token, src.Succeeded);

        public ExecToken Completed<T>(ExecFlow<T> src, bool success = true)
            => Tokens.Close(src.Token, success);

        public ExecFlow<string> Running([CallerName] string msg = null)
        {
            var e = signal(EventSink).Running(msg);
            return Flow(msg);
        }

        public ExecFlow<T> Running<T>(T data)
        {
            signal(EventSink).Running(data);
            return Flow(data);
        }

        public ExecFlow<T> Running<T>(AppEventSource host, T msg)
        {
            signal(EventSink, host).Running(msg);
            return Flow(msg);
        }

        public ExecFlow<string> Running(AppEventSource host, [CallerName] string caller = null)
        {
            signal(EventSink, host).Running(caller);
            return Flow(caller);
        }

        public ExecToken Ran<T>(ExecFlow<T> src, [CallerName] string msg = null)
        {
            var token = Completed(src);
            signal(EventSink).Ran(src.WithMsg(msg));
            return token;
        }

        public ExecToken Ran<T>(ExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran)
        {
            throw new NotImplementedException();
        }
        
        public ExecToken Ran<D>(ExecFlow src, D data, FlairKind flair = FlairKind.Ran)
        {
            var token = Completed(src);
            signal(EventSink).Ran(data);
            return token;
        }

        public ExecToken Ran<T,D>(ExecFlow<T> src, D data, FlairKind flair = FlairKind.Ran)
        {
            var token = Completed(src);
            signal(EventSink).Ran(data);
            return token;
        }

        public ExecFlow<T> Flow<T>(T data)
            => new ExecFlow<T>(this, data, NextExecToken());

        public TableFlow<T> TableFlow<T>(FilePath dst)
            where T : struct
                => new TableFlow<T>(this, dst, NextExecToken());

        public FileEmission Flow(FilePath dst)
            => new FileEmission(NextExecToken(), dst, 0);

        public void Babble<T>(T data)
            => signal(EventSink).Babble(data);

        public void Babble<T>(AppEventSource host, T data)
            => signal(EventSink, host).Babble(data);

        public void Status<T>(T data, FlairKind flair = FlairKind.Status)
            => Raise(status(EventSink.Host, data, flair));

        public void Status<T>(AppEventSource src,T data, FlairKind flair = FlairKind.Status)
            => Raise(status(src.Type, data, flair));

        public void Warn<T>(T msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Raise(warn(EventSink.Host, msg, Events.originate("WorkflowError", caller, file, line)));

        public void Error(Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Raise(error(EventSink.Host, e, Events.originate("WorkflowError", caller, file, line)));

        public void Error<T>(T msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine]int? line = null)
            => Raise(error(EventSink.Host, msg, Events.originate("WorkflowError", caller, file, line)));
    
        public ExecFlow<Type> Creating(Type host)
        {
            signal(EventSink, host).Creating(host);
            return Flow(host);
        }

        public ExecToken Created(ExecFlow<Type> flow)
        {
            signal(EventSink).Created(flow.Data);
            return Completed(flow);
        }

        public ExecToken Completed<T>(ExecFlow<T> flow, Type host, Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine]int? line = null)
        {
            signal(EventSink, host).Raise(Events.error(host, e, caller,file,line));
            return Completed(flow);
        }

        public ExecToken Completed<T>(ExecFlow<T> flow, Type host, Exception e, EventOrigin origin)
        {
            signal(EventSink, host).Raise(Events.error(host, e, origin));
            return Completed(flow);
        }

        public TableFlow<T> EmittingTable<T>(FilePath dst)
            where T : struct
        {
            signal(EventSink).EmittingTable<T>(dst);
            return Emissions.LogEmission(TableFlow<T>(dst));
        }

        public TableFlow<T> EmittingTable<T>(AppEventSource host, FilePath dst)
            where T : struct
        {
            signal(EventSink, host).EmittingTable<T>(dst);
            return Emissions.LogEmission(TableFlow<T>(dst));
        }

        public ExecToken EmittedTable<T>(TableFlow<T> flow, Count count, FilePath? dst = null)
            where T : struct
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(EventSink).EmittedTable<T>(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        public ExecToken EmittedTable<T>(AppEventSource host, TableFlow<T> flow, Count count, FilePath? dst = null)
            where T : struct
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(EventSink, host).EmittedTable<T>(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        public FileEmission EmittingFile(FilePath dst)
        {
            signal(EventSink).EmittingFile(dst);
            return Emissions.LogEmission(Flow(dst));
        }

        public FileEmission EmittingFile(AppEventSource host, FilePath dst)
        {
            signal(EventSink, host).EmittingFile(dst);
            return Emissions.LogEmission(Flow(dst));
        }

        public ExecToken EmittedFile(FileEmission flow, Count count)
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(EventSink).EmittedFile(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        public ExecToken EmittedFile(FileEmission flow)
        {
            var completed = Completed(flow);
            signal(EventSink).EmittedFile(flow.WithToken(completed));
            return completed;
        }
        
        public ExecToken EmittedFile(FileEmission flow, int count)
            => EmittedFile(flow, (Count)count);

        public ExecToken EmittedFile(FileEmission flow, uint count)
            => EmittedFile(flow, (Count)count);

        public ExecToken EmittedFile<T>(FileEmission flow, T msg)
        {
            var completed = Completed(flow);
            var counted = flow.WithToken(completed);
            signal(EventSink).EmittedFile(counted.Target, msg);
            Emissions.LogEmission(counted);
            return completed;
        }

        public ExecToken EmittedFile(AppEventSource host, FileEmission flow, Count count)
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(EventSink, host).EmittedFile(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        public ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
        {
            var emitting = EmittingTable<T>(dst);
            Tables.emit(rows, dst, encoding, rowpad, fk);
            return EmittedTable(emitting, rows.Length);
        }

        public ExecToken TableEmit<T>(Index<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
                    => TableEmit(rows.View, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(T[] rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
                    => TableEmit(@readonly(rows), dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(ReadOnlySeq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
                    => TableEmit(src.View, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(Seq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
                    => TableEmit(src.View, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding)
           where T : struct
        {
            var emitting = EmittingTable<T>(dst);
            var formatter = CsvTables.formatter(typeof(T));
            using var writer = dst.Emitter(encoding);
            writer.WriteLine(formatter.FormatHeader());
            for (var i = 0; i < rows.Length; i++)
                writer.WriteLine(formatter.Format(skip(rows, i)));
            return EmittedTable(emitting, rows.Length, dst);
        }

        public ExecToken TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FilePath dst)
            where T : struct
        {
            var flow = EmittingTable<T>(Host, dst);
            var spec = Tables.rowspec<T>(widths, z16);
            var count = Tables.emit(src, spec, encoding, dst);
            return EmittedTable(Host, flow, count);
        }

        public ExecToken FileEmit<T>(T src, Count count, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            using var emitter = dst.Writer(encoding);
            emitter.Write(src.ToString());
            return EmittedFile(emitting, count);
        }

        public ExecToken FileEmit<T>(T src, FilePath dst, ByteSize size, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            using var emitter = dst.Writer(encoding);
            emitter.Write(src.ToString());
            return EmittedFile(emitting, size);
        }

        public ExecToken FileEmit<T>(T src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            using var emitter = dst.Writer(encoding);
            emitter.Write(src.ToString());
            return EmittedFile(emitting, 0);
        }

        public ExecToken FileEmit<T>(T src, string msg, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            Write(string.Format("{0,-12} | {1}", "Emitting", dst.ToUri()), FlairKind.Running);
            using var emitter = dst.Writer(encoding);
            emitter.Write(src.ToString());
            Write(string.Format("{0,-12} | {1}", "Emitted", dst.ToUri()), FlairKind.Ran);
            Write(string.Format("{0,-12} | {1}", "Description", msg), FlairKind.Ran);
            return EmittedFile(emitting, 0);
        }

        public ExecToken FileEmit<T>(ReadOnlySpan<T> lines, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer(encoding);
            var count = lines.Length;
            for (var i = 0; i < count; i++)
                writer.AppendLine(skip(lines, i));
            return EmittedFile(emitting, count);
        }

        public ExecToken FileEmit(string src, Count count, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Utf8)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer(encoding);
            writer.WriteLine(src);
            return EmittedFile(emitting, count);
        }

        public void Babble(string pattern, params object[] args)
            => Babble(string.Format(pattern,args));

        public ExecToken EmittedBytes(FileEmission flow, ByteSize size)
            => EmittedFile(flow, AppMsg.EmittedBytes.Capture(size, flow.Target));

        public ExecToken Ran(ExecFlow flow)
            => Tokens.Close(flow.Token);
    }
}