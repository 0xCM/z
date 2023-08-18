//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [SymSource(xed), DataWidth(num5.Width)]
    public enum BCast64Kind : byte
    {
        [Symbol(AsmBroadcastSymbols.N1to8, "BCAST=5;VL=512")]
        BCast_1TO8_64 = 5,

        [Symbol(AsmBroadcastSymbols.N4to8, "BCAST=6;VL=512")]
        BCast_4TO8_64 = 6,

        [Symbol(AsmBroadcastSymbols.N2to8, "BCAST=8;VL=512")]
        BCast_2TO8_64 = 8,

        [Symbol(AsmBroadcastSymbols.N1to2, "BCAST=11;VL=128")]
        BCast_1TO2_64 = 11,

        [Symbol(AsmBroadcastSymbols.N1to4, "BCAST=13;VL=256")]
        BCast_1TO4_64 = 13,

        [Symbol(AsmBroadcastSymbols.N2to4, "BCAST=20;VL=256")]
        BCast_2TO4_64 = 20,
    }
}
