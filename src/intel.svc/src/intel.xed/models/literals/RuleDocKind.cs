//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource("xed")]
    public enum XedDocKind : byte
    {
        None,

        EncInstDef,

        DecInstDef,

        EncRuleTable,

        DecRuleTable,

        EncDecRuleTable,

        Widths,

        PointerWidths,

        Fields,

        FormData,

        ChipMap,

        CpuId,
 
        RuleSeq,

        RuleBlocks

    }
}