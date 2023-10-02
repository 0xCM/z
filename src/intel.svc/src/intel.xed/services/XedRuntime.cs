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

    public ref readonly Alloc Alloc => ref _Alloc;

    public XedPaths Paths => XedPaths.Service;

    public XedDocs Docs => Wf.XedDocs();

    public XedDb XedDb => Wf.XedDb();

    public XedRules Rules => Wf.XedRules();

    public XedOps XedOps => Wf.XedOps();

    public XedFlows XedFlows => Wf.XedFlows();

    readonly Alloc _Alloc;

    public XedTables Views => Channel.XedViews();

    public XedRuntime()
    {
        _Alloc = Z0.Alloc.create();
        Disposing += HandleDispose;
    }

    // static XedRuleTables CalcRuleTables()
    // {
    //     var tables = new XedRuleTables();
    //     var dst = new XedRuleBuffers();
    //     exec(PllExec,
    //         () => dst.Target.TryAdd(RuleTableKind.ENC, XedRuleSpecs.criteria(RuleTableKind.ENC)),
    //         () => dst.Target.TryAdd(RuleTableKind.DEC, XedRuleSpecs.criteria(RuleTableKind.DEC))
    //         );
    //     return XedRules.tables(dst);
    // }

    void CalcTypeTables()
    {
        Views.Store(I.TypeTables, TypeTables.typetables(typeof(XedDb).Assembly,"xed", Alloc.Composite()));
        Views.Store(I.TypeTableRows, TypeTables.rows(Views.TypeTables));
    }

    void RunCalcs()
    {
        var defs = XedInstDefParser.parse(Paths.DocSource(XedDocKind.EncInstDef));
        var forms = XedFlows.CalcFormImports(Paths.DocSource(XedDocKind.FormData));
        var chips = XedFlows.CalcChipMap(Paths.DocSource(XedDocKind.ChipMap));
        var cpu = XedFlows.CalcCpuIdDataset(Paths.DocSource(XedDocKind.CpuId));
        var brodcasts = XedFlows.CalcBroadcastDefs();

        CalcTypeTables();

        Views.Store(I.FormImports, forms);
        Views.Store(I.ChipMap, chips);

        //var tables = XedRuleTables.Empty;
        var patterns = sys.empty<InstPattern>();
        exec(PllExec,
            //() => tables = CalcRuleTables(),
            () => patterns = InstPattern.load(defs)
            );

        //Views.Store(I.RuleTables, tables);
        Views.Store(I.InstPattern, patterns);

        var opdetail = sys.empty<InstOpDetail>();
        var instfields = sys.empty<InstFieldRow>();
        var instoc = sys.empty<XedInstOpCode>();
        exec(PllExec,
            () => instoc = poc(patterns),
            () => instfields =  XedPatterns.fieldrows(patterns),
            () => opdetail = Xed.opdetails(patterns)
            );

        Views.Store(I.OpCodes, instoc);
        Views.Store(I.InstFields, instfields);
        Views.Store(I.InstOpDetail, opdetail);

        var cd = XedRuleCells.Empty;
        var opSpecs = sys.empty<InstOpSpec>();
        exec(PllExec,
            () => opSpecs = XedOps.CalcSpecs(opdetail)
            //() => cd = XedRuleTables.datasets(tables)
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

    public bool Running
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
            () => XedFlows.Run(),
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
        var formatter = XedInstPages.create();
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
        => Channel.TableEmit(src, Paths.Table<FieldDef>());

    void EmitRegmaps()
    {
        Channel.TableEmit(XedRegMap.Service.REntries, Paths.Table<RegMapEntry>("rmap"));
        Channel.TableEmit(XedRegMap.Service.XEntries, Paths.Table<RegMapEntry>("xmap"));
    }
}
