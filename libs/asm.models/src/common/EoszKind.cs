//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [Flags]
    public enum EoszKind : byte
    {
        [Symbol("")]
        None,

        [Symbol("8")]
        W8 = 1,

        [Symbol("16")]
        W16 = 2,

        [Symbol("32")]
        W32 = 4,

        [Symbol("64")]
        W64 = 8
    }
}