//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = Pow2Scalars;

    /// <summary>
    /// Defines 1
    /// </summary>
    [SymSource(pow2, NBK.Base16), Flags]
    public enum Pow2x1 : byte
    {
        /// <summary>
        /// 2^0 = 1
        /// </summary>
        [Symbol("2^0")]
        P2ᐞ00 = K.T00,
    }
}