//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Events;

    partial class XTend
    {
        public static IWfChannel Rehost(this IWfChannel channel, Type host)
            => WfChannel.create(((WfChannel)channel).Wf, host);
    }

    public class WfChannel : IWfChannel
    {
        public static WfChannel create(IWfRuntime wf, Type host)
            => new WfChannel(wf, host);

        internal readonly IWfRuntime Wf;

        readonly Type Host;

        readonly IEventSink EventSink;

        protected WfChannel(IWfRuntime wf, Type host)
        {
            Wf = wf;
            EventSink = wf.EventSink;
            Host = host;
        }

        public void Dispose()
        {

        }

        ExecToken NextExecToken() => Wf.NextExecToken();

        public ExecToken Completed(ExecFlow src, bool success = true)
            => TokenDispenser.close(src, success);

        public void Raise<E>(E e)
            where E : IEvent
        {
            EventSink.Deposit(e);
        }

        public virtual void Babble<T>(T content)
            => signal(EventSink, Host).Raise(babble(Host,content));

        public virtual void Babble(string pattern, params object[] args)
            => Wf.Babble(Host, string.Format(pattern, args));

        public virtual void Status<T>(T content, FlairKind flair = FlairKind.Status)
            => Wf.Status(Host, content, flair);

        public virtual void Status(ReadOnlySpan<char> src, FlairKind flair = FlairKind.Status)
            => Wf.Status(Host, new string(src), flair);

        public virtual void Status(FlairKind flair, string pattern, params object[] args)
            => Wf.Status(Host, string.Format(pattern, args));

        public virtual void Status(string pattern, params object[] args)
            => Wf.Status(Host, string.Format(pattern, args));

        public virtual void Warn<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Wf.Warn(content, caller, file, line);

        public virtual void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => signal(EventSink, Host).Error(content, Events.originate("WorkflowError", caller, file, line));

        public virtual void Write<T>(T content)
            => Wf.Data(Host, content);

        public virtual void Write<T>(T content, FlairKind flair)
            => Wf.Data(Host, content, flair);

        public virtual void Row<T>(T content)
            => Wf.Row(content);

        public virtual void Row<T>(T content, FlairKind flair)
            => Wf.Row(content, flair);

        public virtual void Write(string content, FlairKind flair)
            => Wf.Data(Host, content, flair);

        public virtual void Write<T>(string name, T value, FlairKind flair)
            => Wf.Data(Host, text.attrib(name, value), flair);

        public virtual void Write<T>(string name, T value)
            => Wf.Data(Host, text.attrib(name, value));

        public virtual ExecFlow<Type> Creating(Type service)
            => Wf.Creating(service);

        public virtual ExecToken Created(ExecFlow<Type> flow)
            => Wf.Created(flow, Host);

        public virtual ExecToken Completed<T>(ExecFlow<T> flow, Type host, Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Wf.Completed(flow, host, e, caller, file, line);

        public virtual ExecToken Completed<T>(ExecFlow<T> flow, Type host, Exception e, EventOrigin origin)
            => Wf.Completed(flow, host, e, origin);

        public virtual ExecFlow<T> Running<T>(T msg)
            => Wf.Running(Host, msg);

        public virtual ExecFlow<string> Running([CallerName] string caller = null)
            => Wf.Running(Host, caller);

        public virtual ExecToken Ran<T>(ExecFlow<T> flow, [CallerName] string caller = null)
            => Wf.Ran(Host, flow.WithMsg(caller));

        public virtual ExecToken Ran<T>(ExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran)
            => Wf.Ran(Host, flow.WithMsg(msg), flair);

        public virtual ExecToken<D> Ran<D>(ExecFlow src, D data, FlairKind flair = FlairKind.Ran)
        {
            var token = Completed(src);
            signal(Wf.EventSink).Ran(data);
            return (token,data);
        }

        public virtual FileEmission EmittingFile(FilePath dst)
            => Wf.EmittingFile(Host, dst);

        public virtual ExecToken EmittedFile(FileEmission flow, Count count)
            => Wf.EmittedFile(Host, flow, count);

        public virtual ExecToken EmittedFile(FileEmission flow, int count)
            => Wf.EmittedFile(Host, flow, count);

        public virtual ExecToken EmittedFile(FileEmission flow, uint count)
            => Wf.EmittedFile(Host, flow, count);

        public virtual ExecToken EmittedFile<T>(FileEmission flow, T msg)
            => Wf.EmittedFile(flow, msg);

        public virtual ExecToken EmittedFile(FileEmission flow)
            => Wf.EmittedFile(flow);

        public virtual ExecToken Ran(ExecFlow flow, bool success = true)
            => Wf.Ran(flow, success);

        public virtual ExecToken EmittedBytes(FileEmission flow, ByteSize size)
            => EmittedFile(flow, AppMsg.EmittedBytes.Capture(size, flow.Target));

        public virtual TableFlow<T> EmittingTable<T>(FilePath dst)
            => Wf.EmittingTable<T>(Host, dst);

        public virtual ExecToken EmittedTable<T>(TableFlow<T> flow, Count count, FilePath? dst = null)
            => Wf.EmittedTable(Host, flow, count, dst);

        public virtual ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                => CsvTables.emit(Wf.Channel, rows, dst, encoding, rowpad, fk);

        public virtual ExecToken TableEmit<T>(Index<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                => TableEmit(rows.View, dst, encoding, rowpad, fk);

        public virtual ExecToken TableEmit<T>(T[] rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                => TableEmit(@readonly(rows), dst, encoding, rowpad, fk);

        public virtual ExecToken TableEmit<T>(ReadOnlySeq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                => TableEmit(src.View, dst, encoding, rowpad, fk);

        public virtual ExecToken TableEmit<T>(Seq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                => TableEmit(src.View, dst, encoding, rowpad, fk);

        public virtual ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding)
            => CsvTables.emit(Wf.Channel, rows, dst, encoding);
 
        public virtual ExecToken TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FilePath dst)
        {
            var flow = Wf.EmittingTable<T>(Host, dst);
            var spec = CsvTables.rowspec<T>(widths, z16);
            var count = CsvTables.emit(src, spec, encoding, dst);
            return Wf.EmittedTable(Host, flow, count);
        }

        public virtual ExecToken FileEmit<T>(T src, Count count, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            using var emitter = dst.Writer(encoding);
            emitter.Write(src.ToString());
            return EmittedFile(emitting, count);
        }

        public virtual ExecToken FileEmit<T>(T src, FilePath dst, ByteSize size, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            using var emitter = dst.Writer(encoding);
            emitter.Write(src.ToString());
            return EmittedFile(emitting, size);
        }

        public virtual ExecToken FileEmit<T>(T src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            using var emitter = dst.Writer(encoding);
            emitter.Write(src.ToString());
            return EmittedFile(emitting, 0);
        }

        public virtual ExecToken FileEmit<T>(T src, string msg, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            Write(string.Format("{0,-12} | {1}", "Emitting", dst.ToUri()), FlairKind.Running);
            using var emitter = dst.Writer(encoding);
            emitter.Write(src.ToString());
            Write(string.Format("{0,-12} | {1}", "Emitted", dst.ToUri()), FlairKind.Ran);
            Write(string.Format("{0,-12} | {1}", "Description", msg), FlairKind.Ran);
            return EmittedFile(emitting, 0);
        }

        public virtual ExecToken FileEmit<T>(ReadOnlySpan<T> lines, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer(encoding);
            var count = lines.Length;
            for (var i = 0; i < count; i++)
                writer.AppendLine(skip(lines, i));
            return EmittedFile(emitting, count);
        }

        public virtual ExecToken FileEmit(string src, Count count, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Utf8)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer(encoding);
            writer.WriteLine(src);
            return EmittedFile(emitting, count);
        }
    }
}