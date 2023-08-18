//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [SymSource(xed), DataWidth(num5.Width)]
    public enum OpNameKind : byte
    {
        None = 0,

        REG0 = 1,

        REG1 = 2,

        REG2 = 3,

        REG3 = 4,

        REG4 = 5,

        REG5 = 6,

        REG6 = 7,

        REG7 = 8,

        REG8 = 9,

        REG9 = 10,

        MEM0 = 11,

        MEM1 = 12,

        IMM0 = 13,

        IMM1 = 14,

        IMM2 = 15,

        RELBR = 16,

        BASE0 = 17,

        BASE1 = 18,

        SEG0 = 19,

        SEG1 = 20,

        AGEN = 21,

        PTR = 22,

        INDEX = 23,

        SCALE = 24,

        DISP = 25,
    }
}
