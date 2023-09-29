//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;
using static BroadcastSymbols;
using static BroadcastKind;
using static BroadcastClass;

partial struct asm
{
    [MethodImpl(Inline)]
    static AsmBroadcast broadcast(byte id, BroadcastClass @class, asci16 symbol, byte src, byte dst)
        => new (id, @class, symbol, src, dst);

    [Op]
    public static AsmBroadcast broadcast(BroadcastKind kind)
    {
        var dst = AsmBroadcast.Empty;
        var id = (uint5)(byte)kind;
        switch(kind)
        {
            case BCast_1TO16_8:
                dst = broadcast(id, BCast8, N1to16, 1, 16);
            break;

            case BCast_1TO32_8:
                dst = broadcast(id, BCast8, N1to32, 1, 32);
            break;

            case BCast_1TO64_8:
                dst = broadcast(id, BCast8, N1to64, 1, 64);
            break;

            case BCast_1TO2_8:
                dst = broadcast(id, BCast8, N1to8, 1, 8);
            break;

            case BCast_1TO4_8:
                dst = broadcast(id, BCast8, N1to4, 1, 4);
            break;

            case BCast_1TO8_8:
                dst = broadcast(id, BCast8, N1to8, 1, 8);
            break;

            case BCast_1TO8_16:
                dst = broadcast(id, BCast16, N1to8, 1, 8);
            break;

            case BCast_1TO16_16:
                dst = broadcast(id, BCast16, N1to16, 1, 16);
            break;

            case BCast_1TO32_16:
                dst = broadcast(id, BCast16, N1to32, 1, 32);
            break;

            case BCast_1TO2_16:
                dst = broadcast(id, BCast16, N1to2, 1, 2);
            break;

            case BCast_1TO4_16:
                dst = broadcast(id, BCast16, N1to4, 1, 4);
            break;

            case BCast_1TO16_32:
                dst = broadcast(id, BCast32, N1to16, 1, 16);
            break;

            case BCast_4TO16_32:
                dst = broadcast(id, BCast32, N4to16, 4, 16);
            break;

            case BCast_1TO8_32:
                dst = broadcast(id, BCast32, N1to8, 1, 8);
            break;

            case BCast_4TO8_32:
                dst = broadcast(id, BCast32, N4to8, 4, 8);
            break;

            case BCast_2TO16_32:
                dst = broadcast(id, BCast32, N2to16, 2, 16);
            break;

            case BCast_8TO16_32:
                dst = broadcast(id, BCast32, N8to16, 8, 16);
            break;

            case BCast_1TO4_32:
                dst = broadcast(id, BCast32, N1to4, 1, 4);
            break;

            case BCast_2TO4_32:
                dst = broadcast(id, BCast32, N1to4, 2, 4);
            break;

            case BCast_2TO8_32:
                dst = broadcast(id, BCast32, N2to8, 2, 8);
            break;

            case BCast_1TO2_32:
                dst = broadcast(id, BCast32, N1to2, 1, 2);
            break;

            case BCast_1TO8_64:
                dst = broadcast(id, BCast64, N1to8, 1, 8);
            break;

            case BCast_4TO8_64:
                dst = broadcast(id, BCast64, N4to8, 4, 8);
            break;

            case BCast_2TO8_64:
                dst = broadcast(id, BCast64, N2to8, 2, 8);
            break;

            case BCast_1TO2_64:
                dst = broadcast(id, BCast64, N1to2, 1, 2);
            break;

            case BCast_1TO4_64:
                dst = broadcast(id, BCast64, N1to4, 1, 4);
            break;

            case BCast_2TO4_64:
                dst = broadcast(id, BCast64, N2to4, 2, 4);
            break;
        }

        return dst;
    }
}