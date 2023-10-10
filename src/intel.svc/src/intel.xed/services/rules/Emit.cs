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
    public void EmitCatalog(Index<InstPattern> patterns, XedRuleTables rules)
    {
        exec(PllExec,
            EmitRuleBlocks,
            () => Channel.TableEmit(AsmOpCodeKinds.Instance.Records, XedPaths.ImportTable<OpCodeMapInfo>())
        );

        Emit(patterns);
    }

    public void Emit(Index<InstPattern> patterns)
        => EmitPatternData(patterns);

    public void EmitPatternRecords(Index<InstPattern> src)
        => Channel.TableEmit(InstPattern.records(src), XedPaths.ImportTable<InstPatternRecord>());

    public Index<InstPattern> EmitPatternData(Index<InstPattern> src)
    {
        exec(PllExec,
            () => EmitPatternRecords(src)
            );
        return src;
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

}
