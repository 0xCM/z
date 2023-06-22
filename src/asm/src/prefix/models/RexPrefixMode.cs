//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource("asm")]
    public enum RexPrefixMode : byte
    {
        [Symbol("00")]
        R00 = 0,

        [Symbol("01")]
        R01 = 1,

        [Symbol("10")]
        R10 = 2,

        [Symbol("11")]
        R11 = 3,

        Indirect = R00 | R01 | R10,

        Direct = R11,
    }
}