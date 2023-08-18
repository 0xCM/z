//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static AsmBroadcastSymbols;

partial class XedModels
{
    [SymSource("xed"), DataWidth(num5.Width)]
    public enum BCast8Kind : byte
    {
        [Symbol(N1to16, "BCAST=17;VL=128")]
        BCast_1TO16_8 = 17,

        [Symbol(N1to32, "BCAST=18;VL=256")]
        BCast_1TO32_8 = 18,

        [Symbol(N1to64, "BCAST=19;VL=512")]
        BCast_1TO64_8 = 19,

        [Symbol(N1to2, "BCAST=23;VL=128")]
        BCast_1TO2_8  = 23,

        [Symbol(N1to4, "BCAST=24")]
        BCast_1TO4_8  = 24,

        [Symbol(N1to8, "BCAST=25")]
        BCast_1TO8_8  = 25,
    }
}
