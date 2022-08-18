//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedModels.BCastKind;
    using static BroadcastClass;
    using static AsmBroadcast;

    partial class XedOps
    {
        [MethodImpl(Inline), Op]
        public static bool broadcast(in PatternOp src, out BCastKind dst)
        {
            dst = 0;
            if(src.Kind == OpKind.Bcast)
                if(XedParsers.parse(src.SourceExpr, out dst))
                    return true;
            return false;
        }

        public static Index<AsmBroadcast> broadcasts(ReadOnlySpan<BCastKind> src)
        {
            var dst = alloc<AsmBroadcast>(src.Length);
            for(var j=0; j<src.Length; j++)
                seek(dst,j) = XedOps.broadcast(skip(src,j));
            return dst;
        }

        [Op]
        public static AsmBroadcast broadcast(BCastKind kind)
        {
            var dst = AsmBroadcast.Empty;
            var id = (uint5)(byte)kind;
            switch(kind)
            {
                case BCast_1TO16_8:
                    dst = define(id, BCast8, XedRender.format(BCast8Kind.BCast_1TO16_8), 1, 16);
                break;

                case BCast_1TO32_8:
                    dst = define(id, BCast8, XedRender.format(BCast8Kind.BCast_1TO32_8), 1, 32);
                break;

                case BCast_1TO64_8:
                    dst = define(id, BCast8, XedRender.format(BCast8Kind.BCast_1TO64_8), 1, 64);
                break;

                case BCast_1TO2_8:
                    dst = define(id, BCast8, XedRender.format(BCast8Kind.BCast_1TO2_8), 1, 8);
                break;

                case BCast_1TO4_8:
                    dst = define(id, BCast8, XedRender.format(BCast8Kind.BCast_1TO4_8), 1, 4);
                break;

                case BCast_1TO8_8:
                    dst = define(id, BCast8, XedRender.format(BCast8Kind.BCast_1TO8_8), 1, 8);
                break;

                case BCast_1TO8_16:
                    dst = define(id, BCast16, XedRender.format(BCast16Kind.BCast_1TO8_16), 1, 8);
                break;

                case BCast_1TO16_16:
                    dst = define(id, BCast16, XedRender.format(BCast16Kind.BCast_1TO16_16), 1, 16);
                break;

                case BCast_1TO32_16:
                    dst = define(id, BCast16, XedRender.format(BCast16Kind.BCast_1TO32_16), 1, 32);
                break;

                case BCast_1TO2_16:
                    dst = define(id, BCast16, XedRender.format(BCast16Kind.BCast_1TO2_16), 1, 2);
                break;

                case BCast_1TO4_16:
                    dst = define(id, BCast16, XedRender.format(BCast16Kind.BCast_1TO4_16), 1, 4);
                break;

                case BCast_1TO16_32:
                    dst = define(id, BCast32, XedRender.format(BCast32Kind.BCast_1TO16_32), 1, 16);
                break;

                case BCast_4TO16_32:
                    dst = define(id, BCast32, XedRender.format(BCast32Kind.BCast_4TO16_32), 4, 16);
                break;

                case BCast_1TO8_32:
                    dst = define(id, BCast32, XedRender.format(BCast32Kind.BCast_1TO8_32), 1, 8);
                break;

                case BCast_4TO8_32:
                    dst = define(id, BCast32, XedRender.format(BCast32Kind.BCast_4TO8_32), 4, 8);
                break;

                case BCast_2TO16_32:
                    dst = define(id, BCast32, XedRender.format(BCast32Kind.BCast_2TO16_32), 2, 16);
                break;

                case BCast_8TO16_32:
                    dst = define(id, BCast32, XedRender.format(BCast32Kind.BCast_8TO16_32), 8, 16);
                break;

                case BCast_1TO4_32:
                    dst = define(id, BCast32, XedRender.format(BCast32Kind.BCast_1TO4_32), 1, 4);
                break;

                case BCast_2TO4_32:
                    dst = define(id, BCast32, XedRender.format(BCast32Kind.BCast_2TO4_32), 2, 4);
                break;

                case BCast_2TO8_32:
                    dst = define(id, BCast32, XedRender.format(BCast32Kind.BCast_2TO8_32), 2, 8);
                break;

                case BCast_1TO2_32:
                    dst = define(id, BCast32, XedRender.format(BCast32Kind.BCast_1TO2_32), 1, 2);
                break;

                case BCast_1TO8_64:
                    dst = define(id, BCast64, XedRender.format(BCast64Kind.BCast_1TO8_64), 1, 8);
                break;

                case BCast_4TO8_64:
                    dst = define(id, BCast64, XedRender.format(BCast64Kind.BCast_4TO8_64), 4, 8);
                break;

                case BCastKind.BCast_2TO8_64:
                    dst = define(id, BCast64, XedRender.format(BCast64Kind.BCast_2TO8_64), 2, 8);
                break;

                case BCastKind.BCast_1TO2_64:
                    dst = define(id, BCast64, XedRender.format(BCast64Kind.BCast_1TO2_64), 1, 2);
                break;

                case BCastKind.BCast_1TO4_64:
                    dst = define(id, BCast64, XedRender.format(BCast64Kind.BCast_1TO4_64), 1, 4);
                break;

                case BCastKind.BCast_2TO4_64:
                    dst = define(id, BCast64, XedRender.format(BCast64Kind.BCast_2TO4_64), 2, 64);
                break;
            }

            return dst;
        }
    }
}