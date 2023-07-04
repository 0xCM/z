//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static sys;

public partial class XedFlows : WfSvc<XedFlows>
{
    public static ref readonly Index<AsmBroadcast> BroadcastDefs
    {
        [MethodImpl(Inline), Op]
        get => ref _BroadcastDefs;
    }

    XedPaths XedPaths => Wf.XedPaths();

    IDbArchive Targets() => XedPaths.Imports();

    IDbArchive Targets(string scope) => Targets().Targets(scope);

    XedRuntime XedRuntime => Wf.XedRuntime();

    public CpuIdDataset CalcCpuIdDataset(FilePath src)
    {
        var parser = new CpuIdImportCalcs();
        parser.Run(src.ReadLines().Where(text.nonempty));
        return new (parser.Parsed.CpuIdSpecs, parser.Parsed.IsaSpecs);
    }
    
    void EmitIsaSpecs(ReadOnlySeq<InstIsaSpec> src)
        => Channel.TableEmit(src, Targets().Table<InstIsaSpec>());

    void EmitCpuIdSpecs(ReadOnlySeq<CpuIdSpec> src)
        => Channel.TableEmit(src, Targets().Table<CpuIdSpec>());

    public void EmitCpuIdDataset(CpuIdDataset src)
    {
        EmitIsaSpecs(src.InstIsaSpecs);
        EmitCpuIdSpecs(src.CpuIdSpecs);
    }

    public void EmitChipCodes()
        => Channel.TableEmit(Symbols.symkinds<ChipCode>(), XedDb.Targets().Path("xed.chips", FileKind.Csv));

    public void Run()
    {            
        exec(PllExec,
            () => EmitCpuIdDataset(CalcCpuIdDataset(XedDb.DocSource(XedDocKind.CpuId))),
            //ImportInstBlocks,
            () => EmitChipMap(CalcChipMap(XedDb.DocSource(XedDocKind.ChipMap))),
            () => EmitFormImports(CalcFormImports(XedDb.DocSource(XedDocKind.FormData))),
            EmitIsaForms,
            EmitBroadcastDefs,
            () => EmitChipCodes(),
            () => Emit(CalcFieldImports())
            //() => EmitPointerWidths(XedOps.PointerWidthInfo),
            //() => EmitOpWidths(XedRuntime.Views.OpWidths.OpWidths)
        );
    }

    public ReadOnlySeq<FormImport> CalcFormImports(FilePath src)
        => FormImporter.calc(src);

    void EmitBroadcastDefs()
        => Channel.TableEmit(XedFlows.BroadcastDefs, Targets().Table<AsmBroadcast>());

    public void EmitFormImports(ReadOnlySeq<FormImport> src)
        => Channel.TableEmit(src, Targets().Table<FormImport>());

    void Emit(ReadOnlySpan<FieldImport> src)
        => Channel.TableEmit(src, XedPaths.Imports().Table<FieldImport>());

    public void EmitPointerWidths(ReadOnlySpan<PointerWidthInfo> src)
        => Channel.TableEmit(src, Targets().Table<PointerWidthInfo>());

    public void EmitOpWidths(ReadOnlySpan<OpWidthRecord> src)
        => Channel.TableEmit(src, Targets().Table<OpWidthRecord>());

    public ChipMap CalcChipMap(FilePath src)
    {
        var kinds = Symbols.index<InstIsaKind>();
        var chip = ChipCode.INVALID;
        var chips = dict<ChipCode,ChipIsaKinds>();
        using var reader = src.LineReader(TextEncodingKind.Asci);
        while(reader.Next(out var line))
        {
            if(line.StartsWith(Chars.Hash))
                continue;

            var i = line.Index(Chars.Colon);
            if(i != -1)
            {
                var name = line.Left(i).Trim();
                if(blank(name))
                    continue;

                if(XedParsers.parse(name, out chip))
                {
                    if(!chips.TryAdd(chip, new ChipIsaKinds(chip)))
                        Errors.Throw(Msg.DuplicateChipCode.Format(chip));
                }
                else
                    Errors.Throw(Msg.ChipCodeNotFound.Format(name));
            }
            else
            {
                var isaKinds = line.Content.SplitClean(Chars.Tab).Trim().Select(x => Enums.parse<InstIsaKind>(x,0)).Where(x => x != 0).Array();
                chips[chip].Add(isaKinds);
                if(chips.TryGetValue(chip, out var entry))
                    entry.Add(isaKinds);
            }
        }
        var codes = Symbols.index<ChipCode>();
        var buffer = dict<ChipCode,InstIsaKinds>();
        for(var i=0; i<codes.Count; i++)
        {
            var code = codes[i].Kind;
            if(chips.TryGetValue(code, out var entry))
                buffer[code] = entry.Kinds;
            else
                buffer[code] = XedModels.InstIsaKinds.Empty;
        }
        return new ChipMap(buffer);
    }

    public void EmitChipMap(ChipMap  map)
    {
        const string RowFormat = "{0,-12} | {1,-24} | {2}";
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

        Channel.FileEmit(dst.Emit(), counter, Targets().Path(FS.file("xed.chipmap", FS.Csv)));
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
