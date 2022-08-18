//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines literals corresponding to base-8 digits
    /// </summary>
    [SymSource(octal_digits, NBK.Base8)]
    public enum OctalDigitValue : byte
    {
        /// <summary>
        /// Specifies 0 base 8
        /// </summary>
        o0 = 0x0,

        /// <summary>
        /// Specifies 1 base 8
        /// </summary>
        o1 = 0x1,

        /// <summary>
        /// Specifies 2 base 8
        /// </summary>
        o2 = 0x2,

        /// <summary>
        /// Specifies 3 base 8
        /// </summary>
        o3 = 0x3,

        /// <summary>
        /// Specifies 4 base 8
        /// </summary>
        o4 = 0x4,

        /// <summary>
        /// Specifies 5 base 8
        /// </summary>
        o5 = 0x5,

        /// <summary>
        /// Specifies 6 base 8
        /// </summary>
        o6 = 0x6,

        /// <summary>
        /// Specifies 7 base 8
        /// </summary>
        o7 = 0x7,
   }
}