//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    
    /// <summary>
    /// Defines identifiers corresponding to the hex digits 0 and 1
    /// </summary>
    [SymSource(hex_digits, NBK.Base16), DataWidth(1)]
    public enum Hex1Kind : byte
    {
        /// <summary>
        /// Identifies the hex value 0x00 := 0
        /// </summary>
        x00 = 0x0,

        /// <summary>
        /// Identifies the hex value 0x01 := 1
        /// </summary>
        x01 = 0x1,
    }
}