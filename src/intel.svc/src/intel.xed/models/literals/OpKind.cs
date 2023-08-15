//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [SymSource(xed), DataWidth(num4.Width)]
    public enum OpKind : byte
    {
        None = 0,

        [Symbol("agen")]
        Agen = 1,

        [Symbol("base")]
        Base = 2,

        [Symbol("disp")]
        Disp = 3,

        [Symbol("imm")]
        Imm = 4,

        [Symbol("index")]
        Index = 5,

        [Symbol("mem")]
        Mem = 6,

        [Symbol("ptr")]
        Ptr = 7,

        [Symbol("reg")]
        Reg = 8,

        [Symbol("relbr")]
        RelBr = 9,

        [Symbol("scale")]
        Scale = 10,

        [Symbol("seg")]
        Seg = 11,

        [Symbol("bcast")]
        Bcast,
    }
}
