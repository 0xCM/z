//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using static ApiDb;

    public class MdEmit
    {
        public static void types(IWfChannel channel, ReadOnlySpan<Type> src, FileUri dst)
        {
            var emitter = text.emitter();
            for(var i=0; i<src.Length; i++)
                emitter.AppendLine(skip(src,i).AssemblyQualifiedName);
            channel.FileEmit(emitter.Emit(),dst, TextEncodingKind.Utf8);
        }

        public static void types(IWfChannel channel, IEnumerable<AssemblyFile> src, FolderPath dst)
        {
            iter(src, file => {
                try
                {
                var types = file.Load().Types();
                var @base = Archives.identifier(file.AssemblyPath.FolderPath);
                var filename = FS.file($"{@base}.{file.AssemblyPath.FileName.WithoutExtension}", FileKind.List);
                var path = dst + filename;
                MdEmit.types(channel, types, path);
                }
                catch(Exception)
                {
                    channel.Warn($"Unable to load {file}");
                }
            }, true);            
        }
    }

    public class ApiMdEmitter : AppService<ApiMdEmitter>
    {
        IDbArchive Target;

        AppDb AppDb => AppDb.Service;

        public static ApiMdEmitter init(IWfRuntime wf)
        {
            var svc = create(wf);
            return svc;
        }

        public void Emit(IApiCatalog catalog, IDbArchive dst)
        {
            Target = dst;
            Emit(catalog.Assemblies, Target);
        }

        public void EmitLiterals(Assembly[] src, IApiPack dst)
            => iter(src, c => EmitFieldLiterals(c, dst), true);

        void EmitFieldLiterals(Assembly src, IApiPack dst)
        {
            var fields = ClrFields.literals(src.Types());
            if(fields.Length != 0)
                Emit(fields, dst.Metadata("literals").Path(FS.file(src.GetSimpleName(), FileKind.Csv)));
        }

        void Emit(ReadOnlySpan<FieldRef> src, FilePath dst)
        {
            const string Sep = "| ";

            static string formatLine(in FieldRef src)
            {
                const string Sep = "| ";

                var content = ClrLiterals.format(src).PadRight(48);
                var address = src.Address.Format().PadRight(16);
                var width = src.Width.Content.ToString().PadRight(16);
                var type = src.Field.DeclaringType.Name.PadRight(36);
                var field = src.Field.Name.PadRight(36);
                var line = string.Concat(address, Sep, width, Sep,type, Sep, field, Sep, content, Sep);
                return line;
            }

            static string FormatHeader()
                => string.Concat(
                    "FieldAddress".PadRight(16), Sep,
                    "FieldWidth".PadRight(16), Sep,
                    "DeclaringType".PadRight(36), Sep,
                    "FieldName".PadRight(36), Sep,
                    "Value".PadRight(48), Sep
                    );

            var flow = EmittingFile(dst);
            var input = src;
            var count = input.Length;
            var buffer = sys.alloc<Paired<FieldRef,string>>(count);
            ref var emissions = ref first(buffer);

            using var writer = dst.Writer();
            writer.WriteLine(FormatHeader());

            for(var i=0u; i<count; i++)
            {
                try
                {
                    ref readonly var field = ref skip(input,i);
                    var formatted = formatLine(field);
                    seek(emissions, i) = (field,formatted);

                    writer.WriteLine(formatted);
                }
                catch(Exception e)
                {
                    Warn(e.Message);
                }
            }

            EmittedFile(flow, count);
        }

        public void Emit(Assembly[] src, IDbArchive dst)
        {
            Target = dst;
            var symlits = Heaps.symlits(src);
            exec(true,
                () => EmitDataFlows(src),
                () => EmitSymLits(symlits),
                () => EmitApiLiterals(src),
                () => EmitParsers(src),
                () => EmitApiDeps(),
                () => EmitApiTables(src,AppDb.ApiTargets()),
                () => EmitApiTokens(src),
                () => EmitApiCommands(src),
                () => EmitApiTypes(src, AppDb.ApiTargets()),
                () => EmitTypeLists(src),
                () => EmitApiSymbols(src),
                () => EmitPartList(src),
                () => EmitSymHeap(Heaps.load(symlits))
            );
        }

        public void EmitAssets(params Assembly[] src)
        {
            AppDb.ApiTargets("assets").Delete();            
            var entries = EmitAssets(Assets.extract(src));
            EmitAssetEntries(entries);
        }

        public void EmitTypeList(ReadOnlySpan<Type> src, FileUri dst)
            => MdEmit.types(Channel, src, dst);

        public static ReadOnlySeq<ApiLiteralInfo> apilits(Assembly[] src)
        {
            var providers = src.Types().Tagged<LiteralProviderAttribute>()
                  .Select(x => (Type:x, Attrib:x.Tag<LiteralProviderAttribute>().Require()))
                  .Select(x => new LiteralProvider(x.Type.Assembly.Id(), x.Type, x.Attrib.Group, x.Type.Name)).Index();
            var literals = Literals.runtimelits(providers);
            var count = literals.Count;
            var dst = sys.alloc<ApiLiteralInfo>(count);
            for(var i=0u; i<count; i++)
            {
                ref var target = ref seek(dst,i);
                ref readonly var literal = ref literals[i];
                target.Part = literal.Part;
                target.Type = literal.Type;
                target.Group = literal.Group;
                target.Name = literal.Name;
                target.Kind = literal.Kind.ToString();
                target.Value = literal.Value;
            }
            return dst.Sort();
        }

        public void EmitParsers(params Assembly[] src)
        {
            const string RenderPattern = "{0,-8} | {1,-8} | {2}";
            var cols = new string[]{"Seq", "Returns", "Target"};
            var parsers = Parsers.contracted(src);
            var emitter = text.emitter();
            emitter.AppendLineFormat(RenderPattern, cols);
            var i=0u;
            iter(parsers.Values.Index().Sort(), parser
                => emitter.AppendLineFormat(RenderPattern,
                    i++,
                    parser.ResultType.DisplayName(),
                    parser.TargetType.DisplayName()
                    ));
            Channel.FileEmit(emitter.Emit(), parsers.Count, AppDb.ApiTargets().Path("api.parsers", FileKind.Csv));
        }

        public void EmitApiLiterals(params Assembly[] src)
            => EmitApiLiterals(apilits(src));

        public void EmitApiCommands(params Assembly[] src)
            => Emit(ApiCmdTypes.records(src));

        public void EmitApiTypes(Assembly[] src, IDbArchive dst)
            => Channel.TableEmit(DataTypeInfo(src), dst.Table<ApiTypeInfo>());

        public void EmitPartList(params Assembly[] src)
        {
            var dst = text.emitter();
            var seq = src.ToSeq();
            for(var i=0; i<seq.Count; i++)
                dst.AppendLine(seq[i].GetName().FullName);
            Channel.FileEmit(dst.Emit(), AppDb.ApiTargets().Path("api.parts", FileKind.List));
        }

        public void EmitDataFlows(params Assembly[] src)
            => Emit(CalcDataFlows(src));

        public void EmitApiTables(ReadOnlySeq<Assembly> src, IDbArchive dst)
            => Channel.TableEmit(CalcTableFields(src), dst.Table<ApiTableField>());

        public void EmitApiTokens(params Assembly[] src)
            => EmitApiTokens(CalcApiTokens(src));

        public void EmitHeap(SymHeap src)
            => Heaps.emit(src, AppDb.ApiTargets().Table<SymHeapRecord>(), Channel);

        public void EmitTypeLists(params Assembly[] src)
        {            
            MdEmit.types(Channel, EnumTypes(src), AppDb.ApiTargets().Path("api.types.enums", FileKind.List));
            MdEmit.types(Channel, src.TaggedTypes<RecordAttribute>().Select(x => x.Type), AppDb.ApiTargets().Path("api.types.records", FileKind.List));
        }

        public void EmitApiComments()
            => Comments.Collect(AppDb.ApiTargets(comments));

        public void EmitApiDeps(Assembly src, FilePath dst)
        {
            var deps = JsonDeps.load(src);
            var buffer = list<string>();
            iteri(deps.RuntimeLibs(), (i,lib) => buffer.Add(string.Format("{0:D4}:{1}",i,lib)));
            var emitter = text.emitter();
            iter(buffer, line => emitter.AppendLine(line));
            Channel.FileEmit(emitter.Emit(), buffer.Count, dst);
        }

        public void EmitApiDeps()
            => EmitApiDeps(EntryAssembly, AppDb.ApiTargets().Path($"{EntryAssembly.GetSimpleName()}", FileKind.DepsList));

        public void EmitApiSymbols(params Assembly[] src)
            => Channel.TableEmit(Heaps.symlits(src), AppDb.ApiTargets().Table<SymLiteralRow>(), UTF16);

        public void EmitTokens(Type src)
        {
            var syms = Symbols.syminfo(src);
            var name = src.Name.ToLower();
            var dst = Target.PrefixedTable<SymInfo>("tokens" + "." +  name);
            Channel.TableEmit(syms, dst, TextEncodingKind.Unicode);
        }

        public void EmitTypeList(string name, ReadOnlySpan<Type> src)
        {
            var path = AppDb.ApiTargets().Path(name, FileKind.List);
            var dst = text.emitter();
            for(var i=0; i<src.Length; i++)
                dst.AppendLine(skip(src,i).AssemblyQualifiedName);
            Channel.FileEmit(dst.Emit(), src.Length, path);
        }

        IDbArchive ApiTargets(string scope)
            => AppDb.ApiTargets(scope);

        XmlComments Comments 
            => Wf.ApiComments();

        ReadOnlySeq<ApiTypeInfo> DataTypeInfo(Assembly[] src)
            => ApiTypes.describe(ApiTypes.discover(src));

        Type[] EnumTypes(Assembly[] src)
            => src.Enums().Where(x => x.ContainsGenericParameters == false);

        void EmitSymHeap(SymHeap src)
            => Heaps.emit(src, Target.Table<SymHeapRecord>(), Channel);

        void EmitComments(IApiPack dst)
            => Wf.ApiComments().Collect(dst);

        void EmitApiDeps(IApiPack dst)
        {
            var src = ExecutingPart.Assembly;
            var path = Target.Path($"{src.GetSimpleName()}", FileKind.DepsList);
            if(path.Exists)
                EmitApiDeps(src, path);
        }

        ReadOnlySeq<DataFlowSpec> CalcDataFlows(Assembly[] src)
        {
            var flows = DataFlow.discover(src);
            var count = flows.Length;
            var buffer = alloc<DataFlowSpec>(count);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var flow = ref flows[i];
                dst.Actor = flow.Actor;
                dst.Source = flow.Source?.ToString() ?? EmptyString;
                dst.Target = flow.Target?.ToString() ?? EmptyString;
                dst.Description = flow.Format();
            }
            return buffer.Sort();
        }

        ReadOnlySeq<AssetCatalogEntry> EmitAssets(ReadOnlySeq<ComponentAssets> src)
        {
            var counter = 0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var assets = ref src[i];
                var count = assets.Count;
                var targets = AppDb.ApiTargets("assets").Targets(assets.Source.GetSimpleName());
                for(var j=0; j<count; j++)
                {
                    ref readonly var asset = ref assets[j];
                    Channel.FileEmit(Assets.utf8(asset), targets.Path(FS.file(asset.Name.ShortFileName)), TextEncodingKind.Utf8);
                    counter++;
                }
            }

            return src.SelectMany(x => x).Select(e => Assets.entry(e));
        }

        void EmitAssetEntries(ReadOnlySeq<AssetCatalogEntry> src)
            => Channel.TableEmit(src, AppDb.ApiTargets().Table<AssetCatalogEntry>());

        void EmitSymLits(ReadOnlySpan<SymLiteralRow> src)
            => Channel.TableEmit(src, Target.Path("api.symbols", FileKind.Csv), TextEncodingKind.Unicode);

        ConstLookup<Name,ReadOnlySeq<SymInfo>> CalcApiTokens(Assembly[] src)
            => Symbols.lookup(EnumTypes(src).Tagged<SymSourceAttribute>());

        void EmitApiTokens(ConstLookup<Name,ReadOnlySeq<SymInfo>> src)
        {
            var names = src.Keys;
            for(var i=0; i<names.Length; i++)
                Emit(skip(names,i), src[skip(names,i)]);
        }

        void Emit(ReadOnlySpan<ApiTableField> src)
            => Channel.TableEmit(src, AppDb.ApiTargets().Table<ApiTableField>());

        void Emit(string name, ReadOnlySeq<SymInfo> src)
            => Channel.TableEmit(src, ApiTargets(tokens).PrefixedTable<SymInfo>(name), TextEncodingKind.Unicode);

        void Emit(ReadOnlySpan<ApiCmdRow> src)
            => Channel.TableEmit(src, AppDb.ApiTargets().Table<ApiCmdRow>());

        void EmitApiLiterals(ReadOnlySpan<ApiLiteralInfo> src)
            => Channel.TableEmit(src, AppDb.ApiTargets().Table<ApiLiteralInfo>(), TextEncodingKind.Unicode);

        void Emit(ReadOnlySpan<DataFlowSpec> src)
            => Channel.TableEmit(src, AppDb.ApiTargets().Table<DataFlowSpec>());

        static uint CountFields(Index<Type> tables)
        {
            var counter = 0u;
            for(var i=0; i<tables.Count; i++)
                counter += tables[i].DeclaredInstanceFields().Ignore().Index().Count;
            return counter;
        }

        ReadOnlySeq<ApiTableField> CalcTableFields(ReadOnlySeq<Assembly> src)
        {
            var tables = src.Storage.Types().Tagged<RecordAttribute>().Index();
            var count = CountFields(tables);
            var buffer = alloc<ApiTableField>(count);
            var k=0u;
            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var type = ref tables[i];
                var fields = Tables.fields(type);
                var total = 0u;
                var id = TableId.identify(type).Format();
                var typename = type.DisplayName();
                for(var j=z16; j<fields.Length; j++, k++)
                {
                    ref readonly var tf = ref skip(fields,j);
                    ref readonly var fd = ref tf.Definition;
                    ref var dst = ref seek(buffer,k);
                    var size = (ushort)(Sizes.bits(fd.FieldType)/8);
                    total += size;
                    dst.Seq = j;
                    dst.TableId = id;
                    dst.TableType = typename;
                    dst.Col = j;
                    dst.FieldSize = size;
                    dst.TableSize = total;
                    dst.RenderWidth = tf.FieldWidth;
                    dst.FieldName = fd.Name;
                    dst.FieldType = fd.FieldType.DisplayName();
                }
            }
            return buffer;
        }
    }
}