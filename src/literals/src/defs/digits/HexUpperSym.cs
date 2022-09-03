//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the symbols that represent the uppercase base-16 digits
    /// </summary>
    [SymSource(hex_digits, NBK.Base16)]
    public enum HexUpperSym : ushort
    {
        None = 0,

        /// <summary>
        /// Specifies 0 base 16, asci code 48
        /// </summary>
        [Symbol('0')]
        x0 = '0',

        /// <summary>
        /// Specifies 1 base 16, asci code 49
        /// </summary>
        [Symbol('1')]
        x1 = '1',

        /// <summary>
        /// Specifies 2 base 16, asci code 50
        /// </summary>
        [Symbol('2')]
        x2 = '2',

        /// <summary>
        /// Specifies 3 base 16, asci code 51
        /// </summary>
        [Symbol('3')]
        x3 = '3',

        /// <summary>
        /// Specifies 4 base 16, asci code 52
        /// </summary>
        [Symbol('4')]
        x4 = '4',

        /// <summary>
        /// Specifies 5 base 16
        /// </summary>
        [Symbol('5')]
        x5 = '5',

        /// <summary>
        /// Specifies 6 base 16
        /// </summary>
        [Symbol('6')]
        x6 = '6',

        /// <summary>
        /// Specifies 7 base 16
        /// </summary>
        [Symbol('7')]
        x7 = '7',

        /// <summary>
        /// Specifies 8 base 16
        /// </summary>
        [Symbol('8')]
        x8 = '8',

        /// <summary>
        /// Specifies 9 base 16
        /// </summary>
        [Symbol('9')]
        x9 = '9',

        /// <summary>
        /// Specifies 10 base 16, asci code 65
        /// </summary>
        [Symbol('A')]
        A = 'A',

        /// <summary>
        /// Specifies 11 base 16, asci code 66
        /// </summary>
        [Symbol('B')]
        B = 'B',

        /// <summary>
        /// Specifies 12 base 16, asci code 67
        /// </summary>
        [Symbol('C')]
        C = 'C',

        /// <summary>
        /// Specifies 13 base 16, asci code 68
        /// </summary>
        [Symbol('D')]
        D = 'D',

        /// <summary>
        /// Specifies 14 base 16, asci code 69
        /// </summary>
        [Symbol('E')]
        E = 'E',

        /// <summary>
        /// Specifies 15 base 16, asci code 70
        /// </summary>
        [Symbol('F')]
        F = 'F',
    }
}