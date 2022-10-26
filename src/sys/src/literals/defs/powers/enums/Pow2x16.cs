//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = Pow2Scalars;
    using NBK = NumericBaseKind;

    /// <summary>
    /// Defines integers of the form 2^n where n = 0,..,15
    /// </summary>
    [SymSource(pow2, NBK.Base16), Flags]
    public enum Pow2x16 : ushort
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

        /// <summary>
        /// 2^8 = 256
        /// </summary>
        [Symbol("2^8")]
        P2ᐞ08 = K.T08,

        /// <summary>
        /// 2^9 = 512
        /// </summary>
        [Symbol("2^9")]
        P2ᐞ09 = K.T09,

        /// <summary>
        /// 2^10 = 1,024
        /// </summary>
        [Symbol("2^10")]
        P2ᐞ10 = K.T10,

        /// <summary>
        /// 2^11 = 2,048
        /// </summary>
        [Symbol("2^11")]
        P2ᐞ11 = K.T11,

        /// <summary>
        /// 2^12 = 4,096
        /// </summary>
        [Symbol("2^12")]
        P2ᐞ12 = K.T12,

        /// <summary>
        /// 2^13 = 8,192
        /// </summary>
        [Symbol("2^13")]
        P2ᐞ13 = K.T13,

        /// <summary>
        /// 2^14 = 16,384
        /// </summary>
        [Symbol("2^14")]
        P2ᐞ14 = K.T14,

        /// <summary>
        /// 2^15 = 32,768
        /// </summary>
        [Symbol("2^15")]
        P2ᐞ15 = K.T15,
    }
}