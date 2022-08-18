//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the symbols that represent the base-2 digits
    /// </summary>
    [SymSource(binary_digits,NBK.Base2)]
    public enum BinaryDigitSym : ushort
    {
        /// <summary>
        /// The symbolic void
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies 0 base 2, asci code 48
        /// </summary>
        b0 = '0',

        /// <summary>
        /// Specifies 1 base 2, asci code 49
        /// </summary>
        b1 = '1',
    }
}