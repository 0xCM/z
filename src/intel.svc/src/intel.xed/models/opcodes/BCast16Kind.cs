//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [SymSource("xed"), DataWidth(num5.Width)]
        public enum BCast16Kind : byte
        {
            [Symbol("{1to8}", "BCAST=14;VL=128")]
            BCast_1TO8_16 = 14,

            [Symbol("{1to16}", "BCAST=15;VL=256")]
            BCast_1TO16_16 = 15,

            [Symbol("{1to32}", "BCAST=16;VL=512")]
            BCast_1TO32_16 = 16,

            [Symbol("{1to2}", "BCAST=26")]
            BCast_1TO2_16  = 26,

            [Symbol("{1to4}", "BCAST=27")]
            BCast_1TO4_16  = 27,
        }
    }
}