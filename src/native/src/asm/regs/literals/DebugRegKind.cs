//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static RegFacets;
    using static RegIndexCode;
    using static RegClassCode;
    using static NativeSizeCode;
    using static NumericBaseKind;

    /// <summary>
    /// Classifies the accessible debug registers
    /// </summary>
    [SymSource("asm.regs.bits", Base16)]
    public enum DebugRegKind : ushort
    {
        DR0 = r0 | DB << ClassField | W64 << WidthField,

        DR1 = r1 | DB << ClassField | W64 << WidthField,

        DR2 = r2 | DB << ClassField | W64 << WidthField,

        DR3 = r3 | DB << ClassField | W64 << WidthField,

        DR4 = r4 | DB << ClassField | W64 << WidthField,

        DR5 = r5 | DB << ClassField | W64 << WidthField,

        DR6 = r6 | DB << ClassField | W64 << WidthField,

        DR7 = r7 | DB << ClassField | W64 << WidthField,
    }
}