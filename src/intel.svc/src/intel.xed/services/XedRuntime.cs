//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;
using static XedModels;

using I = XedRecordType;

public class XedRuntime : WfSvc<XedRuntime>
{
    bool Started = false;

    readonly object StartLocker = new();

    public ref readonly Alloc Alloc => ref _Alloc;

    public XedDb XedDb => Wf.XedDb();

    public XedRules Rules => Wf.XedRules();

    public XedOps XedOps => Wf.XedOps();

    readonly Alloc _Alloc;

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

    void RunCalcs()
    {
        var defs = XedInstDefParser.parse(XedPaths.DocSource(XedDocKind.EncInstDef));

        //var tables = XedRuleTables.Empty;
        var patterns = sys.empty<InstPattern>();
        
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
            () => ct = CellTables.tables(cd));

        var rulexpr = sys.empty<RuleExpr>();
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

    // public void RunEtl()
    // {
    //     XedPaths.Targets().Delete();
    //     var tables = Views.RuleTables;
    //     var patterns = Views.Patterns;
    //     exec(PllExec,
    //         () => XedFlows.Run(),
    //         () => EmitRegmaps(),
    //         () => Rules.EmitCatalog(patterns, tables)
    //         );

    //     EmitInstPages(patterns);
    //     EmitDocs();
    //     XedDb.EmitArtifacts();
    // }

    // void EmitDocs()
    //     => Docs.Emit();

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

    void EmitRegmaps()
    {
        Channel.TableEmit(XedRegMap.Service.REntries, XedPaths.ImportTable<RegMapEntry>("rmap"));
        Channel.TableEmit(XedRegMap.Service.XEntries, XedPaths.ImportTable<RegMapEntry>("xmap"));
    }
}
