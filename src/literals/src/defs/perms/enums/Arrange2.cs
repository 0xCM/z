//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource(perms, NBK.Base2),Flags]
    public enum Arrange2L : byte
    {
        A = 0b00,

        B = 0b01,

        C = 0b10,

        D = 0b11,

        AB = 0b1110_0100,

        BA = 0b0100_1110,
    }
}