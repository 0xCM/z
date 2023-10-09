//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [DataWidth(3,8)]
    public enum FieldDataKind : byte
    {
        [Symbol("")]
        None,

        [Symbol("bit")]
        Bit,

        [Symbol("byte")]
        Byte,

        [Symbol("ushort")]
        Word,

        [Symbol("XedRegId")]
        Reg,

        [Symbol("CHIP")]
        Chip,

        [Symbol("ICLASS")]
        InstClass,
    }
}
