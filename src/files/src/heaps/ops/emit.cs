//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Heaps
    {
        public static void emit(SymHeap src, FilePath dst, IWfChannel channel)
            => CsvTables.emit(channel, Symbols.records(src).View, dst, TextEncodingKind.Unicode);
    }
}