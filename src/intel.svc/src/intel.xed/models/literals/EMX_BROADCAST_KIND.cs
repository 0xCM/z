//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;
using BK = Asm.BroadcastKind;

partial class XedModels
{
    [DataWidth(num5.Width)]
    public enum EMX_BROADCAST_KIND : byte
    {
        EMX_BROADCAST_1TO4_32 = BK.BCast_1TO4_32,

        EMX_BROADCAST_1TO4_64 = BK.BCast_1TO4_64,

        EMX_BROADCAST_1TO8_32 = BK.BCast_1TO8_32,

        EMX_BROADCAST_2TO4_64 = BK.BCast_2TO4_64,

        EMX_BROADCAST_1TO2_64 = BK.BCast_1TO2_64,

        EMX_BROADCAST_1TO8_16 = BK.BCast_1TO8_16,

        EMX_BROADCAST_1TO16_16 = BK.BCast_1TO16_16,

        EMX_BROADCAST_1TO16_8 = BK.BCast_1TO16_8,

        EMX_BROADCAST_1TO32_8 = BK.BCast_1TO32_8,

        EMX_BROADCAST_1TO16_32 = BK.BCast_1TO16_32,

        EMX_BROADCAST_4TO16_32 = BK.BCast_4TO16_32,

        EMX_BROADCAST_1TO8_64 = BK.BCast_1TO8_64,

        EMX_BROADCAST_4TO8_64 = BK.BCast_4TO8_64,

        EMX_BROADCAST_2TO16_32 = BK.BCast_2TO16_32,

        EMX_BROADCAST_2TO8_64 = BK.BCast_2TO8_64,

        EMX_BROADCAST_8TO16_32 = BK.BCast_8TO16_32,

        EMX_BROADCAST_1TO32_16 = BK.BCast_1TO32_16,

        EMX_BROADCAST_1TO64_8 = BK.BCast_1TO64_8,

        EMX_BROADCAST_4TO8_32 = BK.BCast_4TO8_32,

        EMX_BROADCAST_2TO4_32 = BK.BCast_2TO4_32,

        EMX_BROADCAST_2TO8_32 = BK.BCast_2TO8_32,

        EMX_BROADCAST_1TO2_32 = BK.BCast_1TO2_32,

        EMX_BROADCAST_1TO2_8 = BK.BCast_1TO2_8,

        EMX_BROADCAST_1TO4_8 = BK.BCast_1TO4_8,

        EMX_BROADCAST_1TO8_8 = BK.BCast_1TO8_8,

        EMX_BROADCAST_1TO2_16 = BK.BCast_1TO2_16,

        EMX_BROADCAST_1TO4_16 = BK.BCast_1TO4_16,
    }
}
