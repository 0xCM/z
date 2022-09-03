//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = Pow2Scalars;
    using NBK = NumericBaseKind;

    /// <summary>
    /// Defines integers of the form 2^n where n = 0,1
    /// </summary>
    [Flags, SymSource(pow2, NBK.Base16)]
    public enum Pow2x2 : byte
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
    }
}