//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;
using static AsmMaskTokens;
using static BroadcastKind;
using static BroadcastClass;

partial struct asm
{
    [MethodImpl(Inline)]
    static AsmBroadcast broadcast(byte id, BroadcastClass @class, asci16 symbol, byte src, byte dst)
        => new (id,@class,symbol, src, dst);

    [Op]
    public static AsmBroadcast broadcast(BroadcastKind kind)
    {
        var dst = AsmBroadcast.Empty;
        var id = (uint5)(byte)kind;
        switch(kind)
        {
            case BCast_1TO16_8:
                dst = broadcast(id, BCast8, AsmRender.format(Broadcast8.BCast_1TO16_8), 1, 16);
            break;

            case BCast_1TO32_8:
                dst = broadcast(id, BCast8, AsmRender.format(Broadcast8.BCast_1TO32_8), 1, 32);
            break;

            case BCast_1TO64_8:
                dst = broadcast(id, BCast8, AsmRender.format(Broadcast8.BCast_1TO64_8), 1, 64);
            break;

            case BCast_1TO2_8:
                dst = broadcast(id, BCast8, AsmRender.format(Broadcast8.BCast_1TO2_8), 1, 8);
            break;

            case BCast_1TO4_8:
                dst = broadcast(id, BCast8, AsmRender.format(Broadcast8.BCast_1TO4_8), 1, 4);
            break;

            case BCast_1TO8_8:
                dst = broadcast(id, BCast8, AsmRender.format(Broadcast8.BCast_1TO8_8), 1, 8);
            break;

            case BCast_1TO8_16:
                dst = broadcast(id, BCast16, AsmRender.format(Broadcast16.BCast_1TO8_16), 1, 8);
            break;

            case BCast_1TO16_16:
                dst = broadcast(id, BCast16, AsmRender.format(Broadcast16.BCast_1TO16_16), 1, 16);
            break;

            case BCast_1TO32_16:
                dst = broadcast(id, BCast16, AsmRender.format(Broadcast16.BCast_1TO32_16), 1, 32);
            break;

            case BCast_1TO2_16:
                dst = broadcast(id, BCast16, AsmRender.format(Broadcast16.BCast_1TO2_16), 1, 2);
            break;

            case BCast_1TO4_16:
                dst = broadcast(id, BCast16, AsmRender.format(Broadcast16.BCast_1TO4_16), 1, 4);
            break;

            case BCast_1TO16_32:
                dst = broadcast(id, BCast32, AsmRender.format(Broadcast32.BCast_1TO16_32), 1, 16);
            break;

            case BCast_4TO16_32:
                dst = broadcast(id, BCast32, AsmRender.format(Broadcast32.BCast_4TO16_32), 4, 16);
            break;

            case BCast_1TO8_32:
                dst = broadcast(id, BCast32, AsmRender.format(Broadcast32.BCast_1TO8_32), 1, 8);
            break;

            case BCast_4TO8_32:
                dst = broadcast(id, BCast32, AsmRender.format(Broadcast32.BCast_4TO8_32), 4, 8);
            break;

            case BCast_2TO16_32:
                dst = broadcast(id, BCast32, AsmRender.format(Broadcast32.BCast_2TO16_32), 2, 16);
            break;

            case BCast_8TO16_32:
                dst = broadcast(id, BCast32, AsmRender.format(Broadcast32.BCast_8TO16_32), 8, 16);
            break;

            case BCast_1TO4_32:
                dst = broadcast(id, BCast32, AsmRender.format(Broadcast32.BCast_1TO4_32), 1, 4);
            break;

            case BCast_2TO4_32:
                dst = broadcast(id, BCast32, AsmRender.format(Broadcast32.BCast_2TO4_32), 2, 4);
            break;

            case BCast_2TO8_32:
                dst = broadcast(id, BCast32, AsmRender.format(Broadcast32.BCast_2TO8_32), 2, 8);
            break;

            case BCast_1TO2_32:
                dst = broadcast(id, BCast32, AsmRender.format(Broadcast32.BCast_1TO2_32), 1, 2);
            break;

            case BCast_1TO8_64:
                dst = broadcast(id, BCast64, AsmRender.format(Broadcast64.BCast_1TO8_64), 1, 8);
            break;

            case BCast_4TO8_64:
                dst = broadcast(id, BCast64, AsmRender.format(Broadcast64.BCast_4TO8_64), 4, 8);
            break;

            case BCast_2TO8_64:
                dst = broadcast(id, BCast64, AsmRender.format(Broadcast64.BCast_2TO8_64), 2, 8);
            break;

            case BCast_1TO2_64:
                dst = broadcast(id, BCast64, AsmRender.format(Broadcast64.BCast_1TO2_64), 1, 2);
            break;

            case BCast_1TO4_64:
                dst = broadcast(id, BCast64, AsmRender.format(Broadcast64.BCast_1TO4_64), 1, 4);
            break;

            case BCast_2TO4_64:
                dst = broadcast(id, BCast64, AsmRender.format(Broadcast64.BCast_2TO4_64), 2, 64);
            break;
        }

        return dst;
    }
}