//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class Xed
{
    public static AsmOpCodeClass occlass(XedVexClass src)
        => src switch {
            XedVexClass.VV1 =>AsmOpCodeClass.Vex,
            XedVexClass.EVV => AsmOpCodeClass.Evex,
            XedVexClass.XOPV => AsmOpCodeClass.Xop,
            _ => AsmOpCodeClass.Legacy
        };
}