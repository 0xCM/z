//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines identifiers corresponding to each value that can be represented with a 4-bit unsigned integer
    /// </summary>
    [SymSource(hex_digits, NBK.Base16), DataWidth(4)]
    public enum Hex4Kind : byte
    {
        /// <summary>
        /// Identifies the hex value 0x00 := 0
        /// </summary>
        x00 = 0x00,

        /// <summary>
        /// Identifies the hex value 0x01 := 1
        /// </summary>
        x01 = 0x01,

        /// <summary>
        /// Identifies the hex value 0x02 := 2
        /// </summary>
        x02 = 0x02,

        /// <summary>
        /// Identifies the hex value 0x03 := 3
        /// </summary>
        x03 = 0x03,

        /// <summary>
        /// Identifies the hex value 0x04 := 4
        /// </summary>
        x04 = 0x04,

        /// <summary>
        /// Identifies the hex value 0x05 := 5
        /// </summary>
        x05 = 0x05,

        /// <summary>
        /// Identifies the hex value 0x06 := 6
        /// </summary>
        x06 = 0x06,

        /// <summary>
        /// Identifies the hex value 0x07 := 7
        /// </summary>
        x07 = 0x07,

        /// <summary>
        /// Identifies the hex value 0x08 := 8
        /// </summary>
        x08 = 0x08,

        /// <summary>
        /// Identifies the hex value 0x09 := 9
        /// </summary>
        x09 = 0x09,

        /// <summary>
        /// Identifies the hex value 0x0A := 10
        /// </summary>
        x0A = 0x0A,

        /// <summary>
        /// Identifies the hex value 0x0B := 11
        /// </summary>
        x0B = 0x0B,

        /// <summary>
        /// Identifies the hex value 0x0C := 12
        /// </summary>
        x0C = 0x0C,

        /// <summary>
        /// Identifies the hex value 0x0D := 13
        /// </summary>
        x0D = 0x0D,

        /// <summary>
        /// Identifies the hex value 0x0E := 14
        /// </summary>
        x0E = 0x0E,

        /// <summary>
        /// Identifies the hex value 0x0F := 15
        /// </summary>
        x0F = 0x0F,
    }
}