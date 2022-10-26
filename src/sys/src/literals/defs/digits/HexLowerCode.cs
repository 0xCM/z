//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = HexLowerSym;

    /// <summary>
    /// Defines identiiers for the ASCI codes that correspond to the lowercase hex digits
    /// </summary>
    [SymSource(hex_digits, NBK.Base16)]
    public enum HexLowerCode : byte
    {
        /// <summary>
        /// The hex code with no code
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
        a = (byte)S.a,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        b = (byte)S.b,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        c = (byte)S.c,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        d = (byte)S.d,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        e = (byte)S.e,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        f = (byte)S.f,
    }
}