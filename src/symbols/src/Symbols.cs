//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    [ApiHost]
    public readonly partial struct Symbols
    {
        static int SegCount;

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

        [Op,Closures(Closure)]
        public static ItemList<K,string> expressions<K>(Symbols<K> src, string name = null)
            where K : unmanaged
                => new ItemList<K,string>(name ?? (typeof(K).Name + "Expressions"),
                    src.Storage.Select(x => new ListItem<K,string>(x, x.Expr.Text)));
        [Op,Closures(Closure)]
        public static ItemList<ushort,string> expressions<K>(Symbols<K> src, W16 w, string name = null)
            where K : unmanaged
                => new ItemList<ushort,string>(name ?? (typeof(K).Name + "Expressions"),
                    src.Storage.Select(x => new ListItem<ushort,string>((ushort)x.Value,x.Expr.Text)));

        [Op,Closures(Closure)]
        public static ItemList<K,string> names<K>(Symbols<K> src, string name = null)
            where K : unmanaged
                => new ItemList<K,string>(name ?? (typeof(K).Name + "Names"),
                    src.Storage.Select(x => new ListItem<K,string>(x,x.Name)));

        [Op,Closures(Closure)]
        public static ItemList<ushort,string> names<K>(Symbols<K> src, W16 w, string name = null)
            where K : unmanaged
                => new ItemList<ushort,string>(name ?? (typeof(K).Name + "Names"),
                    src.Storage.Select(x => new ListItem<ushort,string>((ushort)x.Value,x.Name)));

        [Op, Closures(UInt64k)]
        public static SymStore<T> store<T>(ushort capacity)
            => new SymStore<T>((uint)inc(ref SegCount), sys.alloc<T>(capacity));

        [Op, Closures(UInt64k)]
        public static SymStore<T> store<T>(uint capacity)
            => new SymStore<T>((uint)inc(ref SegCount), sys.alloc<T>(capacity));

        public static SymbolSet set(Identifier name, ClrEnumKind type, DataSize size, ReadOnlySpan<string> members, NumericBaseKind @base = NumericBaseKind.Base10)
        {
            var count = (uint)members.Length;
            var dst = new SymbolSet(count, name, type, size, @base, false, EmptyString);
            for(var i=0u; i<count; i++)
            {
                ref readonly var member = ref skip(members,i);
                dst.Symbols[i] = member;
                dst.Names[i] = member;
                dst.Values[i] = i;
                dst.Descriptions[i] = EmptyString;
                dst.Positions[i] = i;
            }
            return dst;
        }


        public static SymbolSet set(Type src)
        {
            var specs = Symbols.syminfo(src);
            var tag = src.Tag<SymSourceAttribute>();
            var count = specs.Count;
            var size = Sizes.measure(src);
            var flags = src.Tag<FlagsAttribute>().IsSome();
            var @base = tag.MapValueOrDefault(x => x.NumericBase, NumericBaseKind.Base10);
            var type = Enums.@base(src);
            var group = tag.MapValueOrDefault(x => x.SymGroup, EmptyString);
            var dst = new SymbolSet(count, src.Name, type, size, @base, flags, group);
            for(var i=0; i<count; i++)
            {
                ref readonly var spec = ref specs[i];
                dst.Symbols[i] = spec.Expr;
                dst.Names[i] = spec.Name;
                dst.Values[i] = spec.Value;
                dst.Descriptions[i] = spec.Description;
                dst.Positions[i] = spec.Index;
            }
            return dst;
        }


        const NumericKind Closure = UnsignedInts;
    }
}