//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using static sys;
    using static Delegates;

    using Z0.Roslyn;

    [ApiHost]
    public sealed class RoslnCmd : AppService<RoslnCmd>
    {
        AppDb AppDb => AppDb.Service;

        [MethodImpl(Inline),Op]
        public static uint nonempty(ReadOnlySpan<CaSymbol> src, Span<CaSymbol> dst)
        {
            var counter = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(src,i);
                if(symbol.IsNonEmpty)
                    seek(dst,counter++) = symbol;
            }
            return counter;
        }

        public static void methods(ReadOnlySpan<TypeSymbol> src, Span<CaSymbol> buffer, ref CaSymbolSet dst)
        {
            var target = buffer;
            var offset = 0u;
            for(var i=0; i<src.Length; i++)
            {
                var members = skip(src,i).GetMembers();
                var count = filter(members, SymbolKind.Method, target);
                target = slice(buffer, offset, count);
                offset += count;
            }

            var collected = slice(buffer, 0, offset);
            var kNonEmpty = nonempty(collected, collected);
            collected = slice(buffer, 0, kNonEmpty);
            dst.Methods = CaSymbols.convert<MethodSymbol>(collected);
        }

        public static MetadataReference reference(FilePath src)
        {
            var xml = src.ChangeExtension(FS.Xml);
            var doc = XmlDocProvider.create(xml);
            var props = default(MetadataReferenceProperties);
            return MetadataReference.CreateFromFile(src.Name, props, doc);
        }

        public static MetadataReference reference(Assembly src)
        {
            var path = FS.path(src.Location);
            var xml = path.ChangeExtension(FS.Xml);
            var props = default(MetadataReferenceProperties);
            if(xml.Exists)
            {
                var doc = XmlDocProvider.create(xml);
                var reference = MetadataReference.CreateFromFile(path.Name, props, doc);
                return reference;
            }
            else
                return MetadataReference.CreateFromFile(path.Name, props);
        }

        public static Index<MetadataReference> refs(ReadOnlySpan<FilePath> src)
        {
            var count = src.Length;
            var dst = alloc<MetadataReference>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = reference(skip(src,i));
            return dst;
        }

        public static uint MemberCount(ReadOnlySpan<TypeSymbol> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(src,i);
                if(symbol.IsNonEmpty)
                {
                    var members = symbol.GetMembers();
                    total += (uint)members.Length;
                }
            }
            return total;
        }

        [MethodImpl(Inline), Op]
        public static SymbolKindFilter filter(SymbolKind kind)
            => new SymbolKindFilter(kind);

        [MethodImpl(Inline), Op]
        public static uint filter(ReadOnlySpan<CaSymbol> src, SymbolKind kind, Span<CaSymbol> dst)
            => gcalc.filter(src, filter(kind), dst);

        [MethodImpl(Inline), Op]
        public static MemberProducer producer()
            => new MemberProducer();

        [MethodImpl(Inline), Op]
        public static SymbolicAssembly join(Assembly src, AssemblySymbol sym)
            => (src,sym);

        [MethodImpl(Inline), Op]
        public static SymbolicMethod join(MethodInfo src, MethodSymbol sym)
            => (src,sym);

        [MethodImpl(Inline), Op]
        public static SymbolicType join(Type src, TypeSymbol sym)
            => (src,sym);

        //ApiMd ApiMd => Wf.ApiMd();

        Roslyn Roslyn => Wf.Roslyn();


        [CmdOp("api/emit/pdbinfo")]
        void EmitPdbInfo()
        {
            EmitMethodSymbols(ApiModules.parts());
            //EmitTypeSymbols(ApiMd.Components);
        }

        void EmitMethodSymbols(ReadOnlySpan<Assembly> src)
        {
            iter(src, component =>{
                var symbols = SymbolizeMethods(component);
                var name = component.Id().PartName();
                var dst = AppDb.ApiTargets("pdb").Path($"{name}.methods", FileKind.Csv);
                var emitting = EmittingFile(dst);
                using var writer = dst.Utf8Writer();
                iteri(symbols, (i,s) => writer.AppendLineFormat("{0,-8} | {1}", i, s.Format()));
                EmittedFile(emitting, symbols.Length);
            });
        }

        public void SymbolizeMethods(ReadOnlySpan<Assembly> src, ReadOnlySpanTarget<MethodSymbol> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                dst(SymbolizeMethods(skip(src,i)));
        }

        public ReadOnlySpan<MethodSymbol> SymbolizeMethods(Assembly src)
            => Symbolize(src).Methods;

        [CmdOp("api/pdbs")]
        void CollectComponentSymbols()
        {
            var components = ApiModules.parts();
            var flow = Running(string.Format("Collecting method symbols for {0} assemblies", components.Length));
            var symbolic = Wf.RoslynCmd();
            var collector = new MethodSymbolCollector();
            SymbolizeMethods(components, collector.Deposit);
            var items = collector.Collected;
            var count = items.Length;
            Ran(flow, string.Format("Collected {0} method symbols", count));
            var dst = AppDb.ApiTargets().Path("api","methods", FileKind.Md);
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
            {
                ref readonly var item = ref skip(items,i);
                writer.WriteLine(item.Format());
            }
            EmittedFile(emitting, count);
        }

        void EmitTypeSymbols(ReadOnlySpan<Assembly> src)
        {
            var counter = 0u;
            foreach(var part in src)
            {
                var dst = AppDb.ApiTargets("pdb").Path(part.Id().PartName().Format(), FileKind.Md);
                var symbols = Symbolize(part);
                var items = symbols.Types;
                counter += (uint)items.Length;
            }
        }

        public CaSymbolSet Symbolize(Assembly src)
        {
            var metadata = reference(src);
            var dst = CaSymbols.set(metadata);
            var name = $"{src.GetSimpleName()}.compilation";
            var comp = Roslyn.Compilation(name, metadata);
            var asymbol = comp.GetAssemblySymbol(metadata);
            dst.Assemblies = sys.array(asymbol);
            var gns = asymbol.GlobalNamespace;
            var types = gns.GetTypes();
            dst.Types = types;
            var allocation = span<CaSymbol>(MemberCount(types));
            methods(types, allocation, ref dst);
            return dst;
        }

        [CmdOp("api/emit/sigs")]
        void EmitMemberSigs()
        {
            //iter(ApiMd.Parts, a => EmitMemberInfo(Emitter, a ), true);
        }

        static void emit(TypeSymbol type, ITextEmitter dst)
        {
            var indent = 0;
            dst.AppendLine(type);
            var members = type.GetMembers();
            var count = members.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var member = ref skip(members,i);
                var docs = member.DocXml();
                var desc = member.Format();
                dst.AppendLine(desc);
                if(docs.IsNonEmpty)
                    dst.AppendLine(docs);
            }
        }

        void EmitMemberInfo(IWfChannel channel, Assembly src)
        {
            var tool = Wf.Roslyn();
            var name = $"{src.GetSimpleName()}.compilation";
            var metadata = RoslnCmd.reference(src);
            var comp = tool.Compilation(name, metadata);
            var symbol = comp.GetAssemblySymbol(metadata);
            var gns = symbol.GlobalNamespace;
            var types = gns.GetTypes();
            var path = AppDb.ApiTargets("sigs").Path(src.GetSimpleName(), FileKind.Txt);
            var flow = channel.EmittingFile(path);
            using var emitter = path.Emitter(UTF8);
            iter(types, t => emit(t,emitter));
            channel.EmittedFile(flow,types.Length);
        }

        public readonly struct SymbolKindFilter : IUnaryPred<SymbolKindFilter,CaSymbol>
        {
            public SymbolKind Kind {get;}

            [MethodImpl(Inline), Op]
            public SymbolKindFilter(SymbolKind kind)
                => Kind = kind;

            [MethodImpl(Inline), Op]
            public bit Invoke(CaSymbol a)
                => a.Kind == Kind;
        }

        public readonly struct MemberProducer : IReadOnlySpanFactory<MemberProducer, TypeSymbol, CaSymbol>
        {
            [MethodImpl(Inline), Op]
            public ReadOnlySpan<CaSymbol> Invoke(in TypeSymbol src)
                => src.GetMembers();
        }
    }
}