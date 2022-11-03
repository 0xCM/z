//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Heaps
    {
        public static void emit(SymHeap src, FilePath dst, IWfChannel channel)
            => CsvEmitters.emit(channel, records(src).View, dst, TextEncodingKind.Unicode);
    }
}