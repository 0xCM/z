namespace Z0
{
    using S = Pow2Scalars;

    /// <summary>
    /// Defines primal-representable powers of 2 and integers of the form 2^n - 1 where n = 0,..,64
    /// </summary>
    [SymSource(pow2, NBK.Base16), Flags]
    public enum Pow2x64 : ulong
    {
        /// <summary>
        /// 2^0 = 1
        /// </summary>
        [Symbol("2^0")]
        P2ᐞ00 = S.T00,

        /// <summary>
        /// 2^1 = 2
        /// </summary>
        [Symbol("2^1")]
        P2ᐞ01 = S.T01,

        /// <summary>
        /// 2^2 = 4
        /// </summary>
        [Symbol("2^2")]
        P2ᐞ02 = S.T02,

        /// <summary>
        /// 2^3 = 8
        /// </summary>
        [Symbol("2^3")]
        P2ᐞ03 = S.T03,

        /// <summary>
        /// 2^4 = 16
        /// </summary>
        [Symbol("2^4")]
        P2ᐞ04 = S.T04,

        /// <summary>
        /// 2^5 = 32
        /// </summary>
        [Symbol("2^5")]
        P2ᐞ05 = S.T05,

        /// <summary>
        /// 2^6 = 64
        /// </summary>
        [Symbol("2^6")]
        P2ᐞ06 = S.T06,

        /// <summary>
        /// 2^7 = 128
        /// </summary>
        [Symbol("2^7")]
        P2ᐞ07 = S.T07,

        /// <summary>
        /// 2^8 = 256
        /// </summary>
        [Symbol("2^8")]
        P2ᐞ08 = S.T08,

        /// <summary>
        /// 2^9 = 512
        /// </summary>
        [Symbol("2^9")]
        P2ᐞ09 = S.T09,

        /// <summary>
        /// 2^10 = 1,024
        /// </summary>
        [Symbol("2^10")]
        P2ᐞ10 = S.T10,

        /// <summary>
        /// 2^11 = 2,048
        /// </summary>
        [Symbol("2^11")]
        P2ᐞ11 = S.T11,

        /// <summary>
        /// 2^12 = 4,096
        /// </summary>
        [Symbol("2^12")]
        P2ᐞ12 = S.T12,

        /// <summary>
        /// 2^13 = 8,192
        /// </summary>
        [Symbol("2^13")]
        P2ᐞ13 = S.T13,

        /// <summary>
        /// 2^14 = 16,384
        /// </summary>
        [Symbol("2^14")]
        P2ᐞ14 = S.T14,

        /// <summary>
        /// 2^15 = 32,768
        /// </summary>
        [Symbol("2^15")]
        P2ᐞ15 = S.T15,

        /// <summary>
        /// 2^16 = 65,536
        /// </summary>
        [Symbol("2^16")]
        P2ᐞ16 = S.T16,

        /// <summary>
        /// 2^17 = 131,072
        /// </summary>
        [Symbol("2^17")]
        P2ᐞ17 = S.T17,

        /// <summary>
        /// 2^18 = 262,144
        /// </summary>
        [Symbol("2^18")]
        P2ᐞ18 = S.T18,

        /// <summary>
        /// 2^19 = 524,288
        /// </summary>
        [Symbol("2^19")]
        P2ᐞ19 = S.T19,

        /// <summary>
        /// 2^20 = 1,048,576
        /// </summary>
        [Symbol("2^20")]
        P2ᐞ20 = S.T20,

        /// <summary>
        /// 2^21 = 2,097,152
        /// </summary>
        [Symbol("2^21")]
        P2ᐞ21 = S.T21,

        /// <summary>
        /// 2^22 = 4,194,304
        /// </summary>
        [Symbol("2^22")]
        P2ᐞ22 = S.T22,

        /// <summary>
        /// 2^23 = 8,388,608
        /// </summary>
        [Symbol("2^23")]
        P2ᐞ23 = S.T23,

        /// <summary>
        /// 2^24 = 16,777,216
        /// </summary>
        [Symbol("2^24")]
        P2ᐞ24 = S.T24,

        /// <summary>
        /// 2^25 = 33,554,432
        /// </summary>
        [Symbol("2^25")]
        P2ᐞ25 = S.T25,

        /// <summary>
        /// 2^26 = 67,108,864 = 0x4000000
        /// </summary>
        [Symbol("2^26")]
        P2ᐞ26 = S.T26,

        /// <summary>
        /// 2^27 = 134,217,728 = 0x8000000
        /// </summary>
        [Symbol("2^27")]
        P2ᐞ27 = S.T27,

        /// <summary>
        /// 2^28 = 268,435,456 = 0x10000000
        /// </summary>
        [Symbol("2^28")]
        P2ᐞ28 = S.T28,

        /// <summary>
        /// 2^29 = 536,870,912 = 0x20000000,
        /// </summary>
        [Symbol("2^29")]
        P2ᐞ29 = S.T29,

        /// <summary>
        /// 2^30 = 1,073,741,824 = 0x40000000
        /// </summary>
        [Symbol("2^30")]
        P2ᐞ30 = S.T30,

        /// <summary>
        /// 2^31 = 2,147,483,648 = 0x80000000
        /// </summary>
        [Symbol("2^31")]
        P2ᐞ31 = S.T31,

        /// <summary>
        /// 2^32 = 4,294,967,296 = 0x100000000
        /// </summary>
        [Symbol("2^32")]
        P2ᐞ32 = 2*(long)P2ᐞ31,

        /// <summary>
        /// 2^33
        /// </summary>
        [Symbol("2^33")]
        P2ᐞ33 = 2*P2ᐞ32,

        /// <summary>
        /// 2^34
        /// </summary>
        [Symbol("2^34")]
        P2ᐞ34 = 2*P2ᐞ33,

        /// <summary>
        /// 2^35
        /// </summary>
        [Symbol("2^35")]
        P2ᐞ35 = 2*P2ᐞ34,

        /// <summary>
        /// 2^36
        /// </summary>
        [Symbol("2^36")]
        P2ᐞ36 = 2*P2ᐞ35,

        /// <summary>
        /// 2^37
        /// </summary>
        [Symbol("2^37")]
        P2ᐞ37 = 2*P2ᐞ36,

        /// <summary>
        /// 2^38
        /// </summary>
        [Symbol("2^38")]
        P2ᐞ38 = 2*P2ᐞ37,

        /// <summary>
        /// 2^39
        /// </summary>
        P2ᐞ39 = 2*P2ᐞ38,

        /// <summary>
        /// 2^40
        /// </summary>
        P2ᐞ40 = 2*P2ᐞ39,

        /// <summary>
        /// 2^41
        /// </summary>
        P2ᐞ41 = 2*P2ᐞ40,

        /// <summary>
        /// 2^42
        /// </summary>
        P2ᐞ42 = 2*P2ᐞ41,

        /// <summary>
        /// 2^43
        /// </summary>
        P2ᐞ43 = 2*P2ᐞ42,

        /// <summary>
        /// 2^44
        /// </summary>
        P2ᐞ44 = 2*P2ᐞ43,

        /// <summary>
        /// 2^45
        /// </summary>
        P2ᐞ45 = 2*P2ᐞ44,

        /// <summary>
        /// 2^46
        /// </summary>
        P2ᐞ46 = 2*P2ᐞ45,

        /// <summary>
        /// 2^47
        /// </summary>
        P2ᐞ47 = 2*P2ᐞ46,

        /// <summary>
        /// 2^48
        /// </summary>
        P2ᐞ48 = 2*P2ᐞ47,

        /// <summary>
        /// 2^49
        /// </summary>
        P2ᐞ49 = 2*P2ᐞ48,

        /// <summary>
        /// 2^50
        /// </summary>
        P2ᐞ50 = 2*P2ᐞ49,

        /// <summary>
        /// 2^51
        /// </summary>
        P2ᐞ51 = 2*P2ᐞ50,

        /// <summary>
        /// 2^52
        /// </summary>
        P2ᐞ52 = 2*P2ᐞ51,

        /// <summary>
        /// 2^53
        /// </summary>
        P2ᐞ53 = 2*P2ᐞ52,

        /// <summary>
        /// 2^54
        /// </summary>
        P2ᐞ54 = 2*P2ᐞ53,

        P2ᐞ55 = 2*P2ᐞ54,

        P2ᐞ56 = 2*P2ᐞ55,

        P2ᐞ57 = 2*P2ᐞ56,

        P2ᐞ58 = 2*P2ᐞ57,

        P2ᐞ59 = 2*P2ᐞ58,

        P2ᐞ60 = 2*P2ᐞ59,

        P2ᐞ61 = 2*P2ᐞ60,

        P2ᐞ62 = 2*P2ᐞ61,

        /// <summary>
        /// T63 = 9223372036854775808
        /// </summary>
        P2ᐞ63 = 2*(ulong)P2ᐞ62,
    }
}