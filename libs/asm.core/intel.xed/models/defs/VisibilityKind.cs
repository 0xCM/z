//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed), DataWidth(num3.Width)]
        public enum OpVisibility : byte
        {
            [Symbol("")]
            None = 0,

            [Symbol("EXPL","Shows up in operand encoding")]
            Explicit,

            [Symbol("IMPL","Part of the opcode, but listed as an operand")]
            Implicit,

            [Symbol("SUPP", "Part of the opcode, but not typically listed as an operand")]
            Suppressed,

            [Symbol("ECOND", "Explicit conditional")]
            Conditional,
        }

        [SymSource(xed), DataWidth(num3.Width)]
        public enum VisibilityKind : byte
        {
            [Symbol("")]
            INVALID,

            [Symbol("EXPLICIT","Shows up in operand encoding")]
            EXPLICIT,

            [Symbol("IMPLICIT","Part of the opcode, but listed as an operand")]
            IMPLICIT,

            [Symbol("SUPPRESSED", "Part of the opcode, but not typically listed as an operand")]
            SUPPRESSED,

            [Symbol("ECOND", "Explicit conditional")]
            ECOND,
        }
    }
}