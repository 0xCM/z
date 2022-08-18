//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Lo = HexLowerSym;
    using Up = HexUpperSym;

    /// <summary>
    /// Defines the symbols that represent both upper and lower-case base-16 digits
    /// </summary>
    [SymSource(hex_digits, NBK.Base16)]
    public enum HexDigitSym : ushort
    {
        /// <summary>
        /// Specifies 0 base 16, asci code 48
        /// </summary>
        [Symbol("0")]
        x0 = Lo.x0,

        /// <summary>
        /// Specifies 1 base 16, asci code 49
        /// </summary>
        [Symbol("1")]
        x1 = Lo.x1,

        /// <summary>
        /// Specifies 2 base 16, asci code 50
        /// </summary>
        [Symbol("2")]
        x2 = Lo.x2,

        /// <summary>
        /// Specifies 3 base 16, asci code 51
        /// </summary>
        [Symbol("3")]
        x3 = Lo.x3,

        /// <summary>
        /// Specifies 4 base 16, asci code 52
        /// </summary>
        [Symbol("4")]
        x4 = '4',

        /// <summary>
        /// Specifies 5 base 16
        /// </summary>
        [Symbol("5")]
        x5 = '5',

        /// <summary>
        /// Specifies 6 base 16
        /// </summary>
        [Symbol("6")]
        x6 = '6',

        /// <summary>
        /// Specifies 7 base 16
        /// </summary>
        [Symbol("7")]
        x7 = '7',

        /// <summary>
        /// Specifies 8 base 16
        /// </summary>
        [Symbol("8")]
        x8 = '8',

        /// <summary>
        /// Specifies 9 base 16
        /// </summary>
        [Symbol("9")]
        x9 = '9',

        /// <summary>
        /// Specifies 10 base 16, asci code 65
        /// </summary>
        [Symbol("A")]
        A = Up.A,

        /// <summary>
        /// Specifies 11 base 16, asci code 66
        /// </summary>
        [Symbol("B")]
        B = Up.B,

        /// <summary>
        /// Specifies 12 base 16, asci code 67
        /// </summary>
        [Symbol("C")]
        C = Up.C,

        /// <summary>
        /// Specifies 13 base 16, asci code 68
        /// </summary>
        [Symbol("D")]
        D = Up.D,

        /// <summary>
        /// Specifies 14 base 16, asci code 69
        /// </summary>
        [Symbol("E")]
        E = Up.E,

        /// <summary>
        /// Specifies 15 base 16, asci code 70
        /// </summary>
        [Symbol("F")]
        F = Up.F,

        /// <summary>
        /// Specifies 10 base 16, asci code 97
        /// </summary>
        [Symbol("a")]
        a = Lo.a,

        /// <summary>
        /// Specifies 10 base 16, asci code 98
        /// </summary>
        [Symbol("b")]
        b = Lo.b,

        /// <summary>
        /// Specifies 10 base 16, asci code 99
        /// </summary>
        [Symbol("c")]
        c = Lo.c,

        /// <summary>
        /// Specifies 10 base 16, asci code 100
        /// </summary>
        [Symbol("d")]
        d = Lo.d,

        /// <summary>
        /// Specifies 10 base 16, asci code 101
        /// </summary>
        [Symbol("e")]
        e = Lo.e,

        /// <summary>
        /// Specifies 10 base 16, asci code 102
        /// </summary>
        [Symbol("f")]
        f = Lo.f,
    }
}