//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Algs;

    [Free, ApiHost]
    public partial class Heaps
    {
        const NumericKind Closure = UnsignedInts;

        public static void emit(SymHeap src, FS.FilePath dst, IWfEventTarget log)
            => Tables.emit(log, Heaps.records(src).View, dst, TextEncodingKind.Unicode);


        [MethodImpl(Inline), Op]
        public static MemoryHeap memory(MemoryAddress @base, Span<byte> data, Span<Address32> offsets)
            => new MemoryHeap(@base, data,offsets);

        public static asci16 id(SymHeap src)
            => string.Format("H{0:X4}x{1:X4}x{2:X6}", src.SymbolCount, src.EntryCount, src.ExprLengths.Storage.Sum());

        [MethodImpl(Inline), Op]
        public static Span<char> expr(SymHeap src, uint index)
            => core.slice(src.Expr.Edit, src.ExprOffsets[index], src.ExprLengths[index]);

        [MethodImpl(Inline)]
        public static ref HeapEntry<K,O,L> convert<K,O,L>(ReadOnlySpan<byte> src, out HeapEntry<K,O,L> dst)
            where K : unmanaged
            where O : unmanaged
            where L : unmanaged
        {
            dst = @as<HeapEntry<K,O,L>>(src);
            return ref dst;
        }
   }
}