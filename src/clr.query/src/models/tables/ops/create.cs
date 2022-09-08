//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class StringTables
    {
        public static StringTable create<K>(SymbolStrings<K> src)
            where K : unmanaged
                => create(spec(src), src.Entries);

        public static StringTable create<K>(in StringTableSpec spec, ItemList<K,string> src)
            where K : unmanaged
        {
            var count = src.Length;
            var strings = span<string>(count);
            for(var i=0; i<count; i++)
                seek(strings, i) = src[i].Value;
            var offset = 0u;
            var offsets = sys.alloc<uint>(count);
            var content = sys.alloc<char>(text.length(strings));
            var j = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var entry = ref src[i];
                seek(offsets, i) = j;
                copy(entry.Value, ref j, content);
            }
            return new StringTable(spec, content, offsets, src.Map(x => x.Value), rows(src));
        }

        public static StringTable create(in StringTableSpec spec, ItemList<string> src)
        {
            var count = src.Length;
            var strings = span<string>(count);
            for(var i=0; i<count; i++)
                seek(strings, src[i].Key) = src[i].Value;

            var offset = 0u;
            var offsets = sys.alloc<uint>(count);
            var chars = sys.alloc<char>(text.length(strings));
            ref var cuts = ref first(offsets);
            var j = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var entry = ref src[i];
                seek(cuts, i) = j;
                copy(entry.Value, ref j, chars);
            }
            return new StringTable(spec, chars, offsets, src.Map(x => x.Value),
                rows(new ItemList<uint,string>(spec.TableName, src.View.Map(x => new ListItem<uint,string>(x.Key,x.Value)))));
        }

        public static StringTable create(in StringTableSpec syntax, ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var offset = 0u;
            var offsets = sys.alloc<uint>(count);
            var chars = sys.alloc<char>(text.length(src));
            ref var cuts = ref first(offsets);
            var j = 0u;
            for(var i=0u; i<count; i++)
            {
                seek(cuts, i) = j;
                copy(skip(src,i), ref j, chars);
            }
            return new StringTable(syntax, chars, offsets);
        }

        [MethodImpl(Inline), Op]
        static uint copy(ReadOnlySpan<char> src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var count = src.Length;
            for(var j=0; j<count; j++)
                seek(dst,i++) = skip(src,j);
            return i - i0;
        }
    }
}