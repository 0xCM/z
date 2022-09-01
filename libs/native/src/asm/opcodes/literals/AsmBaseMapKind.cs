//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = AsmOpCodeMaps.Literals;

    [SymSource(AsmOpCodeMaps.group), DataWidth(3)]
    public enum AsmBaseMapKind : byte
    {
        [Symbol(S.B0)]
        BaseMap0 = 0,

        [Symbol(S.B1)]
        BaseMap1 = 1,

        [Symbol(S.B2)]
        BaseMap2 = 2,

        [Symbol(S.B3)]
        BaseMap3 = 3,

        [Symbol(S.D3)]
        Amd3dNow = 4,
    }
}