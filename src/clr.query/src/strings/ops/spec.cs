//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class StringTables
    {
        [MethodImpl(Inline), Op]
        public static StringTableSpec spec<K>(SymbolStrings<K> spec)
            where K : unmanaged
            => new StringTableSpec(
                index: spec.IndexName,
                table: spec.TableName,
                indexNs: spec.IndexNs,
                tableNs: spec.TableNs,
                indexType: spec.IndexType,
                emitIndex: spec.EmitIndex,
                parametric: spec.Parametric
                );

        [MethodImpl(Inline), Op]
        public static StringTableSpec spec(Identifier tableNs, Identifier tableName, Identifier indexNs, Identifier indexName, ClrIntegerType indexType, bool emitIndex)
            => new StringTableSpec(tableNs, tableName, indexName, indexNs, indexType, true, emitIndex);
    }
}