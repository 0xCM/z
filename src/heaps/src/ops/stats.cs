//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Heaps
    {
        [Op]
        public static SymHeapStats stats(ReadOnlySpan<SymLiteralRow> src)
        {
            var dst = new SymHeapStats();
            dst.SymbolCount = (uint)src.Length;
            dst.EntryCount = (uint)bits.next((Pow2x32)bits.xmsb(dst.SymbolCount));
            dst.CharCount = Symbolic.charcount(src);
            dst.DataSize = dst.CharCount*2;
            return dst;
        }
   }
}