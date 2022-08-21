//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using P = Pow2x2;

    /// <summary>
    /// Defines log2 literals for each pow^2 defined by <see cref ='P'/>
    /// </summary>
    [SymSource(pow2, NBK.Base16)]
    public enum Log2x2 : byte
    {
        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ00'/>
        /// </summary>
        L0 = 0,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ01'/>
        /// </summary>
        L1 = 1,
   }
}