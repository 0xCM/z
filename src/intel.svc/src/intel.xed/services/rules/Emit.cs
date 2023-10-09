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
    public Index<FieldUsage> CalcFieldDeps(CellTables src)
        => Data(nameof(CalcFieldDeps), () => Xed.fields(src));

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

    void EmitRuleDeps(CellTables src)
        => Emit(CalcFieldDeps(src));

    public void EmitCatalog(Index<InstPattern> patterns, XedRuleTables rules)
    {
        exec(PllExec,
            EmitRuleBlocks,
            () => Channel.TableEmit(AsmOpCodeKinds.Instance.Records, XedPaths.ImportTable<OpCodeMapInfo>()),
            () => Emit(mapi(RuleMacros.matches().Values.ToArray().Sort(), (i,m) => m.WithSeq((uint)i))),
            () => Emit(CalcMacroDefs().View)
        );

        Emit(patterns);
    }

    public void Emit(Index<InstPattern> patterns)
        => EmitPatternData(patterns);

    public void EmitInstGroups(Index<InstPattern> src)
        => EmitInstGroups(CalcInstGroups(src));


    public void EmitPatternRecords(Index<InstPattern> src)
        => Channel.TableEmit(InstPattern.records(src), XedPaths.ImportTable<InstPatternRecord>());

    public Index<InstPattern> EmitPatternData(Index<InstPattern> src)
    {
        exec(PllExec,
            () => EmitPatternRecords(src),
            () => EmitFlagEffects(src),
            () => EmitInstAttribs(src),
            () => EmitInstSigs(src),
            () => EmitInstGroups(src)
            );
        return src;
    }

    void Emit(AsmOpCodeClass @class, ReadOnlySpan<InstGroupSeq> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<InstGroupSeq>(@class.ToString().ToLower()));

    public void EmitSeq()
    {
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
        var count = CellRender.Tables.render(src.Cells(), dst);
        var data = Require.equal(dst.Emit(), src.RawFormat);
        Channel.FileEmit(data, src.TableCount, XedPaths.RuleTarget("cells.raw", FS.Csv));
    }

    public void Emit(ReadOnlySpan<MacroMatch> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<MacroMatch>());

    public void Emit(ReadOnlySpan<MacroDef> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<MacroDef>());

    public void Emit(ReadOnlySpan<XedInstOpCode> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<XedInstOpCode>());

    public void Emit(ReadOnlySpan<InstOpRow> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<InstOpRow>());

    public void Emit(ReadOnlySpan<InstOpClass> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<InstOpClass>());

    public void Emit(ReadOnlySpan<RuleExpr> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<RuleExpr>());
}
