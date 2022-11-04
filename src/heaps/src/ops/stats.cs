//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Heaps
    {
        [MethodImpl(Inline), Op]
        public static uint charcount(ReadOnlySpan<SymLiteralRow> src)
        {
            var counter = 0u;
            var kSrc = src.Length;
            for(var i=0; i<src.Length; i++)
                counter += sys.skip(src,i).Symbol.CharCount;
            return counter;
        }

        [Op]
        public static SymHeapStats stats(ReadOnlySpan<SymLiteralRow> src)
        {
            var dst = new SymHeapStats();
            dst.SymbolCount = (uint)src.Length;
            dst.EntryCount = (uint)bits.next((Pow2x32)bits.xmsb(dst.SymbolCount));
            dst.CharCount = charcount(src);
            dst.DataSize = dst.CharCount*2;
            return dst;
        }
   }
}