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
        public static Pairings<InstPattern,InstSig> CalcInstSigs(Index<InstPattern> src)
            => data(XedRecordType.InstSigs, () => XedSigs.sigs(src));
    }
}