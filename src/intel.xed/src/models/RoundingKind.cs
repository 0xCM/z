//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [SymSource(xed), DataWidth(3)]
    public enum RoundingKind : byte
    {
        [Symbol("")]
        None = 0,

        [Symbol("{rn-sae}", "ROUNDC=1 => LLRC=0 & BCRC=1: Round to nearest, ties to even, suppress all exceptions")]
        RnSae = 1,

        [Symbol("{rd-sae}", "ROUNDC=2 => LLRC=1 & BCRC=1: Round down (toward negative infinity), suppress all exceptions")]
        RdSae = 2,

        [Symbol("{ru-sae}", "ROUNDC=3 => LLRC=2 & BCRC=1: Round up (toward positive infinity), suppress all exception")]
        RuSae = 3,

        [Symbol("{rz-sae}", "ROUNDC=4 => LLRC=3 & BCRC=1: Round toward zero, suppress all exception")]
        RzSae = 4,
    }
}
