//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    partial struct Symbols
    {
        // public static SymbolStrings<K> strings<K>(
        //     string tableNs = null,
        //     string indexNs = null,
        //     string tableName = null,
        //     string indexName = null,
        //     bool emitIndex = true,
        //     bool parametric = true
        //     )
        //     where K : unmanaged, Enum
        // {
        //     var dst = new SymbolStrings<K>();
        //     spec(
        //         tableNs: TableNs<K>(tableNs),
        //         indexNs: IndexNs<K>(indexNs),
        //         tableName: Table<K>(tableName),
        //         indexName: Index<K>(indexName),
        //         emitIndex: emitIndex,
        //         parametric: parametric,
        //         entries: Symbols.names(Symbols.index<K>(), Table<K>(tableName)),
        //         ref dst);
        //     return dst;
        // }

        // public static SymbolStrings<K> expr<K>(string tableNs = null, string indexNs = null, string tableName = null,
        //     string indexName = null, bool emitIndex = true, bool parametric = true)
        //     where K : unmanaged, Enum
        // {
        //     var dst = new SymbolStrings<K>();
        //     spec(
        //         tableNs: TableNs<K>(tableNs),
        //         indexNs: IndexNs<K>(indexNs),
        //         tableName: Table<K>(tableName),
        //         indexName: Index<K>(indexName),
        //         emitIndex: emitIndex,
        //         parametric: parametric,
        //         entries: Symbols.expressions(Symbols.index<K>(), Table<K>(tableName)),
        //         ref dst);
        //     return dst;
        // }

        // static void spec<K>(string tableNs, string indexNs, string tableName, string indexName, bool emitIndex, bool parametric, ItemList<K,string> entries, ref SymbolStrings<K> dst)
        //     where K : unmanaged
        // {
        //     dst.Entries = entries;
        //     var count = dst.Entries.Count;
        //     dst.IndexName = indexName;
        //     dst.TableName = tableName;
        //     dst.IndexNs = indexName;
        //     dst.TableNs = tableNs;
        //     dst.IndexType = Enums.kind<K>();
        //     dst.Parametric = parametric;
        //     dst.EmitIndex = emitIndex;
        //     dst.Rows = sys.alloc<StringTableRow>(count);
        //     for(var j=0u; j<count; j++)
        //     {
        //         ref var row = ref dst.Rows[j];
        //         row.Index = j;
        //         row.Content = entries[j].Value;
        //         row.Table = dst.TableName;
        //     }
        // }

        // static uint calc<K>(ItemList<K,string> src, out Index<string> strings, out Index<char> content, out Index<uint> offsets)
        //     where K : unmanaged
        // {
        //     var count = src.Count;
        //     strings = StringTables.strings(src);
        //     offsets = sys.alloc<uint>(count);
        //     content = sys.alloc<char>(text.length(strings.View));
        //     var counter = 0u;
        //     var j = 0u;
        //     for(var i=0u; i<count; i++)
        //     {
        //         offsets[i] = j;
        //         counter += copy(strings[i], ref j, content);
        //     }
        //     return counter;
        // }
    }
}