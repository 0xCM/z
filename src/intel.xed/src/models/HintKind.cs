//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [SymSource(xed), DataWidth(num3.Width)]
    public enum HintKind : byte
    {
        [Symbol("", "No hint")]
        None = 0,

        [Symbol("UNTAKEN_CS", "CS prefix observed but not taken")]
        UNTAKEN_CS= 1,

        [Symbol("UNTAKEN_CS", "DS observed and taken")]
        TAKEN_DS = 2,

        [Symbol("UNTAKEN_VALIDATED", "Hint validated but not taken")]
        UNTAKEN_VALIDATED = 3,

        [Symbol("TAKEN_VALIDATED", "Hint validated and taken")]
        TAKEN_VALIDATED = 4
    }
}
