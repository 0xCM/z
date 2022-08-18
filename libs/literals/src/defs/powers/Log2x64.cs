//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using P = Pow2x64;

    /// <summary>
    /// Defines log2 literals for each pow^2 defined by <see cref ='P'/> and requires 6 bits of storage
    /// </summary>
    [SymSource(pow2, NBK.Base16)]
    public enum Log2x64 : byte
    {
        /// <summary>
        /// log2(<see cref='P.P2ᐞ01'/>) = log2(1) = 0
        /// </summary>
        L0 = 0,

        /// <summary>
        /// log2(<see cref='P.P2ᐞ01'/>) = log2(2) = 1
        /// </summary>
        L1 = 1,

        /// <summary>
        /// log2(<see cref='P.P2ᐞ02'/>) = log2(4) = 2
        /// </summary>
        L2 = 2,

        /// <summary>
        /// log2(<see cref='P.P2ᐞ03'/>) = log2(8) = 3
        /// </summary>
        L3 = 3,

        /// <summary>
        /// log2(<see cref='P.P2ᐞ04'/>) = log2(16) = 4
        /// </summary>
        L4 = 4,

        /// <summary>
        /// log2(<see cref='P.P2ᐞ05'/>) = log2(32) = 5
        /// </summary>
        L5 = 5,

        /// <summary>
        /// log2(<see cref='P.P2ᐞ06'/>) = log2(64) = 6
        /// </summary>
        L6 = 6,

        /// <summary>
        /// log2(<see cref='P.P2ᐞ07'/>) = log2(128) = 8
        /// </summary>
        L7 = 7,

        /// <summary>
        /// log2(<see cref='P.P2ᐞ08'/>) = log2(256) = 8
        /// </summary>
        L8 = 8,

        /// <summary>
        /// log2(<see cref='P.P2ᐞ9'/>) = log2(512) = 9
        /// </summary>
        L9 = 9,

        /// <summary>
        /// log2(<see cref='P.P2ᐞ10'/>) = log2(1024) = 10
        /// </summary>
        L10 = 10,

        /// <summary>
        /// log2(<see cref='P.P2ᐞ11'/>) = log2(2048) = 11
        /// </summary>
        L11 = 11,

        /// <summary>
        /// log2(<see cref='P.P2ᐞ12'/>) = log2(4096) = 12
        /// </summary>
        L12 = 12,

        /// <summary>
        /// log2(<see cref='P.P2ᐞ13'/>) = log2(8192) = 13
        /// </summary>
        L13 = 13,

        /// <summary>
        /// log2(<see cref='P.P2ᐞ14'/>) = 14
        /// </summary>
        L14 = 14,

        /// <summary>
        /// log2(<see cref='P.P2ᐞ15'/>) = 15
        /// </summary>
        L15 = 15,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ06'/>
        /// </summary>
        L16 = 16,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ17'/>
        /// </summary>
        L17 = 17,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ18'/>
        /// </summary>
        L18 = 18,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ19'/>
        /// </summary>
        L19 = 19,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ20'/>
        /// </summary>
        L20 = 20,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ21'/>
        /// </summary>
        L21 = 21,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ22'/>
        /// </summary>
        L22 = 22,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ23'/>
        /// </summary>
        L23 = 23,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ24'/>
        /// </summary>
        L24 = 24,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ25'/>
        /// </summary>
        L25 = 25,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ26'/>
        /// </summary>
        L26 = 26,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ27'/>
        /// </summary>
        L27 = 27,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ28'/>
        /// </summary>
        L28 = 28,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ29'/>
        /// </summary>
        L29 = 29,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ30'/>
        /// </summary>
        L30 = 30,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ31'/>
        /// </summary>
        L31 = 31,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ32'/>
        /// </summary>
        L32 = 32,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ33'/>
        /// </summary>
        L33 = 33,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ34'/>
        /// </summary>
        L34 = 34,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ35'/>
        /// </summary>
        L35 = 35,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ36'/>
        /// </summary>
        L36 = 36,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ37'/>
        /// </summary>
        L37 = 37,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ38'/>
        /// </summary>
        L38 = 38,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ39'/>
        /// </summary>
        L39 = 39,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ40'/>
        /// </summary>
        L40 = 40,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ41'/>
        /// </summary>
        L41 = 41,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ42'/>
        /// </summary>
        L42 = 42,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ43'/>
        /// </summary>
        L43 = 43,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ44'/>
        /// </summary>
        L44 = 44,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ45'/>
        /// </summary>
        L45 = 45,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ46'/>
        /// </summary>
        L46 = 46,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ47'/>
        /// </summary>
        L47 = 47,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ48'/>
        /// </summary>
        L48 = 48,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ49'/>
        /// </summary>
        L49 = 49,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ50'/>
        /// </summary>
        L50 = 50,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ51'/>
        /// </summary>
        L51 = 51,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ52'/>
        /// </summary>
        L52 = 52,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ53'/>
        /// </summary>
        L53 = 53,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ54'/>
        /// </summary>
        L54 = 54,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ55'/>
        /// </summary>
        L55 = 55,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ56'/>
        /// </summary>
        L56 = 56,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ57'/>
        /// </summary>
        L57 = 57,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ58'/>
        /// </summary>
        L58 = 58,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ59'/>
        /// </summary>
        L59 = 59,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ60'/>
        /// </summary>
        L60 = 60,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ61'/>
        /// </summary>
        L61 = 61,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ62'/>
        /// </summary>
        L62 = 62,

        /// <summary>
        /// The exponent of <see cref='P.P2ᐞ63'/>
        /// </summary>
        L63 = 63,

    }
}