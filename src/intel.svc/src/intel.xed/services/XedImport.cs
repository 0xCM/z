//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static sys;

    public partial class XedImport : WfSvc<XedImport>
    {
        public static ref readonly Index<AsmBroadcast> BroadcastDefs
        {
            [MethodImpl(Inline), Op]
            get => ref _BroadcastDefs;
        }

        XedPaths XedPaths => Wf.XedPaths();

        IDbArchive Targets() => XedPaths.Imports();

        IDbArchive Targets(string scope) => Targets().Targets(scope);

        InstBlockImporter BlockImporter => Wf.BlockImporter();

        XedRuntime XedRuntime => Wf.XedRuntime();

        public void Run()
        {
            exec(PllExec,
                ImportInstBlocks,
                EmitChipMap,
                EmitFormImports,
                EmitIsaForms,
                EmitIsaImports,
                EmitCpuIdImports,
                EmitBroadcastDefs,
                EmitChips,
                () => Emit(CalcFieldImports()),
                () => Emit(XedOps.PointerWidthInfo),
                () => Emit(XedRuntime.Views.OpWidths)
            );
        }

        public void CalcInstImports(Action<InstImportBlocks> dst)
            => BlockImportDatasets.calc(dst);

        public void CalcCpuIdImports(Action<CpuIdImporter.Output> f)
            => f(CpuIdImporter.calc());

        public void CalcFormImports(Action<Index<FormImport>> f)
            => f(FormImporter.calc(XedPaths.DocSource(XedDocKind.FormData)));

        void EmitBroadcastDefs()
            => TableEmit(XedImport.BroadcastDefs, Targets().Table<AsmBroadcast>());

        void EmitIsaImports()
            => TableEmit(XedRuntime.Views.IsaImport, Targets().Table<IsaImport>());

        void EmitCpuIdImports()
            => TableEmit(XedRuntime.Views.CpuIdImport, Targets().Table<CpuIdImport>());

        void EmitFormImports()
            => Emit(XedRuntime.Views.FormImports);

        void Emit(ReadOnlySpan<FormImport> src)
            => TableEmit(src, Targets().Table<FormImport>());

        void ImportInstBlocks()
            => BlockImporter.Import(XedRuntime.Views.InstImports);

        void Emit(ReadOnlySpan<FieldImport> src)
            => TableEmit(src, XedPaths.Imports().Table<FieldImport>());

        void Emit(ReadOnlySpan<PointerWidthInfo> src)
            => TableEmit(src, XedPaths.Imports().Table<PointerWidthInfo>());

        void Emit(ReadOnlySpan<OpWidthRecord> src)
            => TableEmit(src, XedPaths.Imports().Table<OpWidthRecord>());

        void EmitChips()
            => TableEmit(Symbols.symkinds<ChipCode>(), Targets().Path("xed.chips", FileKind.Csv));

        void EmitChipMap()
        {
            const string RowFormat = "{0,-12} | {1,-24} | {2}";
            var map = XedRuntime.Views.ChipMap;
            var dst = text.emitter();
            var counter = 0u;
            dst.WriteLine(string.Format(RowFormat, "Sequence", "ChipCode", "Isa"));
            var codes = map.Codes;
            foreach(var code in codes)
            {
                var mapped = map[code];
                foreach(var kind in mapped)
                    dst.WriteLine(string.Format(RowFormat, counter++ , code, kind));
            }

            FileEmit(dst.Emit(), counter, Targets().Path(FS.file("xed.chipmap", FS.Csv)));
        }

        void EmitIsaForms()
        {
            var codes = Symbols.index<ChipCode>();
            var forms = XedRuntime.Views.FormImports;
            var map = XedRuntime.Views.ChipMap;
            var formisa = forms.Select(x => (x.InstForm.Kind, x.IsaKind)).ToDictionary();
            var isakinds = formisa.Values.ToHashSet();
            var isaforms = cdict<InstIsaKind,HashSet<FormImport>>();
            iter(isakinds, k => isaforms[k] = new());
            iter(forms, f => isaforms[f.IsaKind].Add(f));
            iter(codes.Kinds, chip => {
                var kinds = map[chip];
                var dst = Targets("isaforms").Path(FS.file(string.Format("xed.isa.{0}", chip), FS.Csv));
                var matches = sys.bag<FormImport>();
                iter(kinds, k => {
                    if(isaforms.TryGetValue(k, out var forms))
                        matches.AddRange(forms);
                    });
                TableEmit(matches.ToArray().Sort().Resequence(), dst);
            },PllExec);
        }

        static Symbols<VisibilityKind> Visibilities = Symbols.index<VisibilityKind>();

        static Symbols<XedFieldType> FieldTypes = Symbols.index<XedFieldType>();

        static Index<AsmBroadcast> _BroadcastDefs = Xed.broadcasts(Symbols.kinds<BCastKind>());
    }
}