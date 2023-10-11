//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public enum GprWidthIndex : byte
    {
        GPR16_B,
        GPR16_R,

        GPR32_B,
        GPR32_R,

        GPR64_B,
        GPR64_R,

        GPR8_B,
        GPR8_R,
        GPR8_SB,

        GPRv_B,
        GPRv_R,
        GPRv_SB,

        GPRy_B,
        GPRy_R,

        GPRz_B,
        GPRz_R,

        VGPR32_B,
        VGPR32_N,
        VGPR32_R,

        VGPR64_B,
        VGPR64_N,
        VGPR64_R,

        VGPRy_N,

        OeAX,
        OrAX,
        OrBP,
        OrDX,
        OrSP,
    }

}
