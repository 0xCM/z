//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    partial class Symbolic
    {
        public static SymbolStrings<K> expr<K>(string tableNs = null, string indexNs = null, string tableName = null,
            string indexName = null, bool emitIndex = true, bool parametric = true)
            where K : unmanaged, Enum
        {
            var dst = new SymbolStrings<K>();
            spec(
                tableNs: TableNs<K>(tableNs),
                indexNs: IndexNs<K>(indexNs),
                tableName: Table<K>(tableName),
                indexName: Index<K>(indexName),
                emitIndex: emitIndex,
                parametric: parametric,
                entries: SymLists.expressions(Symbols.index<K>(), Table<K>(tableName)),
                ref dst);
            return dst;
        }

        static void spec<K>(string tableNs, string indexNs, string tableName, string indexName, bool emitIndex, bool parametric, ItemList<K,string> entries, ref SymbolStrings<K> dst)
            where K : unmanaged
        {
            dst.Entries = entries;
            var count = dst.Entries.Count;
            dst.IndexName = indexName;
            dst.TableName = tableName;
            dst.IndexNs = indexName;
            dst.TableNs = tableNs;
            dst.IndexType = Enums.kind<K>();
            dst.Parametric = parametric;
            dst.EmitIndex = emitIndex;
            dst.Rows = sys.alloc<StringTableRow>(count);
            for(var j=0u; j<count; j++)
            {
                ref var row = ref dst.Rows[j];
                row.Index = j;
                row.Content = entries[j].Value;
                row.Table = dst.TableName;
            }
        }

        static uint calc<K>(ItemList<K,string> src, out Index<string> strings, out Index<char> content, out Index<uint> offsets)
            where K : unmanaged
        {
            var count = src.Count;
            strings = StringTables.strings(src);
            offsets = sys.alloc<uint>(count);
            content = sys.alloc<char>(text.length(strings.View));
            var counter = 0u;
            var j = 0u;
            for(var i=0u; i<count; i++)
            {
                offsets[i] = j;
                counter += copy(strings[i], ref j, content);
            }
            return counter;
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

        static string Table<K>(string name = null)
            where K : unmanaged
                => name ?? (typeof(K).Name + "ST");

        static string Index<K>(string name = null)
            where K : unmanaged
                => name ?? typeof(K).Name;

        static string IndexNs<K>(string name = null)
            where K : unmanaged
                => name ?? "Z0";

        static string TableNs<K>(string name = null)
            where K : unmanaged
                => name ?? "Z0.Strings";
    }
}