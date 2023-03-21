//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class SymbolStrings
    {
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

        public static SymbolStrings<K> strings<K>(
            string tableNs = null,
            string indexNs = null,
            string tableName = null,
            string indexName = null,
            bool emitIndex = true,
            bool parametric = true
            )
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
                entries: Symbols.names(Symbols.index<K>(), Table<K>(tableName)),
                ref dst);
            return dst;
        }

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
                entries: Symbols.expressions(Symbols.index<K>(), Table<K>(tableName)),
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
    }
}