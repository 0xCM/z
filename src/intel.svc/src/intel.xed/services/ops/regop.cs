//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

partial class Xed
{
    public static RegOp regop(XedRegId src)
        => XedRegMap.Service.Map(src);

    public static XedRegId regid(RegKind src)
        => XedRegMap.Service.Map(src);
}

