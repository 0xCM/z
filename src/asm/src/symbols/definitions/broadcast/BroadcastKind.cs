//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static BroadcastTokens;

[DataWidth(num5.Width)]
public enum BroadcastKind : byte
{
    None = 0,

    BCast_1TO16_32 = Broadcast32.BCast_1TO16_32,

    BCast_4TO16_32 = Broadcast32.BCast_4TO16_32,

    BCast_1TO8_32 = Broadcast32.BCast_1TO8_32,

    BCast_4TO8_32 = Broadcast32.BCast_4TO8_32,

    BCast_1TO8_64 = Broadcast64.BCast_1TO8_64,

    BCast_4TO8_64 = Broadcast64.BCast_4TO8_64,

    BCast_2TO16_32 = Broadcast32.BCast_2TO16_32,

    BCast_2TO8_64 = Broadcast64.BCast_2TO8_64,

    BCast_8TO16_32 = Broadcast32.BCast_8TO16_32,

    BCast_1TO4_32 = Broadcast32.BCast_1TO4_32,

    BCast_1TO2_64 = Broadcast64.BCast_1TO2_64,

    BCast_2TO4_32 = Broadcast32.BCast_2TO4_32,

    BCast_1TO4_64 = Broadcast64.BCast_1TO4_64,

    BCast_1TO8_16 = Broadcast16.BCast_1TO8_16,

    BCast_1TO16_16 = Broadcast16.BCast_1TO16_16,

    BCast_1TO32_16 = Broadcast16.BCast_1TO32_16,

    BCast_1TO16_8 = Broadcast8.BCast_1TO16_8,

    BCast_1TO32_8 = Broadcast8.BCast_1TO32_8,

    BCast_1TO64_8 = Broadcast8.BCast_1TO64_8,

    BCast_2TO4_64 = Broadcast64.BCast_2TO4_64,

    BCast_2TO8_32 = Broadcast32.BCast_2TO8_32,

    BCast_1TO2_32 = Broadcast32.BCast_1TO2_32,

    BCast_1TO2_8  = Broadcast8.BCast_1TO2_8,

    BCast_1TO4_8  = Broadcast8.BCast_1TO4_8,

    BCast_1TO8_8  = Broadcast8.BCast_1TO8_8,

    BCast_1TO2_16  = Broadcast16.BCast_1TO2_16,

    BCast_1TO4_16  = Broadcast16.BCast_1TO4_16,
}

