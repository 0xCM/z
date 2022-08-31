//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ApiMdEmitter : WfSvc<ApiMdEmitter>
    {
        IApiPack Target;

        ApiMd Md;

        ApiComments Comments => Wf.ApiComments();

        IDbTargets AssetTargets
            => AppDb.ApiTargets("assets");

        ReadOnlySeq<ApiDataType> DataTypes()
            => data("DataTypes", () => ApiTypes.discover(Md.Assemblies));

        ReadOnlySeq<ApiTypeInfo> DataTypeInfo()
            => data("DataTypeInfo", () => ApiTypes.describe(DataTypes()));

        internal static ApiMdEmitter create(IWfRuntime wf, ApiMd md)
        {
            var svc = create(wf);
            svc.Md = md;
            return svc;
        }

        public void Emit(IApiCatalog catalog, IApiPack dst)
        {
            Target = dst;
            var src = catalog.Components;
            var symlits = Symbolic.symlits(src);
            exec(true,
                EmitDataFlows,
                () => EmitComments(Target),
                EmitAssets,
                () => EmitSymLits(symlits),
                EmitApiLiterals,
                () => EmitApiDeps(Target),
                EmitParsers,
                EmitApiDeps,
                EmitApiTables,
                EmitApiTokens,
                EmitCmdDefs,
                EmitDataTypes,
                EmitTypeLists,
                EmitApiSymbols,
                EmitPartList,
                () => EmitSymHeap(Heaps.load(symlits), Target)
            );
        }

        public void EmitParsers()
        {
            const string RenderPattern = "{0,-8} | {1,-8} | {2}";
            var cols = new string[]{"Seq", "Returns", "Target"};
            var parsers = Md.Parsers;
            var emitter = text.emitter();
            emitter.AppendLineFormat(RenderPattern, cols);
            var i=0u;
            iter(parsers.Values.Index().Sort(), parser
                => emitter.AppendLineFormat(RenderPattern,
                    i++,
                    parser.ResultType.DisplayName(),
                    parser.TargetType.DisplayName()
                    ));
            FileEmit(emitter.Emit(), parsers.Count, AppDb.ApiTargets().Path("api.parsers", FileKind.Csv));
        }

        public void EmitAssets()
        {
            //AssetTargets.Delete();
            //EmitAssetEntries(EmitAssets(CalcAssets()));
        }

        public void EmitApiLiterals()
            => EmitApiLiterals(Literals.apilits(Md.Assemblies));

        public void EmitCmdDefs()
            => Emit(CalcCmdDefs());

        public void EmitDataTypes()
            => TableEmit(DataTypeInfo(), AppDb.ApiTargets().Table<ApiTypeInfo>());

        public void EmitPartList()
        {
            var dst = text.emitter();
            var src = Md.Assemblies.Index();
            for(var i=0; i<src.Count; i++)
                dst.AppendLine(src[i].GetName().FullName);
            FileEmit(dst.Emit(), AppDb.ApiTargets().Path("api.parts", FileKind.List));
        }

        public void EmitDataFlows()
            => Emit(CalcDataFlows());

        public void EmitApiTables()
            => Emit(CalcTableFields());

        public void EmitApiTokens()
            => EmitApiTokens(CalcApiTokens());

        public void EmitTokenGroup(ITokenGroup src)
            => TableEmit(Symbols.syminfo(src.TokenTypes), Target.Table<SymInfo>($"{src.GroupName}"), TextEncodingKind.Unicode);

        public void EmitHeap(SymHeap src)
            => Heaps.emit(src, AppDb.ApiTargets().Table<SymHeapRecord>(), EventLog);

        public void EmitTypeLists()
        {            
            TypeList.serialize(Md.EnumTypes, AppDb.ApiTargets().Path("api.types.enums", FileKind.List));
            TypeList.serialize(Md.ApiTableTypes, AppDb.ApiTargets().Path("api.types.records", FileKind.List));
        }

        public void EmitApiComments()
            => Comments.Collect(AppDb.ApiTargets(comments));

        public void EmitApiDeps()
            => iter(sys.array(ExecutingPart.Assembly), a => EmitApiDeps(a, AppDb.ApiTargets().Path($"{a.GetSimpleName()}", FileKind.DepsList)), true);

        public void EmitApiSymbols()
            => TableEmit(Symbolic.symlits(Md.Assemblies), AppDb.ApiTargets().Table<SymLiteralRow>(), UTF16);

        void EmitSymHeap(SymHeap src, IApiPack dst)
            => Heaps.emit(src, dst.Metadata().Table<SymHeapRecord>(), EventLog);

        void EmitComments(IApiPack dst)
            => Comments.Collect(dst);

        void EmitApiDeps(IApiPack dst)
            => iter(sys.array(ExecutingPart.Assembly), a => EmitApiDeps(a,Target.Runtime().Path($"{a.GetSimpleName()}", FileKind.DepsList)), true);

        ReadOnlySeq<ApiCmdRow> CalcCmdDefs()
            => CmdTypes.rows(CmdTypes.discover(Md.Assemblies));

        ReadOnlySeq<ApiFlowSpec> CalcDataFlows()
        {
            var src = ApiDataFlow.discover(Md.Assemblies);
            var count = src.Length;
            var buffer = alloc<ApiFlowSpec>(count);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var flow = ref src[i];
                dst.Actor = flow.Actor;
                dst.Source = flow.Source?.ToString() ?? EmptyString;
                dst.Target = flow.Target?.ToString() ?? EmptyString;
                dst.Description = flow.Format();
            }
            return buffer.Sort();
        }

        void EmitTokens(Type src)
        {
            var syms = Symbols.syminfo(src);
            var name = src.Name.ToLower();
            var dst = Target.PrefixedTable<SymInfo>("tokens" + "." +  name);
            TableEmit(syms, dst, TextEncodingKind.Unicode);
        }

        void EmitTypeList(string name, ReadOnlySpan<Type> src)
        {
            var path = AppDb.ApiTargets().Path(name, FileKind.List);
            var dst = text.emitter();
            for(var i=0; i<src.Length; i++)
                dst.AppendLine(skip(src,i).AssemblyQualifiedName);
            FileEmit(dst.Emit(), src.Length, path);
        }

        void EmitApiDeps(Assembly src, FilePath dst)
        {
            var deps = JsonDeps.load(src);
            var buffer = list<string>();
            iteri(deps.RuntimeLibs(), (i,lib) => buffer.Add(string.Format("{0:D4}:{1}",i,lib)));
            var emitter = text.emitter();
            iter(buffer, line => emitter.AppendLine(line));
            FileEmit(emitter.Emit(), buffer.Count, dst);
        }

        void EmitSymLits(ReadOnlySpan<SymLiteralRow> src)
            => TableEmit(src, Target.Metadata().Path("api.symbols", FileKind.Csv), TextEncodingKind.Unicode);

        ConstLookup<Name,ReadOnlySeq<SymInfo>> CalcApiTokens()
            => Symbols.lookup(Md.EnumTypes.Tagged<SymSourceAttribute>());

        void EmitApiTokens(ConstLookup<Name,ReadOnlySeq<SymInfo>> src)
        {
            var names = src.Keys;
            for(var i=0; i<names.Length; i++)
                Emit(skip(names,i), src[skip(names,i)]);
        }

        void Emit(ReadOnlySpan<ApiTableField> src)
            => TableEmit(src, AppDb.ApiTargets().Table<ApiTableField>());

        void Emit(ReadOnlySpan<ApiRuntimeMember> src)
            => TableEmit(src, AppDb.ApiTargets().Table<ApiRuntimeMember>(), TextEncodingKind.Utf8);

        void Emit(Name name, ReadOnlySeq<SymInfo> src)
            => TableEmit(src, Md.ApiTargets(tokens).PrefixedTable<SymInfo>(name), TextEncodingKind.Unicode);

        void Emit(ReadOnlySpan<ApiCmdRow> src)
            => TableEmit(src, AppDb.ApiTargets().Table<ApiCmdRow>());

        void EmitApiLiterals(ReadOnlySpan<ApiLiteralInfo> src)
            => TableEmit(src, AppDb.ApiTargets().Table<ApiLiteralInfo>(), TextEncodingKind.Unicode);

        void Emit(ReadOnlySpan<ApiFlowSpec> src)
            => TableEmit(src, AppDb.ApiTargets().Table<ApiFlowSpec>());

        Index<ComponentAssets> CalcAssets()
            => Assets.extract(Md.Assemblies);

        static uint CountFields(Index<Type> tables)
        {
            var counter = 0u;
            for(var i=0; i<tables.Count; i++)
                counter += tables[i].DeclaredInstanceFields().Ignore().Index().Count;
            return counter;
        }

        ReadOnlySeq<ApiTableField> CalcTableFields()
        {
            var tables = Md.ApiTableTypes;
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
                    ref readonly var src = ref skip(fields,j);
                    ref readonly var field = ref src.Definition;
                    ref var dst = ref seek(buffer,k);
                    var size = (ushort)(Sizes.bits(field.FieldType)/8);
                    total += size;
                    dst.Seq = j;
                    dst.TableId = id;
                    dst.TableType = typename;
                    dst.Col = j;
                    dst.FieldSize = size;
                    dst.TableSize = total;
                    dst.RenderWidth = src.FieldWidth;
                    dst.FieldName = field.Name;
                    dst.FieldType = field.FieldType.DisplayName();
                }
            }
            return buffer;
        }

        ReadOnlySeq<AssetCatalogEntry> EmitAssets(ReadOnlySeq<ComponentAssets> src)
        {
            var counter = 0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var assets = ref src[i];
                var count = assets.Count;
                var targets = AssetTargets.Targets(assets.Source.GetSimpleName());
                for(var j=0; j<count; j++)
                {
                    ref readonly var asset = ref assets[j];
                    FileEmit(Assets.utf8(asset), targets.Path(asset.Name.ShortFileName), TextEncodingKind.Utf8);
                    counter++;
                }
            }

            return src.SelectMany(x => x).Select(e => Assets.entry(e));
        }

        void EmitAssetEntries(ReadOnlySeq<AssetCatalogEntry> src)
            => TableEmit(src, AppDb.ApiTargets().Table<AssetCatalogEntry>());
    }
}