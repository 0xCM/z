//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Lo = HexLowerSym;
    using Up = HexUpperSym;

    /// <summary>
    /// Defines identifiers for the ASCI codes that correspond to both upper/lower-case hex digits
    /// </summary>
    [SymSource(hex_digits, NBK.Base16)]
    public enum HexDigitCode : byte
    {
        /// <summary>
        /// The hex code with no code
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x0 = (byte)Lo.x0,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x1 = (byte)Lo.x1,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x2 = (byte)Lo.x2,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x3 = (byte)Lo.x3,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x4 = (byte)Lo.x4,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x5 = (byte)Lo.x5,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x6 = (byte)Lo.x6,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x7 = (byte)Lo.x7,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x8 = (byte)Lo.x8,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        x9 = (byte)Lo.x9,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        A = (byte)Up.A,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        B = (byte)Up.B,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        C = (byte)Up.C,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        D = (byte)Up.D,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        E = (byte)Up.E,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        F = (byte)Up.F,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        a = (byte)Lo.a,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        b = (byte)Lo.b,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        c = (byte)Lo.c,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        d = (byte)Lo.d,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        e = (byte)Lo.e,

        /// <summary>
        /// Specifies the asci code for the eponymous hex digit
        /// </summary>
        f = (byte)Lo.f,
    }
}