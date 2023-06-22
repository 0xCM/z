//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = AsmOpCodeMaps.Literals;

    [SymSource("asm.opcodes"), DataWidth(5)]
    public enum AsmOpCodeClass : byte
    {
        [Symbol("")]
        None = 0,

        [Symbol(N.BaseClassName)]
        Base = 1,

        [Symbol(N.XopClassName)]
        Xop = 2,

        [Symbol(N.VexClassName)]
        Vex = 4,

        [Symbol(N.EvexClassName)]
        Evex = 8,

        [Symbol(N.Amd3dClassName)]
        Amd3D = 16,
    }
}