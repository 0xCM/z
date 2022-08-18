//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines identifiers corresponding to the hex digits 0,..,3
    /// </summary>
    [SymSource(hex_digits, NBK.Base16), DataWidth(2)]
    public enum Hex2Kind : byte
    {
        /// <summary>
        /// Identifies the hex value 0x00 := 0
        /// </summary>
        x00 = 0x0,

        /// <summary>
        /// Identifies the hex value 0x01 := 1
        /// </summary>
        x01 = 0x1,

        /// <summary>
        /// Identifies the hex value 0x02 := 2
        /// </summary>
        x02 = 0x2,

        /// <summary>
        /// Identifies the hex value 0x03 := 3
        /// </summary>
        x03 = 0x3,
    }
}