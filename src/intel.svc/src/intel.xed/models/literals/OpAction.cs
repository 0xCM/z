//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [SymSource(xed), DataWidth(num2.Width)]
    public enum OpAction : byte
    {
        [Symbol("")]
        None = 0,

        [Symbol("rw", "Read and written (must write)")]
        RW,

        [Symbol("r", "Read-only")]
        R,

        [Symbol("w", "Write-only (must write)")]
        W,

        [Symbol("rcw", "Read and conditionlly written (may write)")]
        RCW,

        [Symbol("cw", "Conditionlly written (may write)")]
        CW,

        [Symbol("crw", "Conditionlly read, always written (must write)")]
        CRW,

        [Symbol("cr", "Conditional read")]
        CR
    }
}
