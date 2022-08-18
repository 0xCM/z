//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines literals that indicate the reason for exraction termination
    /// </summary>
    public enum ExtractTermCode : byte
    {
        None = 0,

        CTC_RET_SBB,
        
        CTC_RET_INTR,

        CTC_RET_ZED_SBB,
        
        CTC_RET_Zx3,

        CTC_RET_Zx7,

        CTC_INTRx2,

        /// <summary>
        /// Identifies the pattern 00 00 00 00 00 00 00
        /// </summary>
        CTC_Zx7,

        CTC_JMP_RAX,

        CTC_BUFFER_OUT,

        CTC_MSDIAG,        

        /// <summary>
        /// Identifies the partial pattern e8 ?? ?? ?? ?? cc
        /// </summary>
        CTC_CALL32_INTR = 2*16,

        Fail = byte.MaxValue,
    }
}