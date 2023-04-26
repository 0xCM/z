//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CsPatterns;
    using static CsModels;
    
    using System.Linq;

    public class SymGen : Channeled<SymGen>
    {
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
            ByteSpans.symrender<E>(container, buffer);
            dst.WriteLine(buffer.Emit());
        }

        public void EmitSymbolSpan<E>(Identifier name, FolderPath dst)
            where E : unmanaged, Enum
        {
            var path = dst + FS.file(name.Format(), FS.Cs);
            using var writer = path.Writer();
            EmitSymbolSpan<E>(name,writer);
        }

        public void EmitSymbolSpan<E>(Identifier name, StreamWriter dst)
            where E : unmanaged, Enum
        {
            var buffer = text.buffer();
            ByteSpans.symrender<E>(name, buffer);
            dst.WriteLine(buffer.Emit());
        }

        public void Emit<T>(Identifier ns, LiteralSeq<T> literals, FilePath dst)
            where T : IComparable<T>, IEquatable<T>
        {
            var buffer = text.buffer();
            var margin = 0u;
            var typename = typeof(T).Name.ToLower();
            var count = literals.Count;
            buffer.IndentLine(margin, CsPatterns.NamespaceDecl(ns));
            buffer.IndentLine(margin, Open());
            margin += 4;
            buffer.IndentLine(margin, "[LiteralProvider]");
            buffer.IndentLine(margin, PublicReadonlyStruct(literals.Name));
            buffer.IndentLine(margin, Open());
            margin +=4;
            for(var i=0; i<count; i++)
            {
                ref readonly var literal = ref literals[i];
                var itemName = literal.Name;
                var itemValue = literal.Value.Format();
                if(CsData.test(itemName))
                    itemName = CsData.identifier(itemName);

                buffer.IndentLineFormat(margin, "public const {0} {1} = {2};", typename, itemName, itemValue);
            }
            margin -=4;
            buffer.IndentLine(margin, Close());
            margin -=4;
            buffer.IndentLine(margin, Close());

            var emitting = Channel.EmittingFile(dst);
            using var writer = dst.Writer();
            writer.Write(buffer.Emit());

            Channel.EmittedFile(emitting, count);
        }
 
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

        public static void render<S,T>(SwitchMap<S,T> spec, ITextEmitter dst)
            where S : unmanaged
            where T : unmanaged
        {
            var srcType = typeof(S);
            var eSrc = srcType.IsEnum;
            var dstType = typeof(T);
            var eDst = dstType.IsEnum;
            var count = Require.equal(spec.Sources.Count, spec.Targets.Count);
            if(count == 0)
                return;

            var margin = 0u;
            dst.IndentLineFormat(margin, "public static {0} {1}({2} src)", dstType.CodeName(), spec.Name, srcType.CodeName());
            margin+=4;
            dst.IndentLine(margin, "=> src switch {");
            margin+=4;
            for(var i=0; i<count; i++)
            {
                ref readonly var a = ref spec.Sources[i];
                ref readonly var b = ref spec.Targets[i];

                var srcCase = eSrc ? string.Format("{0}.{1}", srcType.Name, a) : a.ToString();
                var dstCase = eDst ? string.Format("{0}.{1}", dstType.Name, b) : b.ToString();

                dst.IndentLineFormat(margin, "{0} => {1},", srcCase, dstCase);
            }
            dst.IndentLineFormat(margin, "_ => {0}", default(T));

            margin-=4;
            dst.IndentLine(margin, "};");            
        }

        static void RenderHeader(Timestamp ts, ITextEmitter dst)
            => dst.AppendLineFormat(HeaderFormat, ts);

       static string HeaderFormat = HeaderCells.Join(Chars.Eol);            

        static Index<string> HeaderCells = new string[]{
            "//-----------------------------------------------------------------------------",
            "// Copyright   :  (c) Chris Moore, 2022",
            "// License     :  MIT",
            "// Generated   : {0}",
            "//-----------------------------------------------------------------------------",
            };

        [MethodImpl(Inline)]
        public static EnumReplicantSpec replicant(FolderPath target, out EnumReplicantSpec dst, string ns = null, string type = null)
        {
            dst.Namespace = ns ?? EmptyString;
            dst.DeclaringType = type ?? EmptyString;
            dst.Target = target;
            return dst;
        }

        public void EmitReplicants(EnumReplicantSpec spec, Type[] enums, FolderPath dst)
        {
            var types = enums.GroupBy(x => x.Namespace).Map(x => (x.Key, x.ToArray())).ToDictionary();
            var namespaces = types.Keys.ToIndex();
            iter(namespaces, ns => EmitReplicants(spec.WithNamespace(ns), types[ns]), true);
        }

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
            RenderHeader(sys.timestamp(), code);
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
                RenderHeader(sys.timestamp(), code);
                var enclosed = src[key];
                CsRender.EnumReplicants(spec, enclosed, code, data, e => Channel.Write(e.Format(),e.Flair));
                Channel.FileEmit(code.Emit(), enclosed.Count, ReplicantCodePath(spec, spec.Namespace), TextEncodingKind.Utf8);
                Channel.FileEmit(data.Emit(), enclosed.Count, ReplicantDataPath(spec, spec.Namespace), TextEncodingKind.Utf8);
            }
        }

        static FilePath ReplicantCodePath(EnumReplicantSpec spec, string ns)
            => spec.Target + FS.file(string.Format("{0}.{1}", ns, text.ifempty(spec.DeclaringType, "EnumDefs")), FS.Cs);

        static FilePath ReplicantDataPath(EnumReplicantSpec spec, string ns)
            => spec.Target + FS.file(string.Format("{0}.{1}", ns, text.ifempty(spec.DeclaringType, "EnumDefs")), FS.Csv);
    }
}