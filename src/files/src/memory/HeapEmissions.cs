//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost,Free]
    public sealed class HeapEmissions
    {
        public static void emit(IWfChannel channel, SymHeap src, FilePath dst)
            => CsvTables.emit(channel, Symbols.records(src).View, dst, TextEncodingKind.Unicode);

        public static void emit(IWfChannel channel, SymHeap src, IDbArchive dst)
            => emit(channel, src, dst.Table<SymHeapRecord>());
    }
}