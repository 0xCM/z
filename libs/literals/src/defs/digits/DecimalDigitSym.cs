//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the symbols that represent the base-10 digits
    /// </summary>
    [SymSource(decimal_digits, NBK.Base10)]
    public enum DecimalDigitSym : ushort
    {
        /// <summary>
        /// The code with no substance
        /// </summary>
        Null = 0,

        /// <summary>
        /// Specifies 0 base 10, asci code 48
        /// </summary>
        [Symbol('0')]
        d0 = '0',

        /// <summary>
        /// Specifies 1 base 10, asci code 49
        /// </summary>
        [Symbol('1')]
        d1 = '1',

        /// <summary>
        /// Specifies 2 base 10, asci code 50
        /// </summary>
        [Symbol('2')]
        d2 = '2',

        /// <summary>
        /// Specifies 3 base 10, asci code 51
        /// </summary>
        [Symbol('3')]
        d3 = '3',

        /// <summary>
        /// Specifies 4 base 10, asci code 52
        /// </summary>
        [Symbol('4')]
        d4 = '4',

        /// <summary>
        /// Specifies 5 base 10, asci code 53
        /// </summary>
        [Symbol('5')]
        d5 = '5',

        /// <summary>
        /// Specifies 6 base 10, asci code 54
        /// </summary>
        [Symbol('6')]
        d6 = '6',

        /// <summary>
        /// Specifies 7 base 10, asci code 55
        /// </summary>
        [Symbol('7')]
        d7 = '7',

        /// <summary>
        /// Specifies 8 base 10, asci code 56
        /// </summary>
        [Symbol('8')]
        d8 = '8',

        /// <summary>
        /// Specifies 9 base 10, asci code 57
        /// </summary>
        [Symbol('9')]
        d9 = '9',
    }
}