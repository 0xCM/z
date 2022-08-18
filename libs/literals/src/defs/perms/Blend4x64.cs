//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines control mask values for constructing a 256-bit target by blending 4 64-bit segments from two source vectors
    /// </summary>
    [SymSource(blends, NBK.Base2), Flags]
    public enum Blend4x64 : byte
    {
         LLLL = 0b0000,

         RRRR = 0b1111,

         LRLR = 0b1010,

         RLRL = 0b0101,

         LLRR = 0b1100,

         RRLL = 0b0011,
    }
}