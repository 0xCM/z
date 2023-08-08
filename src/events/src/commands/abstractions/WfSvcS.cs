//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public abstract class WfSvc<S> : AppService<S>
        where S : WfSvc<S>, new()
    {
        protected static AppSettings AppSettings => AppSettings.Default;

        protected static IEnvDb EnvDb => AppSettings.EnvDb();

        protected static AppDb AppDb => AppDb.Service;

        protected static IApiCmdRunner CmdRunner => ApiCmdRunner.Service();
        
        // public new void Babble(string pattern, params object[] args)
        //     => Channel.Babble(pattern, args);

        // public new void Status<T>(T content, FlairKind flair = FlairKind.Status)
        //     => Channel.Status(content, flair);

        // public void Warn<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        //     => Channel.Warn(content, caller, file, line);

        public void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Channel.Error(content, caller, file, line);

        public void Write<T>(T content)
            => Channel.Write(content);

        public void Write<T>(T content, FlairKind flair)
            => Channel.Write(content, flair);

        public void Row<T>(T content)
            => Channel.Row(content);

        public void Row<T>(T content, FlairKind flair)
            => Channel.Row(content, flair);

        public void Write(string content, FlairKind flair)
            => Channel.Write(content, flair);

        public void Write<T>(string name, T value)
            => Channel.Write(name, value);

        public ExecFlow<T> Running<T>(T msg)
            => Channel.Running(msg);

        public ExecFlow<string> Running([CallerName] string msg = null)
            => Channel.Running(msg);

        public ExecToken Ran<T>(ExecFlow<T> flow, [CallerName] string msg = null)
            => Channel.Ran(flow, msg);

        public ExecToken Ran<T,D>(ExecFlow<T> src, D data)
            => Channel.Ran(src, data);

        public FileEmission EmittingFile(FilePath dst)
            => Channel.EmittingFile(dst);

        public ExecToken EmittedFile(FileEmission flow, int count)
            => Channel.EmittedFile(flow, count);

        public ExecToken EmittedFile(FileEmission flow, uint count)
            => Channel.EmittedFile(flow, count);

        public ExecToken EmittedBytes(FileEmission flow, ByteSize size)
            => Channel.EmittedBytes(flow, size);

        public TableFlow<T> EmittingTable<T>(FilePath dst)
            where T : struct
                => Channel.EmittingTable<T>(dst);

        public ExecToken EmittedTable<T>(TableFlow<T> flow, Count count, FilePath? dst = null)
            where T : struct
                => Channel.EmittedTable(flow, count, dst);

        public ExecToken FileEmit<T>(T src, Count count, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Channel.FileEmit(src, count, dst, encoding);

        public ExecToken FileEmit<T>(T src, FilePath dst, ByteSize size, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Channel.FileEmit(src, dst, size, encoding);

        public ExecToken FileEmit<T>(T src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Channel.FileEmit(src, dst, encoding);

        public ExecToken FileEmit<T>(T src, string msg, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Channel.FileEmit(src, msg, dst, encoding);

        public ExecToken FileEmit<T>(ReadOnlySpan<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Channel.FileEmit(src, dst, encoding);

        public ExecToken TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => Channel.TableEmit(src, widths, encoding, dst);

        public ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
                => Channel.TableEmit(rows, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(Index<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
                => Channel.TableEmit(rows, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(T[] rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
            => Channel.TableEmit(rows, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(ReadOnlySeq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
            => Channel.TableEmit(src, dst, encoding);

        public ExecToken TableEmit<T>(Seq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => Channel.TableEmit(src, dst, encoding);
    }
}