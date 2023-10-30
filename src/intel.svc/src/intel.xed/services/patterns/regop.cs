//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

partial class XedPatterns
{
    public static RegOp regop(XedRegId src)
        => XedRegMap.convert(src);

    public static XedRegId regid(RegKind src)
        => XedRegMap.convert(src);
}

