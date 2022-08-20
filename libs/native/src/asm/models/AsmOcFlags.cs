//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using P = Pow2x32;

    [Flags, SymSource(asm)]
    public enum AsmOcFlags : uint
    {
        None = 0,

        Hex8 = P.P2ᐞ00,

        Rex = P.P2ᐞ01,

        Vex = P.P2ᐞ02,

        Evex = P.P2ᐞ03,

        RexB = P.P2ᐞ04,

        RegDigit = P.P2ᐞ05,

        SegOverride = P.P2ᐞ06,

        Disp = P.P2ᐞ07,

        ImmSize = P.P2ᐞ08,

        Exclusion = P.P2ᐞ09,

        FpuDigit = P.P2ᐞ10,

        Mask = P.P2ᐞ11,

        ModRm = P.P2ᐞ12,

        Literal = P.P2ᐞ13,

        Rep = P.P2ᐞ14,

        Size = P.P2ᐞ15,

        Lock = P.P2ᐞ16,

        Operator = P.P2ᐞ17,

        Hex16 = P.P2ᐞ18,
    }
}