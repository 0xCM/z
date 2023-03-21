//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public sealed partial class StringTables
    {
        const NumericKind Closure = UnsignedInts;

        public static StringTable create<K>(SymbolStrings<K> src)
            where K : unmanaged
                => create(spec(src), src.Entries);

        public static StringTable create<K>(in StringTableDef spec, ItemList<K,string> src)
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

        public static StringTable create(in StringTableDef spec, ItemList<string> src)
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

        public static StringTable create(in StringTableDef syntax, ReadOnlySpan<string> src)
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
        public static StringTableDef spec<K>(SymbolStrings<K> spec)
            where K : unmanaged
            => new StringTableDef(
                index: spec.IndexName,
                table: spec.TableName,
                indexNs: spec.IndexNs,
                tableNs: spec.TableNs,
                indexType: spec.IndexType,
                emitIndex: spec.EmitIndex,
                parametric: spec.Parametric
                );

        [MethodImpl(Inline), Op]
        public static StringTableDef spec(Identifier tableNs, Identifier tableName, Identifier indexNs, Identifier indexName, ClrIntegerType indexType, bool emitIndex)
            => new StringTableDef(tableNs, tableName, indexName, indexNs, indexType, true, emitIndex);

        public static Index<string> strings<K>(ItemList<K,string> src)
            where K : unmanaged
        {
            var count = src.Length;
            var dst = sys.alloc<string>(count);
            for(var i=0; i<count; i++)
                seek(dst, i) = src[i].Value;
            return dst;
        }
        
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> entry(StringTable src, int i)
        {
            var i0 = src.Offsets[i];
            var count = src.EntryCount;
            if(i < count-1)
            {
                var i1 = src.Offsets[i+1];
                var length = i1 - i0;
                return slice(src.Content.View, i0, length);
            }
            else
                return slice(src.Content.View, i0);
        }

         [Op]
        public static Index<StringTableRow> rows<K>(ItemList<K,string> src)
            where K : unmanaged
        {
            var count = src.Count;
            var dst = sys.alloc<StringTableRow>(count);
            rows(src,dst);
            return dst;
        }

        [Op]
        public static uint rows<K>(ItemList<K,string> src, Span<StringTableRow> dst)
            where K : unmanaged
        {
            var entries = src.View;
            var count = (uint)min(entries.Length,dst.Length);
            for(var j=0u; j<count; j++)
            {
                ref var row = ref seek(dst,j);
                row.Index = j;
                row.Content = src[j].Value;
                row.Table = src.Name;
            }
            return count;
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