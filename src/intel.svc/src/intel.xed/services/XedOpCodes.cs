//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using V = XedVexClass;
using I = AsmOpCodeIndex;
using X = XopMapKind;
using K = AsmOpCodeKind;
using E = EvexMapKind;

public class XedOpCodes
{
    [Op]
    public static I? index(V @class, byte map)
    {
        var dst = default(I?);
        switch(@class)
        {
            case V.VV1:
                dst = AsmOpCodes.index((VexMapKind)map);
            break;
            case V.EVV:
                dst = AsmOpCodes.index((E)map);
            break;
            case V.XOPV:
                dst = AsmOpCodes.index((X)map);
            break;
            default:
                dst = AsmOpCodes.index((LegacyMapKind)map);
            break;
        }
        return dst;
    }

    public static K kind(V vc, byte number)
    {
        var ock = K.None;
        switch(vc)
        {
            case V.VV1:
                ock = AsmOpCodes.kind(AsmOpCodes.index((VexMapKind)number));
            break;
            case V.XOPV:
                ock = AsmOpCodes.kind(AsmOpCodes.index((X)number));
            break;
            case V.EVV:
            case V.KVV:
                ock = AsmOpCodes.kind(AsmOpCodes.index((E)number));
            break;
            default:
                ock = AsmOpCodes.kind((I)AsmOpCodes.basemap(number));
            break;
        }
        return ock;
    }


    [MethodImpl(Inline), Op]
    public static VexMapKind? vexmap(V kind, byte code)
        => kind == V.VV1 ? (VexMapKind)code : null;

    [MethodImpl(Inline), Op]
    public static E? evexmap(V kind, byte code)
        => kind == V.EVV ? (E)code : null;

    [MethodImpl(Inline), Op]
    public static X? xopmap(V kind, byte code)
        => kind == V.XOPV ? (X)code : null;

    [Op]
    public static V vexclass(I src)
        => vexclass(AsmOpCodes.@class(src));

    [Op]
    public static V vexclass(AsmOpCodeClass src)
    {
        var vc = V.None;
        switch(src)
        {
            case AsmOpCodeClass.Vex:
                vc = V.VV1;
            break;
            case AsmOpCodeClass.Evex:
                vc = V.VV1;
            break;
            case AsmOpCodeClass.Xop:
                vc = V.XOPV;
            break;
        }
        return vc;
    }

}