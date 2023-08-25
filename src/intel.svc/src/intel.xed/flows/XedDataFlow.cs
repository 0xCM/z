//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

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

    IDbArchive Targets()
        => XedPaths.Imports();

    IDbArchive Targets(string scope)
        => Targets().Targets(scope);

    public CpuIdDataset CalcCpuIdDataset(FilePath src)
    {
        var parser = new CpuIdImportCalcs();
        parser.Run(src.ReadLines().Where(text.nonempty));
        return new (parser.Parsed.CpuIdSpecs, parser.Parsed.IsaSpecs);
    }
    
    void EmitIsaSpecs(ReadOnlySeq<InstIsaSpec> src)
        => Channel.TableEmit(src, Targets().Table<InstIsaSpec>());

    public void EmitCpuIdDataset(CpuIdDataset src)
    {
        EmitIsaSpecs(src.InstIsaSpecs);
        Channel.TableEmit(src.CpuIdSpecs, Targets().Table<CpuIdSpec>());
    }

    public void EmitChipCodes(ReadOnlySeq<SymKindRow> src)
        => Channel.TableEmit(src, Targets().Path("xed.chips", FileKind.Csv));

    public void Run()
    {            
        exec(PllExec,
            () => Emit(CalcFieldImports())
        );
    }

    public ReadOnlySeq<FormImport> CalcFormImports(FilePath src)
        => FormImporter.calc(src);

    public void EmitBroadcastDefs(ReadOnlySeq<AsmBroadcast> src)
        => Channel.TableEmit(src, Targets().Table<AsmBroadcast>());

    public void EmitFormImports(ReadOnlySeq<FormImport> src)
        => Channel.TableEmit(src, Targets().Table<FormImport>());

    void Emit(ReadOnlySpan<FieldImport> src)
        => Channel.TableEmit(src, XedPaths.Imports().Table<FieldImport>());

    public void EmitPointerWidths(ReadOnlySpan<PointerWidthInfo> src)
        => Channel.TableEmit(src, Targets().Table<PointerWidthInfo>());

    public void EmitOpWidths(ReadOnlySpan<OpWidthDetail> src)
        => Channel.TableEmit(src, Targets().Table<OpWidthDetail>());

    public void EmitChipMap(ChipMap map)
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

    public void EmitChipInstructions(ChipInstructions src)
    {
        piter(src.Query(), kv => Channel.TableEmit(kv.Right, Targets("isaforms").Path(FS.file(string.Format("xed.isa.{0}", kv.Left), FS.Csv))));                    
    }

    static readonly Symbols<VisibilityKind> Visibilities = Symbols.index<VisibilityKind>();

    static readonly Symbols<XedFieldType> FieldTypes = Symbols.index<XedFieldType>();

    static readonly Index<AsmBroadcast> _BroadcastDefs = Xed.broadcasts(Symbols.kinds<BroadcastKind>());
}
