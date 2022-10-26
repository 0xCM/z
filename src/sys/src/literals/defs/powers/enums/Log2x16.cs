//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using P = Pow2x16;

    /// <summary>
    /// Defines log2 literals for each pow^2 defined by <see cref ='P'/> and requires 4 bits of storage
    /// </summary>
    [SymSource(pow2, NBK.Base16)]
    public enum Log2x16 : byte
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

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ08'/>
        /// </summary>
        L8 = 8,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ09'/>
        /// </summary>
        L9 = 9,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ10'/>
        /// </summary>
        L10 = 10,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ11'/>
        /// </summary>
        L11 = 11,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ12'/>
        /// </summary>
        L12 = 12,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ13'/>
        /// </summary>
        L13 = 13,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ14'/>
        /// </summary>
        L14 = 14,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ15'/>
        /// </summary>
        L15 = 15,
    }
}