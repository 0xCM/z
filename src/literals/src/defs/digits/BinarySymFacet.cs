//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BinaryDigitSym;

    /// <summary>
    /// Defines <see cref='BinaryDigitSym' /> classiefiers
    /// </summary>
    [SymSource(binary_digits,NBK.Base2)]
    public enum BinarySymFacet : ushort
    {
        /// <summary>
        /// The first declared symbol
        /// </summary>
        First = b0,

        /// <summary>
        /// The last declared symbol
        /// </summary>
        Last = b1,
    }
}
