//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;
using static XedModels;

partial class XedRules
{
    public Index<FieldUsage> CalcFieldDeps()
        => Data(nameof(CalcFieldDeps), () => Xed.fields(XedRuntime.Views.CellTables));

    public void Emit(Index<FieldUsage> src)
    {
        const string RenderPattern = "{0,-6} | {1,-6} | {2,-6} | {3,-3} | {4,-32} | {5,-32}";
        var headers = new string[]{"Seq", "Index", "Kind", "C", "Rule", "Field"};
        var dst = text.emitter();
        dst.AppendLineFormat(RenderPattern, headers);
        var j=z8;
        var rule = src.First.Rule;
        for(var i=0; i<src.Count; i++,j++)
        {
            ref readonly var u = ref src[i];
            if(u.Rule != rule)
            {
                j=0;
                rule = u.Rule;
            }

            dst.AppendLineFormat(RenderPattern, i, j, u.TableKind, u.Consequent, u.RuleName, u.Field);
        }

        Channel.FileEmit(dst.Emit(), XedPaths.RuleTargets().Path("xed.rules.fields.deps", FileKind.Csv));
    }

    void EmitRuleDeps()
        => Emit(CalcFieldDeps());

    public void EmitCatalog(Index<InstPattern> patterns, XedRuleTables rules)
    {
        exec(PllExec,
            EmitRuleBlocks,
            () => Channel.TableEmit(AsmOpCodeKinds.Instance.Records, XedPaths.Table<OpCodeMapInfo>()),
            () => Emit(mapi(RuleMacros.matches().Values.ToArray().Sort(), (i,m) => m.WithSeq((uint)i))),
            () => Emit(CalcMacroDefs().View),
            () => Channel.TableEmit(XedRuntime.Views.InstOpSpecs, XedPaths.InstTable<InstOpSpec>()),
            EmitRuleDeps
        );

        Emit(patterns);
    }

    public void Emit(Index<InstPattern> patterns)
    {
        exec(PllExec,
            () => EmitPatternData(patterns),
            () => EmitRuleData()
        );
    }

    public void EmitInstGroups(Index<InstPattern> src)
        => EmitInstGroups(CalcInstGroups(src));

    public void EmitOpcodes(Index<InstPattern> src)
        => Emit(XedRuntime.Views.OpCodes);

    public void EmitInstFields(Index<InstPattern> src)
        => Channel.TableEmit(XedRuntime.Views.InstFields, XedPaths.InstTable<InstFieldRow>());

    public void EmitPatternRecords(Index<InstPattern> src)
        => Channel.TableEmit(CalcPatternRecords(src), XedPaths.InstTable<InstPatternRecord>());

    public void EmitOpDetails()
        => Emit(XedRuntime.Views.InstOpDetails);

    public Index<InstPattern> EmitPatternData(Index<InstPattern> src)
    {
        exec(PllExec,
            () => EmitPatternRecords(src),
            () => EmitFlagEffects(src),
            () => EmitInstAttribs(src),
            () => EmitInstSigs(src),
            () => EmitInstFields(src),
            () => EmitInstGroups(src),
            () => EmitOpDetails(),
            () => EmitOpcodes(src)
            );
        return src;
    }

    public void EmitRuleData()
    {
        exec(PllExec,
            () => Emit(XedRuntime.Views.CellDatasets),
            () => EmitRuleExpr(XedRuntime.Views.CellTables),
            //() => Emit(XedRuleTables.records(XedRuntime.Views.CellTables)),
            () => EmitTableSpecs(XedRuntime.Views.RuleTables),
            EmitSeq,
            () => EmitRulePages(XedRuntime.Views.RuleTables)
        );
    }

    void Emit(AsmOpCodeClass @class, ReadOnlySpan<InstGroupSeq> src)
        => Channel.TableEmit(src, XedPaths.InstTable<InstGroupSeq>(@class.ToString().ToLower()));

    public void EmitSeq()
    {
        exec(PllExec,
            () => EmitSeq(CellParser.ruleseq()),
            () => Emit(XedRuleSeq.controls(), XedRuleSeq.defs())
            );
    }

    public void Emit(Index<SeqControl> controls, Index<SeqDef> defs)
    {
        var dst = text.emitter();
        for(var i=0; i<controls.Count; i++)
        {
            if(i != 1)
                dst.AppendLine();

            dst.AppendLine(controls[i].Format());
        }

        for(var i=0; i<defs.Count; i++)
        {
            dst.AppendLine();
            dst.AppendLine(defs[i].Format());
        }

        Channel.FileEmit(dst.Emit(), controls.Count + defs.Count, XedPaths.RuleTarget("seq.reflected", FS.Txt));
    }

    void EmitSeq(Index<RuleSeq> src)
    {
        var dst = text.buffer();
        iter(src, x => dst.AppendLine(x.Format()));
        Channel.FileEmit(dst.Emit(), src.Count, XedPaths.RuleTarget("seq", FS.Txt));
    }

    public void Emit(Index<InstOpDetail> src)
    {
        exec(PllExec,
        () => Emit(CalcInstOpRows(src)),
        () => Emit(CalcOpClasses(src))
        );
    }

    public void Emit(XedRuleCells src)
    {
        exec(PllExec,
            () => EmitRaw(src)

            );
    }

    void EmitRaw(XedRuleCells src)
    {
        var dst = text.emitter();
        var count = CellRender.Tables.render(XedRuntime.Views.CellTables.Cells(), dst);
        var data = Require.equal(dst.Emit(), src.RawFormat);
        Channel.FileEmit(data, src.TableCount, XedPaths.RuleTarget("cells.raw", FS.Csv));
    }

    public void Emit(ReadOnlySpan<MacroMatch> src)
        => Channel.TableEmit(src, XedPaths.RuleTable<MacroMatch>());

    public void Emit(ReadOnlySpan<FieldDef> src)
        => Channel.TableEmit(src, XedPaths.Table<FieldDef>());

    public void Emit(ReadOnlySpan<RuleCellRecord> src)
        => Channel.TableEmit(src, XedPaths.RuleTable<RuleCellRecord>());

    public void Emit(ReadOnlySpan<MacroDef> src)
        => Channel.TableEmit(src, XedPaths.RuleTable<MacroDef>());

    public void Emit(ReadOnlySpan<XedInstOpCode> src)
        => Channel.TableEmit(src, XedPaths.InstTable<XedInstOpCode>());

    public void Emit(ReadOnlySpan<InstOpRow> src)
        => Channel.TableEmit(src, XedPaths.InstTable<InstOpRow>());

    public void Emit(ReadOnlySpan<InstOpClass> src)
        => Channel.TableEmit(src, XedPaths.Table<InstOpClass>());

    public void Emit(ReadOnlySpan<RuleExpr> src)
        => Channel.TableEmit(src, XedPaths.RuleTable<RuleExpr>());
}
