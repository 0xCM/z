//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CsLang
    {
        public StringTable EmitStringTable<K>(SymbolStrings<K> spec, CgTarget dst)
            where K : unmanaged
                => EmitStringTable(spec,SourceFile(spec.TableName, "stringtables", dst), DataFile(spec.TableName, "stringtables", dst));

        public StringTable EmitStringTable<K>(SymbolStrings<K> spec, FS.FolderPath dst)
            where K : unmanaged
                => EmitStringTable(spec,SourceFile(dst, spec.TableName), DataFile(dst, spec.TableName));

        public StringTable EmitStringTable<K>(SymbolStrings<K> spec, FilePath code, FilePath data)
            where K : unmanaged
        {
            var def = StringTables.create(spec);
            EmitTableCode(spec, code);
            EmitTableData(spec, data);
            return def;
        }

        public StringTable EmitStringTable(Identifier tableNs, ClrIntegerType indexType, ItemList<string> src, CgTarget dst, bool emitIndex)
        {
            var name = src.Name;
            var spec = StringTables.spec(
                tableNs: tableNs,
                tableName: name +"ST",
                indexNs: tableNs,
                indexName: name + "Kind",
                indexType: indexType,
                emitIndex: emitIndex);
            var def = StringTables.create(spec, src);
            EmitTableCode(spec, src, dst);
            EmitTableData(def, DataFile(spec.TableName, "stringtables", dst));
            return def;
        }

        public StringTable EmitStringTable(Identifier tableNs, ClrIntegerType indexType, ItemList<string> src, IDbArchive dst, bool emitIndex)
        {
            var name = src.Name;
            var spec = StringTables.spec(
                tableNs: tableNs,
                tableName: name +"ST",
                indexNs: tableNs,
                indexName: name + "Kind",
                indexType: indexType,
                emitIndex: emitIndex);
            var def = StringTables.create(spec, src);
            EmitTableCode(spec, src, dst);
            EmitTableData(def, DataFile(spec.TableName, "stringtables", dst));
            return def;
        }

        public StringTable EmitStringTable(Identifier tableNs, Identifier tableName, Identifier indexName, ReadOnlySpan<string> strings, CgTarget dst, bool emitIndex)
        {
            var spec = StringTables.spec(
                tableNs: tableNs,
                tableName: tableName,
                indexName: indexName,
                indexNs: tableNs,
                indexType:ClrIntegerType.Empty,
                emitIndex:emitIndex
                );
            var def = StringTables.create(spec, strings);
            EmitTableCode(spec, strings, dst);
            EmitTableData(def, DataFile(spec.TableName, "stringtables", dst));
            return def;
        }

        public StringTable EmitStringTable(Identifier tableNs, Identifier tableName, Identifier indexName, ReadOnlySpan<string> strings, bool emitIndex, IDbTargets dst)
        {
            var spec = StringTables.spec(
                tableNs: tableNs,
                tableName: tableName,
                indexName: indexName,
                indexNs: tableNs,
                indexType:ClrIntegerType.Empty,
                emitIndex:emitIndex
                );
            var def = StringTables.create(spec, strings);
            EmitTableCode(spec, strings, dst);
            EmitTableData(def, DataFile(spec.TableName, "stringtables", dst));
            return def;
        }
    }
}