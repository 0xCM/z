//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Pow2x32;

    using static AsmPrefixGroup;

    [Flags,SymSource(AsmPrefixCodes.Group)]
    public enum AsmPrefixKind : uint
    {
        None = 0,

        /// <summary>
        /// Lock prefix (Group 1)
        /// </summary>
        [Symbol("LOCK", "Lock prefix (Group 1)")]
        Lock = P2ᐞ01 | (Group1 << 25),

        /// <summary>
        /// F2 Repeat prefix (Group 1)
        /// </summary>
        [Symbol("REPF2", "F2 Repeat prefix (Group 1)")]
        RepF2 = P2ᐞ02 | (Group1 << 25),

        /// <summary>
        /// F3 Repeat prefix (Group 1)
        /// </summary>
        [Symbol("REPF3", "F3 Repeat prefix (Group 1)")]
        RepF3 = P2ᐞ03 | (Group1 << 25),

        /// <summary>
        /// CS seg override prefix (Group 2)
        /// </summary>
        [Symbol("CS", "CS seg override prefix (Group 2)")]
        CsSegOverride = P2ᐞ04 | (Group2 << 25),

        /// <summary>
        /// SS seg override prefix (Group 2)
        /// </summary>
        [Symbol("SS", "SS seg override prefix (Group 2)")]
        SsSegOverride = P2ᐞ05 | (Group3 << 25),

        /// <summary>
        /// DS seg override prefix (Group 2)
        /// </summary>
        [Symbol("DS", "DS seg override prefix (Group 2)")]
        DsSegOverride = P2ᐞ06 | (Group2 << 25),

        /// <summary>
        /// ES seg override prefix (Group 2)
        /// </summary>
        [Symbol("ES", "ES seg override prefix (Group 2)")]
        EsSegOverride = P2ᐞ07 | (Group2 << 25),

        /// <summary>
        /// FS seg override prefix (Group 2)
        /// </summary>
        [Symbol("FS", "FS seg override prefix (Group 2)")]
        FsSegOverride = P2ᐞ08 | (Group2 << 25),

        /// <summary>
        /// GS seg override prefix (Group 2)
        /// </summary>
        [Symbol("GS", "GS seg override prefix (Group 2)")]
        GsSegOverride = P2ᐞ09 | (Group2 << 25),

        /// <summary>
        /// Branch hint taken (Group 2)
        /// </summary>
        [Symbol("BR1", "Branch hint taken (Group 2)")]
        BranchTaken = P2ᐞ10 | (Group2 << 25),

        /// <summary>
        /// Branch hint not taken  (Group 2)
        /// </summary>
        [Symbol("BR0", "Branch hint not taken  (Group 2)")]
        BranchNotTaken = P2ᐞ11 | (Group2 << 25),

        /// <summary>
        /// Operand size override (Group 3)
        /// </summary>
        [Symbol("OSZ", "Operand size override (Group 3)")]
        OSZ = P2ᐞ12 | (Group3 << 25),

        /// <summary>
        /// Address size override (Group 4)
        /// </summary>
        [Symbol("ASZ", "Address size override (Group 4)")]
        ASZ = P2ᐞ13 | (Group4 << 25),

        /// <summary>
        /// Rex prefix
        /// </summary>
        [Symbol("REX", "Rex prefix")]
        Rex = P2ᐞ20,

        /// <summary>
        /// VEX C4 prefix
        /// </summary>
        [Symbol("VexC4", "VEX C4 prefix")]
        VexC4 = P2ᐞ21,

        /// <summary>
        /// VEX C5 prefix
        /// </summary>
        [Symbol("VexC5", "VEX C5 prefix")]
        VexC5 = P2ᐞ22,

        /// <summary>
        /// EVEX prefix
        /// </summary>
        [Symbol("EVEX", "EVEX prefix")]
        Evex = P2ᐞ23,
    }
}