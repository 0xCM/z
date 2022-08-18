//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Pow2x32;
    using static NumericBaseKind;

    /// <summary>
    /// Defines literals corresponding the bits in the RFLAGS register
    /// </summary>
    [Flags, SymSource("asm.regs.flags", Base16)]
    public enum RFlagBits : uint
    {
        None = 0,

        CF = P2ᐞ00,

        PF = P2ᐞ02,

        AF = P2ᐞ04,

        ZF = P2ᐞ06,

        SF = P2ᐞ07,

        TF = P2ᐞ08,

        IF = P2ᐞ09,

        DF = P2ᐞ10,

        OF = P2ᐞ11,

        RF = P2ᐞ16,

        VM = P2ᐞ17,

        AC = P2ᐞ18,

        VIF = P2ᐞ19,

        VIP = P2ᐞ20,

        ID = P2ᐞ21,
    }
}