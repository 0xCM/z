//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [SymSource(xed), DataWidth(num5.Width)]
    public enum BCast32Kind : byte
    {
        [Symbol(AsmBroadcastSymbols.N1to16, "BCAST=1;VL=512")]
        BCast_1TO16_32 = 1,

        [Symbol(AsmBroadcastSymbols.N4to16, "BCAST=2;VL=512")]
        BCast_4TO16_32 = 2,

        [Symbol(AsmBroadcastSymbols.N1to8, "BCAST=3;VL=256")]
        BCast_1TO8_32 = 3,

        [Symbol(AsmBroadcastSymbols.N4to8, "BCAST=4;VL=256")]
        BCast_4TO8_32 = 4,

        [Symbol(AsmBroadcastSymbols.N2to16, "BCAST=7;VL=512")]
        BCast_2TO16_32 = 7,

        [Symbol(AsmBroadcastSymbols.N8to16, "BCAST=9;VL=512")]
        BCast_8TO16_32 = 9,

        [Symbol(AsmBroadcastSymbols.N1to4, "BCAST=10;VL=512")]
        BCast_1TO4_32 = 10,

        [Symbol(AsmBroadcastSymbols.N2to4, "BCAST=12;VL=128")]
        BCast_2TO4_32 = 12,

        [Symbol("{2to8}", "BCAST=21;VL=256")]
        BCast_2TO8_32 = 21,

        [Symbol("{1to2}", "BCAST=22;VL=128")]
        BCast_1TO2_32 = 22,
    }
}
