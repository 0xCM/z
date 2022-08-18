//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines common numeric bases
    /// </summary>
    [SymSource(api_kinds)]
    public enum NumericBaseKind : uint
    {
        None = 0,

        /// <summary>
        /// Identifies base 2, binary
        /// </summary>
        Base2 = 2,

        /// <summary>
        /// Identifies base 3, ternary
        /// </summary>
        Base3 = 3,

        /// <summary>
        /// Identifies base 4, quternary
        /// </summary>
        Base4 = 4,

        /// <summary>
        /// Identifies base 8, octal
        /// </summary>
        Base8 = 8,

        /// <summary>
        /// Identifies base 10, decimal
        /// </summary>
        Base10 = 10,

        /// <summary>
        /// Identifies base 16, hex
        /// </summary>
        Base16 = 16,
    }
}