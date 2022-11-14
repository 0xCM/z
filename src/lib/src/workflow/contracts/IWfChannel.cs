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
        ExecToken TableEmit<T>(ReadOnlySpan<T> rows, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        ExecToken TableEmit<T>(Index<T> rows, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        ExecToken TableEmit<T>(T[] rows, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        ExecToken TableEmit<T>(ReadOnlySeq<T> src, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        ExecToken TableEmit<T>(Seq<T> src, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;                
    }

    public interface IWfChannel : IEventChannel, IMsgChannel
    {
        ExecFlow<Type> Creating(Type service);

        ExecToken Completed<T>(ExecFlow<T> flow, Type host, Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null);

        ExecToken Completed<T>(ExecFlow<T> flow, Type host, Exception e, EventOrigin origin);

        ExecToken Created(ExecFlow<Type> flow);

        ExecToken EmittedBytes(FileWritten flow, ByteSize size);

        ExecToken EmittedFile(FileWritten flow, Count count);

        ExecToken EmittedFile(FileWritten flow, int count);

        ExecToken EmittedFile(FileWritten flow, uint count);

        ExecToken EmittedFile<T>(FileWritten flow, T msg);

        ExecToken EmittedFile(FileWritten flow);

        ExecToken EmittedTable<T>(TableFlow<T> flow, Count count, FilePath? dst = null) where T : struct;

        FileWritten EmittingFile(FilePath dst);

        TableFlow<T> EmittingTable<T>(FilePath dst) where T : struct;

        ExecToken FileEmit<T>(T src, Count count, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        ExecToken FileEmit<T>(T src, FilePath dst, ByteSize size, TextEncodingKind encoding = TextEncodingKind.Asci);

        ExecToken FileEmit<T>(T src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        ExecToken FileEmit<T>(T src, string msg, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        ExecToken FileEmit<T>(ReadOnlySpan<T> lines, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        ExecToken FileEmit(string src, Count count, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Utf8);

        ExecFlow<T> Running<T>(T msg);

        ExecFlow<string> Running([CallerName] string msg = null);

        ExecToken Ran<T>(ExecFlow<T> flow, [CallerName] string msg = null);

        ExecToken Ran<T>(ExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran);

        ExecToken Ran<T, D>(ExecFlow<T> src, D data, FlairKind flair = FlairKind.Ran);

        ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        ExecToken TableEmit<T>(Index<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        ExecToken TableEmit<T>(T[] rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        ExecToken TableEmit<T>(ReadOnlySeq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        ExecToken TableEmit<T>(Seq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding) where T : struct;

        ExecToken TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FilePath dst) where T : struct;
    }
}