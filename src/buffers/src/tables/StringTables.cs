//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CsPatterns;

    [ApiHost]
    public sealed class StringTables : Channeled<StringTables>
    {
        const NumericKind Closure = UnsignedInts;

        public static FilePath DataFile(string name, string scope, IDbArchive dst)
            => dst.Targets(scope).Path(FS.file(name, FS.Csv));

        public static FilePath SourceFile(string name, string scope, IDbArchive dst)
            => dst.Targets(scope).Path(FS.file(name, FS.Cs));

        public StringTable EmitStringTable<K>(SymbolStrings<K> spec, FolderPath dst)
            where K : unmanaged
                => EmitStringTable(spec,SourceFile(dst, spec.TableName), DataFile(dst, spec.TableName));

        public StringTable EmitStringTable<K>(SymbolStrings<K> spec, FilePath code, FilePath data)
            where K : unmanaged
        {
            var def = StringTables.create(spec);
            EmitCode(spec, code);
            EmitData(spec, data);
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
            EmitCode(spec, src, dst);
            EmitData(def, DataFile(spec.TableName, "stringtables", dst));
            return def;
        }

        public StringTable EmitStringTable(Identifier tableNs, Identifier tableName, Identifier indexName, ReadOnlySpan<string> strings, bool emitIndex, IDbArchive dst)
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
            EmitCode(spec, strings, dst);
            EmitData(def, DataFile(spec.TableName, "stringtables", dst));
            return def;
        }

        void EmitData(StringTable src, FilePath dst)
            => Channel.TableEmit(src.Rows, dst);

        void EmitData<K>(SymbolStrings<K> src, FilePath dst)
            where K : unmanaged
                => Channel.TableEmit(src.Rows, dst);

        void EmitCode(StringTableDef syntax, ItemList<string> src, IDbArchive dst)
        {
            var path = SourceFile(syntax.TableName, "stringtables", dst);
            var emitter = text.emitter();
            render(syntax, src, emitter);
            Channel.FileEmit(emitter.Emit(), src.Count, path);
        }

        void EmitCode<K>(SymbolStrings<K> spec, FilePath dst)
            where K : unmanaged
        {
            var emitter = text.emitter();
            var def = StringTables.create(spec);
            render(def.Spec, spec.Entries, emitter);
            Channel.FileEmit(emitter.Emit(), spec.Entries.Count, dst);
        }

        void EmitCode(StringTableDef spec, ReadOnlySpan<string> src, IDbArchive dst)
        {
            var path = SourceFile(spec.TableName, "stringtables", dst);
            var emitter = text.emitter();
            render(spec, src, emitter);
            Channel.FileEmit(emitter.Emit(), src.Length, path);
        }

        static FilePath DataFile(FolderPath dst, string name)
            => dst + FS.file(name, FS.Csv);

        static FilePath SourceFile(FolderPath dst, string name)
            => dst + FS.file(name, FS.Cs);

        static uint render(in StringTableDef spec, ItemList<string> src, ITextEmitter dst)
        {
            dst.WriteLine(string.Format("namespace {0}", spec.TableNs));
            dst.WriteLine(Open());
            dst.WriteLine(string.Format("    using {0};", "System"));
            dst.WriteLine();
            dst.WriteLine(string.Format("    using static {0};", "core"));
            dst.WriteLine();
            render(4, StringTables.create(spec, src), dst);
            dst.WriteLine(Close());
            return (uint)src.Length;
        }

        static uint render<K>(in StringTableDef spec, ItemList<K,string> src, ITextEmitter dst)
            where K : unmanaged
        {
            dst.WriteLine(string.Format("namespace {0}", spec.TableNs));
            dst.WriteLine(Open());
            dst.WriteLine(string.Format("    using {0};", "System"));
            dst.WriteLine();
            dst.WriteLine(string.Format("    using static {0};", "core"));
            dst.WriteLine();
            render(4, StringTables.create(spec, src), dst);
            dst.WriteLine(Close());
            return (uint)src.Length;
        }

        static uint render(in StringTableDef spec, ReadOnlySpan<string> src, ITextEmitter dst)
        {
            dst.WriteLine(string.Format("namespace {0}", spec.TableNs));
            dst.WriteLine(Open());
            dst.WriteLine(string.Format("    using {0};", "System"));
            dst.WriteLine();
            dst.WriteLine(string.Format("    using static {0};", "core"));
            dst.WriteLine();
            render(4, StringTables.create(spec, src), dst);
            dst.WriteLine(Close());
            return (uint)src.Length;
        }

        static void render(uint margin, StringTable src, ITextEmitter dst)
        {
            var syntax = src.Spec;
            if(src.Spec.EmitIndex)
            {
                RenderIndex(margin, src, dst);
                dst.AppendLine();
            }

            dst.IndentLine(margin, CustomAttribute(nameof(ApiCompleteAttribute)));
            dst.IndentLine(margin, PublicReadonlyStruct(syntax.TableName));
            dst.IndentLine(margin, Open());
            margin+=4;

            var OffsetsProp = nameof(MemoryStrings.Offsets);
            var DataProp = nameof(MemoryStrings.Data);
            var EntryCountProp = nameof(MemoryStrings.EntryCount);
            var CharCountProp = nameof(MemoryStrings.CharCount);
            var CharBaseProp = nameof(MemoryStrings.CharBase);
            var OffsetBaseProp = nameof(MemoryStrings.OffsetBase);
            var StringsProp = "Strings";

            dst.IndentLine(margin, Constant(EntryCountProp, src.EntryCount));
            dst.AppendLine();

            dst.IndentLine(margin, Constant(CharCountProp, src.Content.Count));
            dst.AppendLine();

            dst.IndentLine(margin, StaticLambdaProp(nameof(MemoryAddress), CharBaseProp, Call("address", DataProp)));
            dst.AppendLine();

            dst.IndentLine(margin, StaticLambdaProp(nameof(MemoryAddress), OffsetBaseProp, Call("address", OffsetsProp)));
            dst.AppendLine();

            var FactoryName = string.Format("{0}.{1}", nameof(MemoryStrings), nameof(MemoryStrings.create));
            var FactoryCreate = Call(FactoryName, OffsetsProp, DataProp);

            if(src.Spec.Parametric)
                dst.IndentLine(margin, StaticLambdaProp(string.Format("{0}<{1}>", nameof(MemoryStrings), syntax.IndexName), StringsProp, FactoryCreate));
            else
                dst.IndentLine(margin, StaticLambdaProp(nameof(MemoryStrings), StringsProp, FactoryCreate));
            dst.AppendLine();

            dst.IndentLine(margin, ByteSpans.format(ByteSpans.bytespan(OffsetsProp, src.Offsets.Storage)));
            dst.AppendLine();
            dst.IndentLine(margin, ByteSpans.format(ByteSpans.charspan(DataProp,  new string(src.Content.Storage))));
            margin-=4;
            dst.IndentLine(margin, Close());
        }

        static void RenderIndex(uint margin, StringTable src, ITextEmitter dst)
        {
            var count = src.EntryCount;
            var syntax = src.Spec;
            dst.IndentLine(margin, string.Format("public enum {0} : {1}", syntax.IndexName, syntax.IndexType.Keyword));
            dst.IndentLine(margin, Chars.LBrace);
            margin+=4;
            for(var i=0u; i<count; i++)
            {
                ref readonly var name = ref src.Names[i];
                if(text.empty(name))
                    break;
                dst.IndentLineFormat(margin, "{0} = {1},", name, i);
            }
            margin-=4;
            dst.IndentLine(margin, Chars.RBrace);
        }        
 
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