//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines literals that correspond to base-2 digits
    /// </summary>
    [SymSource(binary_digits,NBK.Base2)]
    public enum BinaryDigitValue : byte
    {
        /// <summary>
        /// Specifies the absence of a digit
        /// </summary>
        None = 0xFF,

        /// <summary>
        /// Specifies 0 base 2
        /// </summary>
        b0 = 0,

        /// <summary>
        /// Specifies 1 base 2
        /// </summary>
        b1 = 1,
    }
}