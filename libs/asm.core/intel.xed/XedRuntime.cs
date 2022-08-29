//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedPatterns;
    using static XedModels;
    using static core;
    using static XedImport;

    using I = XedRecord;

    public partial class XedRuntime : WfSvc<XedRuntime>
    {
        bool Started = false;

        object StartLocker = new();

        public ref readonly Alloc Alloc => ref _Alloc;

        public XedPaths Paths => XedPaths.Service;

        public XedDocs Docs => Wf.XedDocs(this);

        public XedDb XedDb => Wf.XedDb(this);

        public XedRules Rules => Wf.XedRules(this);

        public XedOps XedOps => Wf.XedOps(this);

        public XedDisasmSvc Disasm => Wf.XedDisasm(this);

        public XedImport Import => Wf.XedImport(this);

        Alloc _Alloc;

        XedViews _Views;

        public ref readonly XedViews Views
        {
            [MethodImpl(Inline)]
            get => ref _Views;
        }

        protected override void Initialized()
        {
            _Views = new(this, () => Emitter);
        }

        public XedRuntime()
        {
            _Alloc = Z0.Alloc.create();
        }

        void CalcCpuIdImports()
        {
            Import.CalcCpuIdImports(data => {
                Views.Store(I.CpuIdImport, data.CpuIdRecords);
                Views.Store(I.IsaImport, data.IsaRecords);
            });
        }

        static RuleTables CalcRuleTables()
        {
            var tables = new RuleTables();
            var dst = new RuleBuffers();
            exec(AppData.get().PllExec(),
                () => dst.Target.TryAdd(RuleTableKind.ENC, RuleSpecs.criteria(RuleTableKind.ENC)),
                () => dst.Target.TryAdd(RuleTableKind.DEC, RuleSpecs.criteria(RuleTableKind.DEC))
                );
            return XedRules.tables(dst);
        }

        void CalcTypeTables()
        {
            Views.Store(I.TypeTables, MemDb.typetables(typeof(XedDb).Assembly,"xed", Alloc.Composite()));
            Views.Store(I.TypeTableRows, MemDb.rows(Views.TypeTables));
        }

        void RunCalcs()
        {
            var defs = sys.empty<InstDef>();
            var blocks = InstImportBlocks.Empty;
            var forms = sys.empty<FormImport>();
            var chips = ChipMap.Empty;
            exec(PllExec,
                CalcTypeTables,
                CalcCpuIdImports,
                () => defs = InstDefParser.parse(Paths.DocSource(XedDocKind.EncInstDef)),
                () => Views.Store(I.AsmBroadcastDefs, Import.CalcBroadcastDefs()),
                () => Views.Store(I.OpWidths, XedOps.Widths),
                () => Import.CalcInstImports(data => blocks = data),
                () => Import.CalcFormImports(data => forms = data),
                () => XedChips.calc(data =>  chips = data)
                );

            Views.Store(I.InstImports, blocks);
            Views.Store(I.FormImports, forms);
            Views.Store(I.ChipMap, chips);

            var tables = RuleTables.Empty;
            var patterns = sys.empty<InstPattern>();
            exec(PllExec,
                () => tables = CalcRuleTables(),
                () => patterns = InstPattern.load(defs),
                () => Views.Store(I.WidthLookup, XedOps.WidthLookup)
                );

            Views.Store(I.RuleTables, tables);
            Views.Store(I.InstPattern, patterns);

            var opdetail = sys.empty<InstOpDetail>();
            var instfields = sys.empty<InstFieldRow>();
            var instoc = sys.empty<XedInstOpCode>();
            exec(PllExec,
                () => instoc = poc(patterns),
                () => instfields =  XedPatterns.fieldrows(patterns),
                () => opdetail = XedOps.opdetails(patterns)
                );

            Views.Store(I.OpCodes, instoc);
            Views.Store(I.InstFields, instfields);
            Views.Store(I.InstOpDetail, opdetail);

            var cd = CellDatasets.Empty;
            var opSpecs = sys.empty<InstOpSpec>();
            exec(PllExec,
                () => opSpecs = XedOps.CalcSpecs(opdetail),
                () => cd = RuleTables.datasets(tables)
                );
            Views.Store(I.CellDatasets, cd);
            Views.Store(I.InstOpSpecs, opSpecs);

            var ct = CellTables.Empty;
            exec(PllExec,
                () => ct = CellTables.from(cd));
            Views.Store(I.CellTables, ct);

            var rulexpr = sys.empty<RuleExpr>();
            exec(PllExec,
                () => rulexpr = Rules.CalcRuleExpr(Views.CellTables));
            Views.Store(I.RuleExpr, rulexpr);

            Started = true;
        }

        [MethodImpl(Inline)]
        public void Start()
        {
            lock(StartLocker)
            {
                if(!Started)
                    RunCalcs();
            }
        }

        public new bool Running
        {
            [MethodImpl(Inline)]
            get => Started;
        }

        protected override void Disposing()
        {
            _Alloc?.Dispose();
        }

        public void RunEtl()
        {
            Paths.Output().Delete();
            var tables = Views.RuleTables;
            var patterns = Views.Patterns;
            Emit(XedFields.Defs.Positioned);
            exec(PllExec,
                () => Import.Run(),
                () => EmitRegmaps(),
                () => Rules.EmitCatalog(patterns, tables)
                );

            EmitInstPages(patterns);
            EmitDocs();
            XedDb.EmitArtifacts();
        }

        void EmitDocs()
            => Docs.Emit();

        void EmitInstPages(Index<InstPattern> src)
        {
            src.Sort();
            var formatter = InstPageFormatter.create();
            Paths.InstPages().Delete();
            iter(formatter.GroupFormats(src), x => Emit(x), PllExec);
        }

        void Emit(in InstIsaFormat src)
        {
            var dst = Paths.InstPagePath(src.Isa);
            Require.invariant(!dst.Exists);
            FileEmit(src.Content, src.LineCount, dst, TextEncodingKind.Asci);
        }

        void Emit(ReadOnlySpan<FieldDef> src)
            => TableEmit(src, Paths.Table<FieldDef>());

        void EmitRegmaps()
        {
            TableEmit(XedRegMap.Service.REntries, Paths.Table<RegMapEntry>("rmap"));
            TableEmit(XedRegMap.Service.XEntries, Paths.Table<RegMapEntry>("xmap"));
        }
    }
}