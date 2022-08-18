//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = Pow2Scalars;

    /// <summary>
    /// Defines integers of the form 2^n where n = 0,..,31
    /// </summary>
    [SymSource(pow2, NBK.Base16), Flags]
    public enum Pow2x32 : uint
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

        /// <summary>
        /// 2^16 = 65,536
        /// </summary>
        [Symbol("2^16")]
        P2ᐞ16 = K.T16,

        /// <summary>
        /// 2^17 = 131,072
        /// </summary>
        [Symbol("2^17")]
        P2ᐞ17 = K.T17,

        /// <summary>
        /// 2^18 = 262,144
        /// </summary>
        [Symbol("2^18")]
        P2ᐞ18 = K.T18,

        /// <summary>
        /// 2^19 = 524,288
        /// </summary>
        [Symbol("2^19")]
        P2ᐞ19 = K.T19,

        /// <summary>
        /// 2^20 = 1,048,576
        /// </summary>
        [Symbol("2^20")]
        P2ᐞ20 = K.T20,

        /// <summary>
        /// 2^21 = 2,097,152
        /// </summary>
        [Symbol("2^21")]
        P2ᐞ21 = K.T21,

        /// <summary>
        /// 2^22 = 4,194,304
        /// </summary>
        [Symbol("2^22")]
        P2ᐞ22 = K.T22,

        /// <summary>
        /// 2^23 = 8,388,608
        /// </summary>
        [Symbol("2^23")]
        P2ᐞ23 = K.T23,

        /// <summary>
        /// 2^24 = 16,777,216
        /// </summary>
        [Symbol("2^24")]
        P2ᐞ24 = K.T24,

        /// <summary>
        /// 2^25 = 33,554,432
        /// </summary>
        [Symbol("2^25")]
        P2ᐞ25 = K.T25,

        /// <summary>
        /// 2^26 = 67,108,864 = 0x4000000
        /// </summary>
        [Symbol("2^26")]
        P2ᐞ26 = K.T26,

        /// <summary>
        /// 2^27 = 134,217,728 = 0x8000000
        /// </summary>
        [Symbol("2^27")]
        P2ᐞ27 = K.T27,

        /// <summary>
        /// 2^28 = 268,435,456 = 0x10000000
        /// </summary>
        [Symbol("2^28")]
        P2ᐞ28 = K.T28,

        /// <summary>
        /// 2^29 = 536,870,912 = 0x20000000,
        /// </summary>
        [Symbol("2^29")]
        P2ᐞ29 = K.T29,

        /// <summary>
        /// 2^30 = 1,073,741,824 = 0x40000000
        /// </summary>
        [Symbol("2^30")]
        P2ᐞ30 = K.T30,

        /// <summary>
        /// 2^31 = 2,147,483,648 = 0x80000000
        /// </summary>
        [Symbol("2^31")]
        P2ᐞ31 = K.T31,
    }
}