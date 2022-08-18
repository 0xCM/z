//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = DecimalDigitSym;

    /// <summary>
    /// Defines the symbols that represent the base-10 digits
    /// </summary>
    [SymSource(decimal_digits, NBK.Base10)]
    public enum DecimalDigitCode : byte
    {
        None = 0,

        /// <summary>
        /// Specifies the asci code for the digit '0'
        /// </summary>
        d0 = (byte)S.d0,

        /// <summary>
        /// Specifies the asci code for the digit '1'
        /// </summary>
        d1 = (byte)S.d1,

        /// <summary>
        /// Specifies the asci code for the digit '2'
        /// </summary>
        d2 = (byte)S.d2,

        /// <summary>
        /// Specifies the asci code for the digit '3'
        /// </summary>
        d3 = (byte)S.d3,

        /// <summary>
        /// Specifies the asci code for the digit '4'
        /// </summary>
        d4 = (byte)S.d4,

        /// <summary>
        /// Specifies the asci code for the digit '5'
        /// </summary>
        d5 = (byte)S.d5,

        /// <summary>
        /// Specifies the asci code for the digit '6'
        /// </summary>
        d6 = (byte)S.d6,

        /// <summary>
        /// Specifies the asci code for the digit '7'
        /// </summary>
        d7 = (byte)S.d7,

        /// <summary>
        /// Specifies the asci code for the digit '8'
        /// </summary>
        d8 = (byte)S.d8,

        /// <summary>
        /// Specifies the asci code for the digit '9'
        /// </summary>
        d9 = (byte)S.d9,
    }
}