//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a parition over hex digits
    /// </summary>
    [SymSource(hex_digits, NBK.Base16)]
    public enum HexDigitKind : byte
    {
        None = 0,

        /// <summary>
        /// Classifies digits from the sequence '0',..,'9'
        /// </summary>
        Number,

        /// <summary>
        /// Classifies digits from the sequence 'a',..,'b'
        /// </summary>
        LowerLetter,

        /// <summary>
        /// Classifies digits from the sequence 'A',..,'F'
        /// </summary>
        UpperLetter,
    }
}