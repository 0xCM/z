//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedForms
    {
        public enum FormTokenKind : byte
        {
            None,

            RegClass,

            RegIndex,

            OpClass,

            AddressClass,

            Cpuid,

            Field,

            NonTerm,

            IsaKind,

            InstCategory,

            Gp8RegLit,

            Gp16RegLit,

            Gp32RegLit,

            Gp64RegLit,

            CrRegLit,

            DbRegLit,

            SegRegLit,

            Rep,

            InstClass,

            Hex8Lit,

            Hex16Lit
        }
    }
}