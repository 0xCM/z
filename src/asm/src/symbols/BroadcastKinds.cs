//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static Asm.BroadcastSymbols;

public class BroadcastKinds
{
    [SymSource("xed"), DataWidth(num5.Width)]
    public enum Broadcast8 : byte
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

    [SymSource("xed"), DataWidth(num5.Width)]
    public enum Broadcast16 : byte
    {
        [Symbol(N1to8, "BCAST=14;VL=128")]
        BCast_1TO8_16 = 14,

        [Symbol(N1to16, "BCAST=15;VL=256")]
        BCast_1TO16_16 = 15,

        [Symbol(N1to32, "BCAST=16;VL=512")]
        BCast_1TO32_16 = 16,

        [Symbol(N1to2, "BCAST=26")]
        BCast_1TO2_16  = 26,

        [Symbol(N1to4, "BCAST=27")]
        BCast_1TO4_16  = 27,
    }

    [DataWidth(num5.Width)]
    public enum Broadcast32 : byte
    {
        [Symbol(N1to16, "BCAST=1;VL=512")]
        BCast_1TO16_32 = 1,

        [Symbol(N4to16, "BCAST=2;VL=512")]
        BCast_4TO16_32 = 2,

        [Symbol(N1to8, "BCAST=3;VL=256")]
        BCast_1TO8_32 = 3,

        [Symbol(N4to8, "BCAST=4;VL=256")]
        BCast_4TO8_32 = 4,

        [Symbol(N2to16, "BCAST=7;VL=512")]
        BCast_2TO16_32 = 7,

        [Symbol(N8to16, "BCAST=9;VL=512")]
        BCast_8TO16_32 = 9,

        [Symbol(N1to4, "BCAST=10;VL=512")]
        BCast_1TO4_32 = 10,

        [Symbol(N2to4, "BCAST=12;VL=128")]
        BCast_2TO4_32 = 12,

        [Symbol(N2to8, "BCAST=21;VL=256")]
        BCast_2TO8_32 = 21,

        [Symbol(N1to2, "BCAST=22;VL=128")]
        BCast_1TO2_32 = 22,
    }

    [DataWidth(num5.Width)]
    public enum Broadcast64 : byte
    {
        [Symbol(N1to8, "BCAST=5;VL=512")]
        BCast_1TO8_64 = 5,

        [Symbol(N4to8, "BCAST=6;VL=512")]
        BCast_4TO8_64 = 6,

        [Symbol(N2to8, "BCAST=8;VL=512")]
        BCast_2TO8_64 = 8,

        [Symbol(N1to2, "BCAST=11;VL=128")]
        BCast_1TO2_64 = 11,

        [Symbol(N1to4, "BCAST=13;VL=256")]
        BCast_1TO4_64 = 13,

        [Symbol(N2to4, "BCAST=20;VL=256")]
        BCast_2TO4_64 = 20,
    }

}
