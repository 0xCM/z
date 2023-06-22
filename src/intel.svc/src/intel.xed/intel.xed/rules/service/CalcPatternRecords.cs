//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    
    partial class XedRules
    {
        public Index<InstPatternRecord> CalcPatternRecords(Index<InstPattern> src)
            => Data(nameof(CalcPatternRecords), () => XedPatterns.records(src));
    }
}