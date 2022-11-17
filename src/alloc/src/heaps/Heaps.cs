//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    [Free, ApiHost]
    public partial class Heaps
    {
        const NumericKind Closure = UnsignedInts;

        public static asci16 id(SymHeap src)
            => string.Format("H{0:X4}x{1:X4}x{2:X6}", src.SymbolCount, src.EntryCount, src.ExprLengths.Storage.Sum());

        [MethodImpl(Inline), Op]
        public static Span<char> expr(SymHeap src, uint index)
            => sys.slice(src.Expr.Edit, src.ExprOffsets[index], src.ExprLengths[index]);

        [MethodImpl(Inline)]
        public static HeapEntry<K,O,L> convert<K,O,L>(ReadOnlySpan<byte> src, out HeapEntry<K,O,L> dst)
            where K : unmanaged
            where O : unmanaged
            where L : unmanaged
        {
            dst = @as<HeapEntry<K,O,L>>(src);
            return dst;
        }
   }
}