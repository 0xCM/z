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
        None,

        [Symbol("agen")]
        Agen,

        [Symbol("base")]
        Base,

        [Symbol("disp")]
        Disp,

        [Symbol("imm")]
        Imm,

        [Symbol("index")]
        Index,

        [Symbol("mem")]
        Mem,

        [Symbol("ptr")]
        Ptr,

        [Symbol("reg")]
        Reg,

        [Symbol("relbr")]
        RelBr,

        [Symbol("scale")]
        Scale,

        [Symbol("seg")]
        Seg,

        [Symbol("bcast")]
        Bcast,
    }
}
