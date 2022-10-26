//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static DecimalDigitSym;

    /// <summary>
    /// Defines <see cref='DecimalDigitSym' /> classifiers
    /// </summary>
    [SymSource(digits,NBK.Base10)]
    public enum DecimalSymFacet : ushort
    {
        /// <summary>
        /// The first declared symbol
        /// </summary>
        First = d0,

        /// <summary>
        /// The last declared symbol
        /// </summary>
        Last = d9,
    }
}