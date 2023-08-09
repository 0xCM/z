//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;
using static XedPatterns;
using static XedModels;

using I = XedRecordType;

public class XedRuntime : WfSvc<XedRuntime>
{
    bool Started = false;

    readonly object StartLocker = new();

    public ref readonly CompositeBuffers Alloc => ref _Alloc;

    public XedPaths Paths => XedPaths.Service;

    public XedDocs Docs => Wf.XedDocs();

    public XedDb XedDb => Wf.XedDb();

    public XedRules Rules => Wf.XedRules();

    public XedOps XedOps => Wf.XedOps();

    public XedFlows XedImport => Wf.XedFlows();

    readonly CompositeBuffers _Alloc;

    public XedTables Views => Channel.XedViews();

    public XedRuntime()
    {
        _Alloc = CompositeBuffers.create();
        Disposing += HandleDispose;
    }

    static XedRuleTables CalcRuleTables()
    {
        var tables = new XedRuleTables();
        var dst = new XedRuleBuffers();
        exec(PllExec,
            () => dst.Target.TryAdd(RuleTableKind.ENC, XedRuleSpecs.criteria(RuleTableKind.ENC)),
            () => dst.Target.TryAdd(RuleTableKind.DEC, XedRuleSpecs.criteria(RuleTableKind.DEC))
            );
        return XedRules.tables(dst);
    }

    void CalcTypeTables()
    {
        Views.Store(I.TypeTables, TypeTables.typetables(typeof(XedDb).Assembly,"xed", Alloc.Composite()));
        Views.Store(I.TypeTableRows, TypeTables.rows(Views.TypeTables));
    }

    void RunCalcs()
    {
        var defs = XedInstDefParser.parse(XedDb.DocSource(XedDocKind.EncInstDef));
        var blocks = XedImport.CalcInstDump(XedDb.DocSource(XedDocKind.RuleDump));
        var forms = XedImport.CalcFormImports(XedDb.DocSource(XedDocKind.FormData));
        var chips = XedImport.CalcChipMap(XedDb.DocSource(XedDocKind.ChipMap));
        var cpu = XedImport.CalcCpuIdDataset(XedDb.DocSource(XedDocKind.CpuId));
        var brodcasts = XedImport.CalcBroadcastDefs();

        CalcTypeTables();

        Views.Store(I.FormImports, forms);
        Views.Store(I.ChipMap, chips);

        var tables = XedRuleTables.Empty;
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
            () => cd = XedRuleTables.datasets(tables)
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

    void HandleDispose()
    {
        _Alloc?.Dispose();
    }

    public void RunEtl()
    {
        Paths.Targets().Delete();
        var tables = Views.RuleTables;
        var patterns = Views.Patterns;
        Emit(XedFields.Defs.Positioned);
        exec(PllExec,
            () => XedImport.Run(),
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
        Channel.FileEmit(src.Content, src.LineCount, dst, TextEncodingKind.Asci);
    }

    void Emit(ReadOnlySpan<FieldDef> src)
        => TableEmit(src, Paths.Table<FieldDef>());

    void EmitRegmaps()
    {
        Channel.TableEmit(XedRegMap.Service.REntries, Paths.Table<RegMapEntry>("rmap"));
        Channel.TableEmit(XedRegMap.Service.XEntries, Paths.Table<RegMapEntry>("xmap"));
    }
}
