//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = Pow2Scalars;

    /// <summary>
    /// Defines integers of the form 2^n where n = 0,..,3
    /// </summary>
    [SymSource(pow2, NBK.Base16), Flags]
    public enum Pow2x4 : byte
    {
        /// <summary>
        /// 2^0 = 1
        /// </summary>
        [Symbol("2^0")]
        P2ᐞ00 = K.T00,

        /// <summary>
        /// 2^1 = 2
        /// </summary>
        [Symbol("2^1")]
        P2ᐞ01 = K.T01,

        /// <summary>
        /// 2^2 = 4
        /// </summary>
        [Symbol("2^2")]
        P2ᐞ02 = K.T02,

        /// <summary>
        /// 2^3 = 8
        /// </summary>
        [Symbol("2^3")]
        P2ᐞ03 = K.T03,
    }
}