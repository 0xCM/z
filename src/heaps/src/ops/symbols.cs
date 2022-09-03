//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Refs;

    partial class Heaps
    {
        public static SymHeap symbols<E>()
            where E : unmanaged, Enum
                => load(Symbolic.symlits<E>());

         public static SymHeap<K,byte,byte> symbols<K>(W8 wO, W8 wL)
            where K : unmanaged, Enum
                => symbols<K,byte,byte>();

        public static SymHeap<K,ushort,byte> symbols<K>(W16 wO, W8 wL)
            where K : unmanaged, Enum
                => symbols<K,ushort,byte>();

        public static SymHeap<K,ushort,ushort> symbols<K>(W16 wO, W16 wL)
            where K : unmanaged, Enum
                => symbols<K,ushort,ushort>();

        public static SymHeap<K,uint,byte> symbols<K>(W32 wO, W8 wL)
            where K : unmanaged, Enum
                => symbols<K,uint,byte>();

        public static SymHeap<K,uint,ushort> symbols<K>(W32 wO, W16 wL)
            where K : unmanaged, Enum
                => symbols<K,uint,ushort>();

        public static SymHeap<K,O,L> symbols<K,O,L>()
            where K : unmanaged, Enum
            where O : unmanaged
            where L : unmanaged
        {
            var symbols = Symbols.index<K>();
            var count = symbols.Count;
            var content = text.buffer();
            var offsets = span<O>(count);
            var lengths = span<L>(count);
            var entries = span<HeapEntry<K,O,L>>(count);
            var offset = 0u;
            for(var i=0; i<symbols.Count; i++)
            {
                var expr = symbols[i].Expr.Data;
                var length = (uint)expr.Length;
                seek(entries,i) = new HeapEntry<K,O,L>(symbols[i].Kind, @as<uint,O>(offset), @as<uint,L>(length));
                content.Append(expr);
                offset += length;
            }
            return new SymHeap<K,O,L>(entries,content.Emit());
        }
    }
}