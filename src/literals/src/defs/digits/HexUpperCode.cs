//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = HexUpperSym;

    /// <summary>
    /// Defines identifiers for the ASCI codes that correspond to the uppercase hex digits
    /// </summary>
    [SymSource(hex_digits, NBK.Base16)]
    public enum HexUpperCode : byte
    {
        /// <summary>
        /// The code with no name
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x0 = (byte)S.x0,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x1 = (byte)S.x1,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x2 = (byte)S.x2,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x3 = (byte)S.x3,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x4 = (byte)S.x4,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x5 = (byte)S.x5,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x6 = (byte)S.x6,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x7 = (byte)S.x7,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x8 = (byte)S.x8,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x9 = (byte)S.x9,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        A = (byte)S.A,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        B = (byte)S.B,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        C = (byte)S.C,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        D = (byte)S.D,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        E = (byte)S.E,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        F = (byte)S.F,
    }
}