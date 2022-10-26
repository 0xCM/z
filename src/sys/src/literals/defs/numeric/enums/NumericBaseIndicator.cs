//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines common numeric base indicators that prefix or suffix a numeric literal
    /// to designate the literal's numeric base
    /// </summary>
    [SymSource(numeric)]
    public enum NumericBaseIndicator : ushort
    {
        None = 0,

        /// <summary>
        /// Specifies base 2, binary
        /// </summary>
        [Symbol("b","Specifies base 2, binary")]
        Base2 = 'b',

        /// <summary>
        /// Specifies base 3, ternary
        /// </summary>
        [Symbol("t","Specifies base 3, ternary")]
        Base3 = 't',

        /// <summary>
        /// Specifies base 3, quaternary
        /// </summary>
        [Symbol("q","Specifies base 3, quaternary")]
        Base4 = 'q',

        /// <summary>
        /// Specifies base 8, octal
        /// </summary>
        [Symbol("o","Specifies base 8, octal")]
        Base8 = 'o',

        /// <summary>
        /// Specifies base 10, decimal
        /// </summary>
        [Symbol("d","Specifies base 10, decimal")]
        Base10 = 'd',

        /// <summary>
        /// Specifies base 16, hex
        /// </summary>
        [Symbol("h","Specifies base 16, hex")]
        Base16 = 'h',
    }
}