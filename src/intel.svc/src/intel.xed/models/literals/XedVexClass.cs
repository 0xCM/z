//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

[SymSource(AsmOpCodes.group), DataWidth(3)]
public enum XedVexClass : byte
{
    [Symbol("legacy", "VEXVALID=0")]
    None = 0,

    [Symbol("vex", "VEXVALID=1")]
    VV1 = 1,

    [Symbol("evex", "VEXVALID=2")]
    EVV = 2,

    [Symbol("xop", "VEXVALID=3")]
    XOPV = 3,
}    
