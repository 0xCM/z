//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = AsmOpCodeMaps.Literals;
    using C = AsmOpCodeClass;
    using B = AsmBaseMapKind;
    using X = XopMapKind;
    using V = VexMapKind;
    using E = EvexMapKind;

    partial class XedLiterals
    {

    }

    [SymSource(AsmOpCodeMaps.group)]
    public enum XedOpCodeKind : ushort
    {
        None = 0,

        [Symbol(S.B0)]
        Base00 = C.Base | (ushort)((byte)B.BaseMap0 << 8),

        [Symbol(S.B1)]
        Base0F = C.Base | (ushort)((byte)B.BaseMap1 << 8),

        [Symbol(S.B2)]
        Base0F38 = C.Base | (ushort)((byte)B.BaseMap2 << 8),

        [Symbol(S.B3)]
        Base0F3A = C.Base | (ushort)((byte)B.BaseMap3 << 8),

        [Symbol(S.D3)]
        Amd3DNow = C.Base | (ushort)((byte)B.Amd3dNow << 8),

        [Symbol(S.X8)]
        Xop8 = C.Xop | (ushort)((byte)X.Xop8 << 8),

        [Symbol(S.X9)]
        Xop9 = C.Xop | (ushort)((byte)X.Xop9 << 8),

        [Symbol(S.XA)]
        XopA = C.Xop | (ushort)((byte)X.XopA << 8),

        [Symbol(S.V1)]
        Vex0F = C.Vex | (ushort)((byte)V.VEX_MAP_0F << 8),

        [Symbol(S.V2)]
        Vex0F38 = C.Vex | (ushort)((byte)V.VEX_MAP_0F38 << 8),

        [Symbol(S.V3)]
        Vex0F3A = C.Vex | (ushort)((byte)V.VEX_MAP_0F3A << 8),

        [Symbol(S.E1)]
        Evex0F = C.Evex | (ushort)((byte)E.EVEX_MAP_0F << 8),

        [Symbol(S.E2)]
        Evex0F38 = C.Evex | (ushort)((byte)E.EVEX_MAP_0F38 << 8),

        [Symbol(S.E3)]
        Evex0F3A = C.Evex | (ushort)((byte)E.EVEX_MAP_0F3A << 8),
    }
}