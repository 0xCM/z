//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEventChannel
    {
        EventId Raise<E>(E e) 
            where E : IEvent;

        ExecFlow<Type> Creating(Type service);

        ExecToken Completed<T>(ExecFlow<T> flow, Type host, Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null);

        ExecToken Completed<T>(ExecFlow<T> flow, Type host, Exception e, EventOrigin origin);

        ExecToken Created(ExecFlow<Type> flow);

        ExecFlow<T> Running<T>(T msg);

        ExecFlow<string> Running([CallerName] string msg = null);

        ExecToken Ran<T>(ExecFlow<T> flow, [CallerName] string msg = null);

        ExecToken Ran<T>(ExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran);

        ExecToken Ran<T, D>(ExecFlow<T> src, D data, FlairKind flair = FlairKind.Ran);            
    }

    public interface IMsgChannel
    {
        void Babble<T>(T content);

        void Babble(string pattern, params object[] args);

        void Status<T>(T content, FlairKind flair = FlairKind.Status);

        void Warn<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null);

        void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null);

        void Row<T>(T content);

        void Row<T>(T content, FlairKind flair);

        void Write<T>(T content);

        void Write<T>(T content, FlairKind flair);

        void Write(string content, FlairKind flair);

        void Write<T>(string name, T value, FlairKind flair);

        void Write<T>(string name, T value);
    }

    public interface ITableChannel
    {
        ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        ExecToken TableEmit<T>(Index<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        ExecToken TableEmit<T>(T[] rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        ExecToken TableEmit<T>(ReadOnlySeq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        ExecToken TableEmit<T>(Seq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding) where T : struct;

        ExecToken TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FilePath dst) where T : struct;    

        ExecToken EmittedTable<T>(TableFlow<T> flow, Count count, FilePath? dst = null) where T : struct;

        TableFlow<T> EmittingTable<T>(FilePath dst) where T : struct;
    }

    public interface ICmdChannel : IEventChannel
    {
        ExecFlow<T> Executing<T>(T cmd, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : ICmd<T>, new()
                => Running(cmd);

        ExecToken Executed<T>(ExecFlow<T> flow, [CallerName] string msg = null)
            where T : ICmd<T>, new()
                => Ran(flow, msg);
    }

    public interface IFileChannel
    {
        ExecToken EmittedBytes(FileEmission flow, ByteSize size);

        ExecToken EmittedFile(FileEmission flow, Count count);

        ExecToken EmittedFile(FileEmission flow, int count);

        ExecToken EmittedFile(FileEmission flow, uint count);

        ExecToken EmittedFile<T>(FileEmission flow, T msg);

        ExecToken EmittedFile(FileEmission flow);
        
        FileEmission EmittingFile(FilePath dst);

        ExecToken FileEmit<T>(T src, Count count, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        ExecToken FileEmit<T>(T src, FilePath dst, ByteSize size, TextEncodingKind encoding = TextEncodingKind.Asci);

        ExecToken FileEmit<T>(T src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        ExecToken FileEmit<T>(T src, string msg, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        ExecToken FileEmit<T>(ReadOnlySpan<T> lines, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        ExecToken FileEmit(string src, Count count, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Utf8);
    }

    public interface IWfChannel : IEventChannel, IMsgChannel, ITableChannel, IFileChannel, ICmdChannel
    {

    }
}