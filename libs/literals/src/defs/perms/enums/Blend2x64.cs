//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines control mask values for constucting a 128-bit target by blending 2 64-bit segments from two source vectors
    /// </summary>
    [SymSource(perms, NBK.Base2),Flags]
    public enum Blend2x64 : byte
    {
         [Symbol("00")]
         LL = 0b00,

         [Symbol("11")]
         RR = 0b11,

         [Symbol("10")]
         LR = 0b10,

         [Symbol("01")]
         RL = 0b01,
    }
}