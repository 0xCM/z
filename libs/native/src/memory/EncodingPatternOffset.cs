//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum EncodingPatternOffset : int
    {
        None = 0,

        RET_SBB = -1,

        RET_INT = -1,

        RET_ZED_SBB = -2,

        RET_Zx3 = -2,

        RET_INTRx2 = -2,

        CALL32_INTR = 0,

        JMP_RAX = 0,

        Z7 = -7,

        RET_Zx7 = -6,
    }
}