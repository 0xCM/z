//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public enum Blend16x16 : ushort
{
    LLLLLLLLLLLLLLLL = 0b0000000000000000,

    RRRRRRRRRRRRRRRR = 0b1111111111111111,

    LRLRLRLRRLRLRLRL = 0b0101010110101010,

    LLRRLLRRRRLLRRLL = 0b0011001111001100,

    LLLLRRRRRRRRLLLL = 0b0000111111110000,

    RRLLLLRRLLRRRRLL = 0b1100001100111100,

    RRRLLRRRLLLRRLLL = 0b1110011100011000,
}
