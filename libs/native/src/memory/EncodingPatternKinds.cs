//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum EncodingPatternKind : long
    {
        None = 0,

        RET_SBB = ExtractTermCode.CTC_RET_SBB,

        RET_INTR = ExtractTermCode.CTC_RET_INTR,

        RET_ZED_SBB = ExtractTermCode.CTC_RET_ZED_SBB,

        RET_Zx3 = ExtractTermCode.CTC_RET_Zx3,

        RET_Zx7 = ExtractTermCode.CTC_RET_Zx7,

        INTRx2 = ExtractTermCode.CTC_INTRx2,

        /// <summary>
        /// Identifies the pattern 00 00 00 00 00 00 00
        /// </summary>
        Zx7 = ExtractTermCode.CTC_Zx7,

        JMP_RAX = ExtractTermCode.CTC_JMP_RAX,

        /// <summary>
        /// Identifies the partial pattern e8 ?? ?? ?? ?? cc
        /// </summary>
        CALL32_INTR = 2*16
    }
}