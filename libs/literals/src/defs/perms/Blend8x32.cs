//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines control mask values for constructing a 256-bit target by blending 8 32-bit segments from two source vectors
    /// </summary>
    [SymSource(blends, NBK.Base2), Flags]
    public enum Blend8x32 : byte
    {
        LLLLLLLL = 0b00000000,

        RRRRRRRR = 0b11111111,

        LRLRLRLR = 0b10101010,

        RLRLRLRL = 0b01010101,

        LLRRLLRR = 0b11001100,

        RRLLRRLL = 0b00110011,

        LLLLRRRR = 0b11110000,

        RRRRLLLL = 0b00001111
    }
}