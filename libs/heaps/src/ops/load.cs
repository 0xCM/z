//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    partial class Heaps
    {
        /// <summary>
        /// Creates a <see cref='SymHeap'/> from a specified <see cref='SymLiteralRow'/> sequence
        /// </summary>
        /// <param name="src">The data source</param>
        public static SymHeap load(ReadOnlySpan<SymLiteralRow> src)
        {
            var dst = new SymHeap();
            var stats = Heaps.stats(src);
            dst.SymbolCount = stats.SymbolCount;;
            dst.EntryCount = stats.EntryCount;
            dst.ExprLengths = sys.alloc<uint>(stats.EntryCount);
            dst.CharCount = stats.CharCount;
            dst.Expr = sys.alloc<char>(stats.CharCount);
            dst.ExprOffsets = sys.alloc<uint>(stats.EntryCount);
            dst.Values = sys.alloc<SymVal>(stats.EntryCount);
            dst.Names = sys.alloc<Identifier>(stats.EntryCount);
            dst.Sources = sys.alloc<Identifier>(stats.EntryCount);
            var size=0u;
            var offset=0u;
            for(var i=0u; i<dst.SymbolCount; i++)
            {
                ref readonly var row = ref skip(src,i);
                var chars = row.Symbol.Data;
                var length = (uint)chars.Length;
                dst.Length(i) = length;
                dst.Value(i) = row.Value;
                dst.Name(i) = row.Name;
                dst.Offset(i) = offset;
                dst.Source(i) = row.Type;
                Demand.lteq(offset + length, stats.CharCount);
                chars.CopyTo(slice(dst.Expr.Edit, offset, length));
                offset += length;
                size += length*2;
            }

            return dst;
        }

        /// <summary>
        /// Reconstitutes a <see cref='SymHeap{K,O,L}'/> indexed by <typeparamref name='K'> values with <typeparamref name='O'>-measured offsets and <typeparamref name='L'>-measured lengths
        /// </summary>
        /// <param name="entries"></param>
        /// <param name="data"></param>
        /// <typeparam name="K">The linear index type</typeparam>
        /// <typeparam name="O">The offset type</typeparam>
        /// <typeparam name="L">The length type</typeparam>
        [MethodImpl(Inline)]
        public static SymHeap<K,O,L> load<K,O,L>(ReadOnlySpan<byte> entries, ReadOnlySpan<char> data)
            where K : unmanaged
            where O : unmanaged
            where L : unmanaged
                => new SymHeap<K,O,L>(recover<HeapEntry<K,O,L>>(entries), data);
    }
}