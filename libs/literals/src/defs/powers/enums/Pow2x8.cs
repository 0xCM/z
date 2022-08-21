//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = Pow2Scalars;
    using NBK = NumericBaseKind;

    /// <summary>
    /// Defines integers of the form 2^n where n = 0,..,7
    /// </summary>
    [SymSource(pow2, NBK.Base16), Flags]
    public enum Pow2x8 : byte
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

        /// <summary>
        /// 2^4 = 16
        /// </summary>
        [Symbol("2^4")]
        P2ᐞ04 = K.T04,

        /// <summary>
        /// 2^5 = 32
        /// </summary>
        [Symbol("2^5")]
        P2ᐞ05 = K.T05,

        /// <summary>
        /// 2^6 = 64
        /// </summary>
        [Symbol("2^6")]
        P2ᐞ06 = K.T06,

        /// <summary>
        /// 2^7 = 128
        /// </summary>
        [Symbol("2^7")]
        P2ᐞ07 = K.T07,
    }
}