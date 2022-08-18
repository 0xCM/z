//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    public partial class Symbolic
    {
        public static Index<SymKindRow> symkinds<K>()
            where K : unmanaged, Enum
        {
            var src = Symbols.index<K>();
            var count = src.Count;
            var dst = sys.alloc<SymKindRow>(count);
            symkinds(src, dst);
            return dst;
        }

        public static uint symkinds<K>(in Symbols<K> src, Span<SymKindRow> dst)
            where K : unmanaged
        {
            var symbols = src.View;
            var count = (uint)min(symbols.Length, dst.Length);
            var type = typeof(K).Name;
            for(var i=0; i<count; i++)
            {
                ref var target = ref seek(dst,i);
                ref readonly var symbol = ref skip(symbols,i);
                target.Index = symbol.Key;
                target.Value = bw64(symbol.Kind);
                target.Type = type;
                target.Name = symbol.Name;
            }
            return count;
        }
    }
}