//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

public enum XedRecordType : byte
{
    InstPattern,

    RuleTables,

    InstFields,

    CellTables,

    RuleExpr,

    CellDatasets,

    OpCodes,

    IsaImport,

    CpuIdImport,

    TypeTables,

    TypeTableRows,

    ChipMap,

    FormImports,

    InstImports,

    AsmBroadcastDefs,

    OpWidths,

    WidthLookup,

    InstOpSpecs,

    InstOpDetail,

    InstSigs,
}
