//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the symbols that represent base-8 digits
    /// </summary>
    [SymSource(octal_digits, NBK.Base8)]
    public enum OctalDigitSym : ushort
    {
        /// <summary>
        /// Specifies 0 base 8, asci code 48
        /// </summary>
        [Symbol('0')]
        o0 = '0',

        /// <summary>
        /// Specifies 1 base 8, asci code 49
        /// </summary>
        [Symbol('1')]
        o1 = '1',

        /// <summary>
        /// Specifies 2 base 8, asci code 50
        /// </summary>
        [Symbol('2')]
        o2 = '2',

        /// <summary>
        /// Specifies 3 base 8, asci code 51
        /// </summary>
        [Symbol('3')]
        o3 = '3',

        /// <summary>
        /// Specifies 4 base 8, asci code 52
        /// </summary>
        [Symbol('4')]
        o4 = '4',

        /// <summary>
        /// Specifies 5 base 8
        /// </summary>
        [Symbol('5')]
        o5 = '5',

        /// <summary>
        /// Specifies 6 base 8
        /// </summary>
        [Symbol('6')]
        o6 = '6',

        /// <summary>
        /// Specifies 7 base 8
        /// </summary>
        [Symbol('7')]
        o7 = '7',
    }
}