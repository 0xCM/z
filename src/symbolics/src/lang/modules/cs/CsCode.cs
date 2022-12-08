//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CsPatterns;
    using static CsModels;
    using static sys;
    using System.Linq;


    public partial class CsLang : AppService<CsLang>
    {
         public static CsEmitter emitter()
            => new();

        public class Enums
        {
            [MethodImpl(Inline)]
            public static EnumReplicantSpec replicant(FolderPath target, out EnumReplicantSpec dst, string ns = null, string type = null)
            {
                dst.Namespace = ns ?? EmptyString;
                dst.DeclaringType = type ?? EmptyString;
                dst.Target = target;
                return dst;
            }

        }


        public SwitchMapEmitter SwitchMap()
            => Service(()=> SwitchMapEmitter.create(Wf));

        public GHexStrings HexStrings()
            => Service(() => GHexStrings.create(Wf));


        public GLiteralProvider LiteralProviders()
            => Wf.GenLitProviders();

        public void EmitReplicants(EnumReplicantSpec spec, Type[] enums, FolderPath dst)
        {
            var types = enums.GroupBy(x => x.Namespace).Map(x => (x.Key, x.ToArray())).ToDictionary();
            var namespaces = types.Keys.ToIndex();
            iter(namespaces, ns => EmitReplicants(spec.WithNamespace(ns), types[ns]), true);
        }


        public StringTable EmitStringTable<K>(SymbolStrings<K> spec, CgTarget dst)
            where K : unmanaged
                => EmitStringTable(spec,SourceFile(spec.TableName, "stringtables", dst), DataFile(spec.TableName, "stringtables", dst));

        public StringTable EmitStringTable<K>(SymbolStrings<K> spec, FolderPath dst)
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
            EmitTableCode(spec, strings, dst);
            EmitTableData(def, DataFile(spec.TableName, "stringtables", dst));
            return def;
        }
 
         public void EmitTableCode(StringTableSpec syntax, ItemList<string> src, IDbArchive dst)
        {
            var path = SourceFile(syntax.TableName, "stringtables", dst);
            var emitter = text.emitter();
            render(syntax, src, emitter);
            Channel.FileEmit(emitter.Emit(), src.Count, path);
        }

        public void EmitTableCode<K>(SymbolStrings<K> spec, FilePath dst)
            where K : unmanaged
        {
            var emitter = text.emitter();
            var def = StringTables.create(spec);
            render(def.Spec, spec.Entries, emitter);
            Channel.FileEmit(emitter.Emit(), spec.Entries.Count, dst);
        }

        public void EmitTableCode(StringTableSpec spec, ReadOnlySpan<string> src, IDbArchive dst)
        {
            var path = SourceFile(spec.TableName, "stringtables", dst);
            var emitter = text.emitter();
            render(spec, src, emitter);
            Channel.FileEmit(emitter.Emit(), src.Length, path);
        }

        _FileUri EmitTableCode(StringTableSpec syntax, ItemList<string> src, CgTarget cgdst)
        {
            var dst = SourceFile(syntax.TableName, "stringtables", cgdst);
            var emitter = text.emitter();
            render(syntax, src, emitter);
            Channel.FileEmit(emitter.Emit(), src.Count, dst);
            return dst;
        }

        void EmitTableCode(StringTableSpec spec, ReadOnlySpan<string> src, CgTarget cgdst)
        {
            var dst = SourceFile(spec.TableName, "stringtables", cgdst);
            var emitter = text.emitter();
            render(spec, src, emitter);
            Channel.FileEmit(emitter.Emit(), src.Length, dst);
        }

        static uint render(in StringTableSpec spec, ItemList<string> src, ITextEmitter dst)
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

        static uint render<K>(in StringTableSpec spec, ItemList<K,string> src, ITextEmitter dst)
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

        static uint render(in StringTableSpec spec, ReadOnlySpan<string> src, ITextEmitter dst)
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

            dst.IndentLine(margin, GSpanRes.format(ByteSpans.bytespan(OffsetsProp, src.Offsets.Storage)));
            dst.AppendLine();
            dst.IndentLine(margin, GSpanRes.format(ByteSpans.charspan(DataProp,  new string(src.Content.Storage))));
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
        void EmitTableData(StringTable src, FilePath dst)
            => Channel.TableEmit(src.Rows, dst);

        void EmitTableData<K>(SymbolStrings<K> src, FilePath dst)
            where K : unmanaged
                => Channel.TableEmit(src.Rows, dst);

        public static PortableExecutableReference peref<T>()
            => PortableExecutableReference.CreateFromFile(typeof(T).Assembly.Location);

        public static PortableExecutableReference peref(Type src)
            => PortableExecutableReference.CreateFromFile(src.Assembly.Location);

        public static PortableExecutableReference[] perefs(params Type[] src)
            => src.Select(peref);

        public static SyntaxTree parse(string src)
            => CSharpSyntaxTree.ParseText(src);

        public static CSharpCompilation compilation(string name)
            => CSharpCompilation.Create(name);

        [Op]
        public static CSharpCompilation compilation(Identifier name, MetadataReference[] refs)
            => compilation(name).AddReferences(refs);

        [Op]
        public static CSharpCompilation compilation(Identifier name, MetadataReference[] refs, params SyntaxTree[] syntax)
            => compilation(name,refs).AddSyntaxTrees(syntax);

        public void EmitSymSpan<E>(FilePath dst)
            where E : unmanaged, Enum
        {
            var emitting = Channel.EmittingFile(dst);
            var container = string.Format("{0}Data", typeof(E).Name);
            using var writer = dst.AsciWriter();
            EmitSymSpan<E>(container, writer);
        }

        static void EmitSymSpan<E>(Identifier container, StreamWriter dst)
            where E : unmanaged, Enum
        {
            var buffer = text.buffer();
            GSpanRes.symrender<E>(container, buffer);
            dst.WriteLine(buffer.Emit());
        }

        public StringLitEmitter StringLits()
            => Wf.GenLiterals();

        public GAsciLookup AsciLookups()
            => Service(Wf.GenAsciLookups);

        public GSpanRes SpanRes()
            => Service(() => GSpanRes.create(Wf));

        public void EmitArrayInitializer<T>(ItemList<Constant<T>> src, ITextBuffer dst)
        {
            var count = src.Count;
            var keyword = CsData.keyword(typeof(T));
            dst.AppendFormat("{0} = new {1}[{2}]{{", src.Name, keyword, count);
            for(var i=0; i<count; i++)
            {
                ref readonly var item = ref src[i];
                dst.AppendFormat("{0},", item.Value.Format());
            }
            dst.Append("};");
        }

        public Index<Type> LoadTypes(FilePath src)
        {
            var running = Channel.Running(string.Format("Loading enum types from {0}", src.ToUri()));
            var buffer = list<Type>();
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                if(line.IsEmpty)
                    continue;

                var name = line.Content.Trim();
                var type = Type.GetType(name);
                if(type != null)
                    buffer.Add(type);
                else
                    Channel.Warn(string.Format("Unable to load {0}", name));
            }

            var dst = buffer.ToArray();
            Channel.Ran(running, string.Format("Loaded {0} enum types from {1}", dst.Length, src.ToUri()));
            return dst;
        }

        string TargetExpr(CgTarget target)
            => TargetExpressions[target];


        public FolderPath ProjectRoot(CgTarget target)
            => CgRoot + FS.folder(TargetExpr(target));

        public FolderPath SourceRoot(CgTarget target)
            => ProjectRoot(target) + FS.folder("src");

        public FilePath SourceFile(string name, IDbArchive dst)
            => dst.Path(FS.file(name, FS.Cs));

        public FilePath SourceFile(string name, string scope, CgTarget target)
            => SourceRoot(target) + FS.folder(scope) + FS.file(name, FS.Cs);

        public static FilePath SourceFile(string name, string scope, IDbArchive dst)
            => dst.Targets(scope).Path(FS.file(name, FS.Cs));

        public static FilePath DataFile(FolderPath dst, string name)
            => dst + FS.file(name, FS.Csv);

        public static FilePath SourceFile(FolderPath dst ,string name)
            => dst + FS.file(name, FS.Cs);

        public FilePath DataFile(string name, string scope, CgTarget target)
            => SourceRoot(target) + FS.folder(scope) + FS.file(name, FS.Csv);

        public static FilePath DataFile(string name, string scope, IDbArchive dst)
            => dst.Targets(scope).Path(FS.file(name, FS.Csv));

        public void EmitFile(string src, string name, IDbArchive dst)
            => Channel.FileEmit(src, SourceFile(name, dst));

        public void RenderHeader(Timestamp ts, ITextEmitter dst)
            => dst.AppendLineFormat(HeaderFormat, ts);

        static Index<string> HeaderCells = new string[]{
            "//-----------------------------------------------------------------------------",
            "// Copyright   :  (c) Chris Moore, 2022",
            "// License     :  MIT",
            "// Generated   : {0}",
            "//-----------------------------------------------------------------------------",
            };


        static FilePath ReplicantCodePath(EnumReplicantSpec spec, string ns)
            => spec.Target + FS.file(string.Format("{0}.{1}", ns, text.ifempty(spec.DeclaringType, "EnumDefs")), FS.Cs);

        static FilePath ReplicantDataPath(EnumReplicantSpec spec, string ns)
            => spec.Target + FS.file(string.Format("{0}.{1}", ns, text.ifempty(spec.DeclaringType, "EnumDefs")), FS.Csv);

        void EmitReplicants(EnumReplicantSpec spec, Type[] types)
        {
            var tops = types.Where(t => !t.IsNested);
            var enclosed = types.Where(t => t.IsNested).GroupBy(t => t.DeclaringType).Select(t => (t.Key, t.Index())).ToDictionary();
            exec(true,
                () => EmitTopReplicants(spec,tops),
                () => EmitEnclosedReplicants(spec,enclosed)
            );
        }

        void EmitTopReplicants(EnumReplicantSpec spec, Type[] tops)
        {
            var code = text.emitter();
            var data = text.emitter();
            RenderHeader(core.timestamp(), code);
            CsRender.EnumReplicants(spec, tops, code, data, e => Channel.Write(e.Format(),e.Flair));
            Channel.FileEmit(code.Emit(), tops.Length, ReplicantCodePath(spec, spec.Namespace), TextEncodingKind.Utf8);
            Channel.FileEmit(data.Emit(), tops.Length, ReplicantDataPath(spec, spec.Namespace), TextEncodingKind.Utf8);
        }

        void EmitEnclosedReplicants(EnumReplicantSpec spec, Dictionary<Type,Index<Type>> src)
        {
            var keys = src.Keys.Index();
            var code = text.emitter();
            var data = text.emitter();
            for(var i=0; i<keys.Count; i++)
            {
                ref readonly var key = ref keys[i];
                spec = spec.WithDeclaringType(key.Name);
                RenderHeader(core.timestamp(), code);
                var enclosed = src[key];
                CsRender.EnumReplicants(spec, enclosed, code, data, e => Channel.Write(e.Format(),e.Flair));
                Channel.FileEmit(code.Emit(), enclosed.Count, ReplicantCodePath(spec, spec.Namespace), TextEncodingKind.Utf8);
                Channel.FileEmit(data.Emit(), enclosed.Count, ReplicantDataPath(spec, spec.Namespace), TextEncodingKind.Utf8);
            }
        }

       static string HeaderFormat = HeaderCells.Join(Chars.Eol);            
 
        ConstLookup<CgTarget,string> TargetExpressions;

        public FolderPath CgRoot => FolderPath.Empty;

        public CsLang()
        {
            var symbols = Symbols.index<CgTarget>();
            var count = symbols.Count;
            var targets = dict<CgTarget,string>();
            for(var i=0u; i<count; i++)
            {
                ref readonly var sym = ref symbols[i];
                targets[sym.Kind] = sym.Expr.Format();
            }
            TargetExpressions = targets;
        }

    }

    public class CsCode : AppService<CsCode>
    {
 


    }
}