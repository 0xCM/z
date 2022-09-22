//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;



    public class WfEmit : IWfChannel
    {
        public static WfEmit create(IWfRuntime wf, WfHost host)
            => new WfEmit(wf, host);

        readonly IWfRuntime Wf;

        readonly WfHost Host;

        WfEmit(IWfRuntime wf, WfHost host)
        {
            Wf = wf;
            Host = host;
        }

        public void Dispose()
        {

        }

        public EventId Raise<E>(E e)
            where E : IWfEvent
                => Wf.Raise(e);

        public void Babble<T>(T content)
            => Wf.Babble(Host, content);

        public void Babble(string pattern, params object[] args)
            => Wf.Babble(Host, string.Format(pattern, args));

        public void Status<T>(T content, FlairKind flair = FlairKind.Status)
            => Wf.Status(Host, content, flair);

        public void Status(ReadOnlySpan<char> src, FlairKind flair = FlairKind.Status)
            => Wf.Status(Host, new string(src), flair);

        public void Status(FlairKind flair, string pattern, params object[] args)
            => Wf.Status(Host, string.Format(pattern, args));

        public void Status(string pattern, params object[] args)
            => Wf.Status(Host, string.Format(pattern, args));

        public void Warn<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Wf.Warn(content, caller, file, line);

        public void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Wf.Error(Host, core.require(content), caller, file, line);

        public void Write<T>(T content)
            => Wf.Data(Host, content);

        public void Write<T>(T content, FlairKind flair)
            => Wf.Data(Host, content, flair);

        public void Row<T>(T content)
            => Wf.Row(content);

        public void Row<T>(T content, FlairKind flair)
            => Wf.Row(content, flair);

        public void Write(string content, FlairKind flair)
            => Wf.Data(Host, content, flair);

        public void Write<T>(string name, T value, FlairKind flair)
            => Wf.Data(Host, RpOps.attrib(name, value), flair);

        public void Write<T>(string name, T value)
            => Wf.Data(Host, RpOps.attrib(name, value));

        public WfExecFlow<Type> Creating(Type service)
            => Wf.Creating(service);

        public ExecToken Created(WfExecFlow<Type> flow)
            => Wf.Created(flow);

        public ExecToken Completed<T>(WfExecFlow<T> flow, Type host, Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Wf.Completed(flow, host, e, caller, file, line);

        public ExecToken Completed<T>(WfExecFlow<T> flow, Type host, Exception e, EventOrigin origin)
            => Wf.Completed(flow, host, e, origin);

        public WfExecFlow<T> Running<T>(T msg)
            => Wf.Running(Host, msg);

        public WfExecFlow<string> Running([CallerName] string msg = null)
            => Wf.Running(Host, msg);

        public ExecToken Ran<T>(WfExecFlow<T> flow, [CallerName] string msg = null)
            => Wf.Ran(Host, flow.WithMsg(msg));

        public ExecToken Ran<T>(WfExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran)
            => Wf.Ran(Host, flow.WithMsg(msg), flair);

        public ExecToken Ran<T, D>(WfExecFlow<T> src, D data, FlairKind flair = FlairKind.Ran)
            => Wf.Ran(src, data, flair);

        public FileWritten EmittingFile(FilePath dst)
            => Wf.EmittingFile(Host, dst);

        public ExecToken EmittedFile(FileWritten flow, Count count)
            => Wf.EmittedFile(Host, flow, count);

        public ExecToken EmittedFile(FileWritten flow, int count)
            => Wf.EmittedFile(Host, flow, count);

        public ExecToken EmittedFile(FileWritten flow, uint count)
            => Wf.EmittedFile(Host, flow, count);

        public ExecToken EmittedFile<T>(FileWritten flow, T msg)
            => Wf.EmittedFile(flow, msg);

        public ExecToken EmittedFile(FileWritten flow)
            => Wf.EmittedFile(flow);

        public ExecToken EmittedBytes(FileWritten flow, ByteSize size)
            => EmittedFile(flow, AppMsg.EmittedBytes.Capture(size, flow.Target));

        public WfTableFlow<T> EmittingTable<T>(FilePath dst)
            where T : struct
                => Wf.EmittingTable<T>(Host, dst);

        public ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FilePath? dst = null)
            where T : struct
                => Wf.EmittedTable(Host, flow, count, dst);

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
            var formatter = RecordFormatters.create(typeof(T));
            using var writer = dst.Emitter(encoding);
            writer.WriteLine(formatter.FormatHeader());
            for (var i = 0; i < rows.Length; i++)
                writer.WriteLine(formatter.Format(skip(rows, i)));
            return EmittedTable(emitting, rows.Length, dst);
        }

        public ExecToken TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(Host, dst);
            var spec = Tables.rowspec<T>(widths, z16);
            var count = Tables.emit(src, spec, encoding, dst);
            return Wf.EmittedTable(Host, flow, count);
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