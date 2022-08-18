//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using P = Pow2x8;

    /// <summary>
    /// Defines log2 literals for each pow^2 defined by <see cref ='P'/> and requires 3 bits of storage
    /// </summary>
    [SymSource(pow2, NBK.Base16)]
    public enum Log2x8 : byte
    {
        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ00'/>
        /// </summary>
        L0 = 0,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ01'/>
        /// </summary>
        L1 = 1,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ02'/>
        /// </summary>
        L2 = 2,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ03'/>
        /// </summary>
        L3 = 3,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ04'/>
        /// </summary>
        L4 = 4,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ05'/>
        /// </summary>
        L5 = 5,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ06'/>
        /// </summary>
        L6 = 6,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ07'/>
        /// </summary>
        L7 = 7,
   }
}