//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = BinaryDigitSym;

    [SymSource(binary_digits, NBK.Base2)]
    public enum BinaryDigitCode : byte
    {
        /// <summary>
        /// Specifies the asci code for the eponymous binary digit
        /// </summary>
        b0 = (byte)S.b0,

        /// <summary>
        /// Specifies the asci code for the eponymous binary digit
        /// </summary>
        b1 = (byte)S.b1,
   }
}