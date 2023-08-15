//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using S = AsmOpCodes.Literals;

[SymSource(AsmOpCodes.group), DataWidth(2)]
public enum VexMapKind : byte
{
    [Symbol(S.V1, "MAP=1")]
    VEX_MAP_0F = 1,

    [Symbol(S.V2, "MAP=2")]
    VEX_MAP_0F38 = 2,

    [Symbol(S.V3, "MAP=3")]
    VEX_MAP_0F3A = 3
}
