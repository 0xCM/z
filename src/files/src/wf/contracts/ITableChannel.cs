//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITableChannel
    {
        ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular);

        ExecToken TableEmit<T>(Index<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular);

        ExecToken TableEmit<T>(T[] rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular);

        ExecToken TableEmit<T>(ReadOnlySeq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) ;

        ExecToken TableEmit<T>(Seq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) ;

        ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding);

        ExecToken TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FilePath dst);

        ExecToken EmittedTable<T>(TableFlow<T> flow, Count count, FilePath? dst = null);

        TableFlow<T> EmittingTable<T>(FilePath dst);
    }
}