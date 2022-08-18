//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Identifies refinement classes of the ModRm byte
    /// </summary>
    public enum ModRmKind
    {
        None = 0,

        /// <summary>
        /// Restricts the ModRm domain to values where mod[7:6] != 0b11
        /// </summary>
        RD = 1,

        /// <summary>
        /// Restricts the ModRm domain to values where mod[7:6] = 0b11
        /// </summary>
        RR = 2,
    }

    public enum ModRmMod16 : byte
    {
        RD0 = 0b00,

        RD8 = 0b01,

        RD16 = 0b10,

        RR = 0b11,
    }

    public enum ModRmMod32 : byte
    {
        RD0 = 0b00,

        RD8 = 0b01,

        RD32 = 0b10,

        RR = 0b11,
    }
}