//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Events;

    public sealed class WfChannel : IWfChannel
    {    
        public static WfChannel create(WfInit init)
            => new (init.EventBroker, init.EmissionLog, init.Host);

        public static WfChannel create(IEventBroker broker, IWfEmissions emissions, Type host)
            => new (broker, emissions, host);

        readonly Type Host;

        readonly IEventSink EventSink;

        readonly IWfEmissions Emissions;

        WfChannel(IEventBroker broker, IWfEmissions emissions, Type host)
        {
            EventSink = broker.Sink;
            Emissions = emissions;
            Host = host;
        }

        static ExecToken Completed(ExecFlow src, bool success = true)
            => TokenDispenser.close(src, success);

        [MethodImpl(Inline)]
        static ExecToken NextExecToken()
            => TokenDispenser.open();

        static ExecToken Completed(FileEmission src)
            => TokenDispenser.close(src);

        static ExecToken Completed<T>(ExecFlow<T> src, bool success = true)
            => TokenDispenser.close(src, success);

        static ExecToken Completed<T>(TableFlow<T> src, bool success = true)
            => TokenDispenser.close(src, success);

        ExecFlow<T> Flow<T>(T data)
            => new (this, data, NextExecToken());

        TableFlow<T> TableFlow<T>(FilePath dst)
            => new (this, dst, NextExecToken());

        FileEmission Flow(FilePath dst)
            => new (NextExecToken(), dst, 0);

        public void Raise<E>(E e)
            where E : IEvent
        {
            EventSink.Deposit(e);
        }

        public void Babble<T>(T content)
            => signal(EventSink, Host).Raise(babble(Host,content));

        public void Babble(string pattern, params object[] args)
            => signal(EventSink, Host).Babble(string.Format(pattern, args));

        public void Status<T>(T content, FlairKind flair = FlairKind.Status)
            => signal(EventSink, Host).Status(content, flair);

        public void Status(ReadOnlySpan<char> src, FlairKind flair = FlairKind.Status)
            => signal(EventSink, Host).Status(new string(src), flair);

        public void Status(FlairKind flair, string pattern, params object[] args)
            => signal(EventSink, Host).Status(string.Format(pattern, args), flair);

        public void Status(string pattern, params object[] args)
            => signal(EventSink, Host).Status(string.Format(pattern, args));

        public void Warn<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => signal(EventSink).Warn(content, originate(Host, caller, file, line));

        public void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => signal(EventSink, Host).Error(content, originate("WorkflowError", caller, file, line));

        public void Write<T>(T content)
            => signal(EventSink, Host).Data(content);

        public void Write<T>(T content, FlairKind flair)
            => signal(EventSink, Host).Data(content, flair);

        public void Row<T>(T content)
            => signal(EventSink, Host).Row(content);

        public void Row<T>(T content, FlairKind flair)
            => signal(EventSink, Host).Row(content, flair);

        public void Write(string content, FlairKind flair)
            => signal(EventSink, Host).Data(content,flair);

        public void Write<T>(string name, T value, FlairKind flair)
            => signal(EventSink, Host).Data(text.attrib(name, value), flair);

        public void Write<T>(string name, T value)
            => signal(EventSink, Host).Data(text.attrib(name, value));

        public ExecFlow<Type> Creating(Type host)
        {
            signal(EventSink, host).Creating(host);
            return Flow(host);
        }

        public ExecToken Created(ExecFlow<Type> flow)
        {
            signal(EventSink, Host).Created(flow.Data);
            return Completed(flow);
        }

        public ExecToken Completed<T>(ExecFlow<T> flow, Type host, Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            signal(EventSink, host).Raise(error(host, e, caller,file,line));
            return Completed(flow);
        }

        public ExecToken Completed<T>(ExecFlow<T> flow, Type host, Exception e, EventOrigin origin)
        {
            signal(EventSink, host).Raise(error(host, e, origin));
            return Completed(flow);
        }

        public ExecFlow<T> Running<T>(T msg)
        {
            signal(EventSink, Host).Running(msg);
            return Flow(msg);
        }

        public ExecFlow<string> Running([CallerName] string caller = null)
        {
            signal(EventSink, Host).Running(caller);
            return Flow(caller);
        }

        public ExecToken Ran<T>(ExecFlow<T> flow, [CallerName] string caller = null)
        {
            var token = Completed(flow);
            signal(EventSink, Host).Ran(flow.Data);
            return token;
        }

        public ExecToken Ran<T>(ExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran)
        {
            var token = Completed(flow);
            signal(EventSink, Host).Ran(flow.Data);
            return token;
        }

        public ExecToken<D> Ran<D>(ExecFlow src, D data, FlairKind flair = FlairKind.Ran)
        {
            var token = Completed(src);
            signal(EventSink, Host).Ran(data);
            return (token,data);
        }

        public FileEmission EmittingFile(FilePath dst)
        {
            signal(EventSink, Host).EmittingFile(dst);
            return Emissions.LogEmission(Flow(dst));
        }

        public ExecToken EmittedFile(FileEmission flow, Count count)
        {
            var completed = Completed(flow);
            var token = flow.WithCount(count).WithToken(completed);
            signal(EventSink, Host).EmittedFile(count, token.Target);
            Emissions.LogEmission(token);
            return completed;
        }

        public ExecToken EmittedFile(FileEmission flow, int count)
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(EventSink, Host).EmittedFile(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        public ExecToken EmittedFile(FileEmission flow, uint count)
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(EventSink, Host).EmittedFile(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        public ExecToken EmittedFile<T>(FileEmission flow, T msg)
        {
            var completed = Completed(flow);
            var counted = flow.WithToken(completed);
            signal(EventSink).EmittedFile(counted.Target, msg);
            Emissions.LogEmission(counted);
            return completed;
        }

        public ExecToken EmittedFile(FileEmission flow)
        {
            var completed = Completed(flow);
            var token = flow.WithToken(completed);
            signal(EventSink).EmittedFile(token);
            return completed;
        }

        public ExecToken Ran(ExecFlow flow, bool success = true)
        {
            var token = Completed(flow, success);
            signal(EventSink, Host).Ran(flow);
            return token;
        }

        public ExecToken EmittedBytes(FileEmission flow, ByteSize size)
            => EmittedFile(flow, AppMsg.EmittedBytes.Capture(size, flow.Target));

        public TableFlow<T> EmittingTable<T>(FilePath dst)
        {
            signal(EventSink, Host).EmittingTable<T>(dst);
            return Emissions.LogEmission(TableFlow<T>(dst));
        }

        public ExecToken EmittedTable<T>(TableFlow<T> flow, Count count, FilePath? dst = null)
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(EventSink).EmittedTable<T>(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        ExecToken<TableFlow<T>> EmittedTable<T>(AppEventSource host, TableFlow<T> flow, Count count, FilePath? dst = null)
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(EventSink, host).EmittedTable<T>(count, counted.Target);
            Emissions.LogEmission(counted);
            return (completed, counted);
        }

        public ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                => CsvTables.emit(this, rows, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(Index<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                => TableEmit(rows.View, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(T[] rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                => TableEmit(@readonly(rows), dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(ReadOnlySeq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                => TableEmit(src.View, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(Seq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                => TableEmit(src.View, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding)
            => CsvTables.emit(this, rows, dst, encoding);
 

        public ExecToken TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FilePath dst)
        {
            signal(EventSink, Host).EmittingTable<T>(dst);
            var flow =Emissions.LogEmission(TableFlow<T>(dst));
            var count = CsvTables.emit(src, widths, dst);
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(EventSink, Host).EmittedTable<T>(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
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
    }
}