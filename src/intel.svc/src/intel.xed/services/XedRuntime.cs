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
        var defs = XedInstDefParser.parse(XedPaths.DocSource(XedDocKind.EncInstDef));
        var cpu = XedFlows.CalcCpuIdDataset(XedPaths.DocSource(XedDocKind.CpuId));
        var brodcasts = XedFlows.CalcBroadcastDefs();

        CalcTypeTables();

        //var tables = XedRuleTables.Empty;
        var patterns = sys.empty<InstPattern>();
        exec(PllExec,
            //() => tables = CalcRuleTables(),
            () => patterns = InstPattern.load(defs)
            );

        var opdetail = sys.empty<InstOpDetail>();
        var instfields = sys.empty<InstFieldRow>();
        var instoc = sys.empty<XedInstOpCode>();
        exec(PllExec,
            () => instoc = poc(patterns),
            () => instfields =  XedPatterns.fieldrows(patterns),
            () => opdetail = Xed.opdetails(patterns)
            );

        var cd = XedRuleCells.Empty;
        var opSpecs = sys.empty<InstOpSpec>();
        exec(PllExec,
            () => opSpecs = XedOps.CalcSpecs(opdetail)
            //() => cd = XedRuleTables.datasets(tables)
            );

        var ct = CellTables.Empty;
        exec(PllExec,
            () => ct = CellTables.from(cd));

        var rulexpr = sys.empty<RuleExpr>();
        exec(PllExec,
            () => rulexpr = Rules.CalcRuleExpr(Views.CellTables));

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
        XedPaths.Targets().Delete();
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
        XedPaths.InstPages().Delete();
        iter(formatter.GroupFormats(src), x => Emit(x), PllExec);
    }

    void Emit(in InstIsaFormat src)
    {
        var dst = XedPaths.InstPagePath(src.Isa);
        Require.invariant(!dst.Exists);
        Channel.FileEmit(src.Content, src.LineCount, dst, TextEncodingKind.Asci);
    }

    void Emit(ReadOnlySpan<FieldDef> src)
        => Channel.TableEmit(src, XedPaths.Table<FieldDef>());

    void EmitRegmaps()
    {
        Channel.TableEmit(XedRegMap.Service.REntries, XedPaths.Table<RegMapEntry>("rmap"));
        Channel.TableEmit(XedRegMap.Service.XEntries, XedPaths.Table<RegMapEntry>("xmap"));
    }
}
