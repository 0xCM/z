//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies ternary logic and bitwise operators
    /// </summary>
    [SymSource(api_kinds)]
    public enum TernaryBitLogicKind : byte
    {
        /// <summary>
        /// The empty identity
        /// </summary>
        None = 0,

        X00 = 0x00,

        /// <summary>
        /// nor(a, or(b,c))
        /// </summary>
        X01 = 0x01,

        /// <summary>
        /// and(c, nor(b,a))
        /// </summary>
        X02 = 0x02,

        /// <summary>
        /// nor(b,a)
        /// </summary>
        X03 = 0x03,

        /// <summary>
        /// and(b, nor(a,c))
        /// </summary>
        X04 = 0x04,

        /// <summary>
        /// nor(c,a)
        /// </summary>
        X05 = 0x05,

        /// <summary>
        /// and(not(a), xor(b,c))
        /// </summary>
        X06 = 0x06,

        /// <summary>
        /// nor(a, and(b,c))
        /// </summary>
        X07 = 0x07,

        /// <summary>
        /// and(and(not(a),b), c)
        /// </summary>
        X08 = 0x08,

        /// <summary>
        ///  nor(a, xor(b,c))
        /// </summary>
        X09 = 0x09,

        /// <summary>
        /// and(c, not(a))
        /// </summary>
        X0A = 0x0a,

        /// <summary>
        /// and(not(a), or(not(b),  c))
        /// </summary>
        X0B = 0x0b,

        /// <summary>
        /// and(b, not(a))
        /// </summary>
        X0C = 0x0c,

        /// <summary>
        /// and(not(a), or(b, not(c)))
        /// </summary>
        X0D = 0x0d,

        /// <summary>
        /// and(not(a),or(b,c))
        /// </summary>
        X0E = 0x0e,

        /// <summary>
        /// not(a)
        /// </summary>
        X0F = 0x0f,

        /// <summary>
        /// and(a, nor(b, c))
        /// </summary>
        X10 = 0x10,

        /// <summary>
        /// nor(c,b)
        /// </summary>
        X11 = 0x11,

        /// <summary>
        /// and(not(b), xor(a,c))
        /// </summary>
        X12 = 0x12,

        /// <summary>
        /// nor(b, and(a,c))
        /// </summary>
        X13 = 0x13,

        /// <summary>
        /// and(not(c), xor(a,b))
        /// </summary>
        X14 = 0x14,

        /// <summary>
        ///
        /// </summary>
        X15 = 0x15,

        /// <summary>
        ///
        /// </summary>
        X16 = 0x16,

        /// <summary>
        ///
        /// </summary>
        X17 = 0x17,

        /// <summary>
        /// and(xor(a,b), xor(a,c))
        /// </summary>
        X18 = 0x18,

        /// <summary>
        /// xor(xor(b,c), and(a, and(b,c)))
        /// </summary>
        X19 = 0x19,

        /// <summary>
        /// not(and(and(a,b), xor(a, c)))
        /// </summary>
        X1A = 0x1a,

        /// <summary>
        ///
        /// </summary>
        X1B = 0x1b,

        /// <summary>
        ///
        /// </summary>
        X1C = 0x1c,

        /// <summary>
        ///
        /// </summary>
        X1D = 0x1d,

        /// <summary>
        ///
        /// </summary>
        X1E = 0x1e,

        /// <summary>
        ///
        /// </summary>
        X1F = 0x1f,

        /// <summary>
        ///
        /// </summary>
        X20 = 0x20,

        /// <summary>
        ///
        /// </summary>
        X21 = 0x21,

        /// <summary>
        ///
        /// </summary>
        X22 = 0x22,

        /// <summary>
        ///
        /// </summary>
        X23 = 0x23,

        /// <summary>
        ///
        /// </summary>
        X24 = 0x24,

        /// <summary>
        ///
        /// </summary>
        X25 = 0x25,

        /// <summary>
        /// and(not(and(a,b)), xor(a, not(c)));
        /// </summary>
        X26 = 0x26,

        /// <summary>
        ///
        /// </summary>
        X27 = 0x27,

        /// <summary>
        ///
        /// </summary>
        X28 = 0x28,

        /// <summary>
        /// select(c, xor(b,a), nor(b,a))
        /// </summary>
        X29 = 0x29,

        /// <summary>
        /// and(c, nand(b,a))
        /// </summary>
        X2A = 0x2a,

        /// <summary>
        /// select(c, nand(b,a), nor(b,a))
        /// </summary>
        X2B = 0x2b,

        /// <summary>
        /// and(or(b,c), xor(a,b))
        /// </summary>
        X2C = 0x2c,

        /// <summary>
        ///  xor(a,(or(b,not(c))))
        /// </summary>
        X2D = 0x2d,

        /// <summary>
        ///
        /// </summary>
        X2E = 0x2e,

        /// <summary>
        ///
        /// </summary>
        X2F = 0x2f,

        /// <summary>
        /// cnotimply(a,b)
        /// </summary>
        X30 = 0x30,

        /// <summary>
        /// and(not(b), or(a,not(c)))
        /// </summary>
        X31 = 0x31,

        /// <summary>
        ///
        /// </summary>
        X32 = 0x32,

        /// <summary>
        /// not(b)
        /// </summary>
        X33 = 0x33,

        /// <summary>
        ///
        /// </summary>
        X34 = 0x34,

        /// <summary>
        ///
        /// </summary>
        X35 = 0x35,

        /// <summary>
        ///
        /// </summary>
        X36 = 0x36,

        /// <summary>
        ///
        /// </summary>
        X37 = 0x37,

        /// <summary>
        ///
        /// </summary>
        X38 = 0x38,

        /// <summary>
        ///
        /// </summary>
        X39 = 0x39,

        /// <summary>
        /// select(a, not(b), c)
        /// </summary>
        X3A = 0x3a,

        /// <summary>
        /// or(and(not(a),c),not(b))
        /// </summary>
        X3B = 0x3b,

        /// <summary>
        /// xor(b,a)
        /// </summary>
        X3C = 0x3c,

        /// <summary>
        /// or(xor(b,a),nor(a,c))
        /// </summary>
        X3D = 0x3d,

        /// <summary>
        /// or(and(not(a),c),xor(a,b))
        /// </summary>
        X3E = 0x3e,

        /// <summary>
        /// nand(b,a)
        /// </summary>
        X3F = 0x3f,

        /// <summary>
        ///
        /// </summary>
        X40 = 0x40,

        /// <summary>
        ///
        /// </summary>
        X41 = 0x41,

        /// <summary>
        ///
        /// </summary>
        X42 = 0x42,

        /// <summary>
        /// and(not(and(a,c)), xor(a,not(b)))
        /// </summary>
        X43 = 0x43,

        /// <summary>
        /// cnotimply(b,c)
        /// </summary>
        X44 = 0x44,

        /// <summary>
        ///
        /// </summary>
        X45 = 0x45,

        /// <summary>
        ///
        /// </summary>
        X46 = 0x46,

        /// <summary>
        ///
        /// </summary>
        X47 = 0x47,

        /// <summary>
        /// and(b,xor(a,c))
        /// </summary>
        X48 = 0x48,

        /// <summary>
        /// select(b,xor(a,c),nor(a,c))
        /// </summary>
        X49 = 0x49,

        /// <summary>
        /// and(or(b,c), xor(a,c))
        /// </summary>
        X4A = 0x4a,

        /// <summary>
        /// xor(a, or(not(b), c))
        /// </summary>
        X4B = 0x4b,

        /// <summary>
        /// and(b, nand(a,c))
        /// </summary>
        X4C = 0x4c,

        /// <summary>
        /// select(b, nand(a,c),nor(a,c))
        /// </summary>
        X4D = 0x4d,

        /// <summary>
        /// select(c, not(a), b)
        /// </summary>
        X4E = 0x4e,

        /// <summary>
        /// or(not(a), andnot(b,c))
        /// </summary>
        X4F = 0x4f,

        /// <summary>
        /// cnotimply(a,c)
        /// </summary>
        X50 = 0x50,

        /// <summary>
        /// and(not(c),or(a,not(b)))
        /// </summary>
        X51 = 0x51,

        /// <summary>
        /// and(not(and(b,c)),xor(a,c))
        /// </summary>
        X52 = 0x52,

        /// <summary>
        /// select(a, not(c), not(b))
        /// </summary>
        X53 = 0x53,

        /// <summary>
        /// and(not(c), or(a,b))
        /// </summary>
        X54 = 0x54,

        /// <summary>
        /// not(c)
        /// </summary>
        X55 = 0x55,

        /// <summary>
        /// xor(c,or(b,a))
        /// </summary>
        X56 = 0x56,

        /// <summary>
        /// nand(c,or(b,a))
        /// </summary>
        X57 = 0x57,

        /// <summary>
        /// and(or(a,b),xor(a,c))
        /// </summary>
        X58 = 0x58,

        /// <summary>
        /// xor(c, or(a,xor1(b)))
        /// </summary>
        X59 = 0x59,

        /// <summary>
        /// xor(c,a)
        /// </summary>
        X5A = 0x5a,

        /// <summary>
        /// or(xor(a,c), xor(or(a,b),on))
        /// </summary>
        X5B = 0x5b,

        /// <summary>
        /// select(a,not(c), b)
        /// </summary>
        X5C = 0x5c,

        /// <summary>
        /// or(not(c), and(not(a), b))
        /// </summary>
        X5D = 0x5d,

        /// <summary>
        /// or(and(not(c),b),(xor(a,c)))
        /// </summary>
        X5E = 0x5e,

        /// <summary>
        ///
        /// </summary>
        X5F = 0x5f,

        /// <summary>
        ///
        /// </summary>
        X60 = 0x60,

        /// <summary>
        ///
        /// </summary>
        X61 = 0x61,

        /// <summary>
        ///
        /// </summary>
        X62 = 0x62,

        /// <summary>
        ///
        /// </summary>
        X63 = 0x63,

        /// <summary>
        ///
        /// </summary>
        X64 = 0x64,

        /// <summary>
        ///
        /// </summary>
        X65 = 0x65,

        /// <summary>
        ///
        /// </summary>
        X66 = 0x66,

        /// <summary>
        ///
        /// </summary>
        X67 = 0x67,

        /// <summary>
        ///
        /// </summary>

        /// <summary>
        ///
        /// </summary>
        X68 = 0x68,

        /// <summary>
        ///
        /// </summary>
        X69 = 0x69,

        /// <summary>
        ///
        /// </summary>
        X6A = 0x6a,

        /// <summary>
        ///
        /// </summary>
        X6B = 0x6b,

        /// <summary>
        ///
        /// </summary>
        X6C = 0x6c,

        /// <summary>
        ///
        /// </summary>
        X6D = 0x6d,

        /// <summary>
        ///
        /// </summary>
        X6E = 0x6e,

        /// <summary>
        ///
        /// </summary>
        X6F = 0x6f,

        /// <summary>
        ///
        /// </summary>
        X70 = 0x70,

        /// <summary>
        ///
        /// </summary>
        X71 = 0x71,

        /// <summary>
        ///
        /// </summary>
        X72 = 0x72,

        /// <summary>
        ///
        /// </summary>
        X73 = 0x73,

        /// <summary>
        ///
        /// </summary>
        X74 = 0x74,

        /// <summary>
        ///
        /// </summary>
        X75 = 0x75,

        /// <summary>
        ///
        /// </summary>
        X76 = 0x76,

        /// <summary>
        ///
        /// </summary>
        X77 = 0x77,

        /// <summary>
        ///
        /// </summary>
        X78 = 0x78,

        /// <summary>
        ///
        /// </summary>
        X79 = 0x79,

        /// <summary>
        ///
        /// </summary>
        X7A = 0x7a,

        /// <summary>
        ///
        /// </summary>
        X7B = 0x7b,

        /// <summary>
        ///
        /// </summary>
        X7C = 0x7c,

        /// <summary>
        ///
        /// </summary>
        X7D = 0x7d,

        /// <summary>
        ///
        /// </summary>
        X7E = 0x7e,

        /// <summary>
        ///
        /// </summary>
        X7F = 0x7f,

        /// <summary>
        ///
        /// </summary>
        X80 = 0x80,

        /// <summary>
        ///
        /// </summary>
        X81 = 0x81,

        /// <summary>
        ///
        /// </summary>
        X82 = 0x82,

        /// <summary>
        ///
        /// </summary>
        X83 = 0x83,

        /// <summary>
        ///
        /// </summary>
        X84 = 0x84,

        /// <summary>
        ///
        /// </summary>
        X85 = 0x85,

        /// <summary>
        ///
        /// </summary>
        X86 = 0x86,

        /// <summary>
        ///
        /// </summary>
        X87 = 0x87,

        /// <summary>
        ///
        /// </summary>
        X88 = 0x88,

        /// <summary>
        ///
        /// </summary>
        X89 = 0x89,

        /// <summary>
        ///
        /// </summary>
        X8A = 0x8a,

        /// <summary>
        ///
        /// </summary>
        X8B = 0x8b,

        /// <summary>
        ///
        /// </summary>
        X8C = 0x8c,

        /// <summary>
        ///
        /// </summary>
        X8D = 0x8d,

        /// <summary>
        ///
        /// </summary>
        X8E = 0x8e,

        /// <summary>
        ///
        /// </summary>
        X8F = 0x8f,

        /// <summary>
        ///
        /// </summary>
        X90 = 0x90,

        /// <summary>
        ///
        /// </summary>
        X91 = 0x91,

        /// <summary>
        ///
        /// </summary>
        X92 = 0x92,

        /// <summary>
        ///
        /// </summary>
        X93 = 0x93,

        /// <summary>
        ///
        /// </summary>
        X94 = 0x94,

        /// <summary>
        ///
        /// </summary>
        X95 = 0x95,

        /// <summary>
        ///
        /// </summary>
        X96 = 0x96,

        /// <summary>
        ///
        /// </summary>
        X97 = 0x97,

        /// <summary>
        ///
        /// </summary>
        X98 = 0x98,

        /// <summary>
        ///
        /// </summary>
        X99 = 0x99,

        /// <summary>
        ///
        /// </summary>
        X9A = 0x9a,

        /// <summary>
        ///
        /// </summary>
        X9B = 0x9b,

        /// <summary>
        ///
        /// </summary>
        X9C = 0x9c,

        /// <summary>
        ///
        /// </summary>
        X9D = 0x9d,

        /// <summary>
        ///
        /// </summary>
        X9E = 0x9e,

        /// <summary>
        ///
        /// </summary>
        X9F = 0x9f,

        /// <summary>
        ///
        /// </summary>
        XA0 = 0xa0,

        /// <summary>
        ///
        /// </summary>
        XA1 = 0xa1,

        /// <summary>
        ///
        /// </summary>
        XA2 = 0xa2,

        /// <summary>
        ///
        /// </summary>
        XA3 = 0xa3,

        /// <summary>
        ///
        /// </summary>
        XA4 = 0xa4,

        /// <summary>
        ///
        /// </summary>
        XA5 = 0xa5,

        /// <summary>
        ///
        /// </summary>
        XA6 = 0xa6,

        /// <summary>
        ///
        /// </summary>
        XA7 = 0xa7,

        /// <summary>
        ///
        /// </summary>
        XA8 = 0xa8,

        /// <summary>
        ///
        /// </summary>
        XA9 = 0xa9,


        /// <summary>
        /// third(a,b,c) := c
        /// </summary>
        XAA = 0xaa,

        /// <summary>
        ///
        /// </summary>
        XAB = 0xab,

        /// <summary>
        ///
        /// </summary>
        XAC = 0xac,

        /// <summary>
        ///
        /// </summary>
        XAD = 0xad,

        /// <summary>
        ///
        /// </summary>
        XAE = 0xae,

        /// <summary>
        ///
        /// </summary>
        XAF = 0xaf,

        /// <summary>
        ///
        /// </summary>
        XB0 = 0xb0,

        /// <summary>
        ///
        /// </summary>
        XB1 = 0xb1,

        /// <summary>
        ///
        /// </summary>
        XB2 = 0xb2,

        /// <summary>
        ///
        /// </summary>
        XB3 = 0xb3,

        /// <summary>
        ///
        /// </summary>
        XB4 = 0xb4,

        /// <summary>
        ///
        /// </summary>
        XB5 = 0xb5,

        /// <summary>
        ///
        /// </summary>
        XB6 = 0xb6,

        /// <summary>
        ///
        /// </summary>
        XB7 = 0xb7,

        /// <summary>
        ///
        /// </summary>
        XB8 = 0xb8,

        /// <summary>
        ///
        /// </summary>
        XB9 = 0xb9,

        /// <summary>
        ///
        /// </summary>
        XBA = 0xba,

        /// <summary>
        ///
        /// </summary>
        XBB = 0xbb,

        /// <summary>
        ///
        /// </summary>
        XBC = 0xbc,

        /// <summary>
        ///
        /// </summary>
        XBD = 0xbd,

        /// <summary>
        ///
        /// </summary>
        XBE = 0xbe,

        /// <summary>
        ///
        /// </summary>
        XBF = 0xbf,

        /// <summary>
        ///
        /// </summary>
        XC0 = 0xc0,

        /// <summary>
        ///
        /// </summary>
        XC1 = 0xc1,

        /// <summary>
        ///
        /// </summary>
        XC2 = 0xc2,

        /// <summary>
        ///
        /// </summary>
        XC3 = 0xc3,

        /// <summary>
        ///
        /// </summary>
        XC4 = 0xc4,

        /// <summary>
        ///
        /// </summary>
        XC5 = 0xc5,

        /// <summary>
        ///
        /// </summary>
        XC6 = 0xc6,

        /// <summary>
        ///
        /// </summary>
        XC7 = 0xc7,

        /// <summary>
        ///
        /// </summary>
        XC8 = 0xc8,

        /// <summary>
        ///
        /// </summary>
        XC9 = 0xc9,

        /// <summary>
        /// select(a,b,c)
        /// </summary>
        XCA = 0xca,

        /// <summary>
        /// second(a,b,c) := b
        /// </summary>
        XCB = 0xcb,

        /// <summary>
        ///
        /// </summary>
        XCC = 0xcc,

        /// <summary>
        ///
        /// </summary>
        XCD = 0xcd,

        /// <summary>
        ///
        /// </summary>
        XCE = 0xce,

        /// <summary>
        ///
        /// </summary>
        XCF = 0xcf,

        /// <summary>
        ///
        /// </summary>
        XD0 = 0xd0,

        /// <summary>
        ///
        /// </summary>
        XD1 = 0xd1,

        /// <summary>
        ///
        /// </summary>
        XD2 = 0xd2,

        /// <summary>
        ///
        /// </summary>
        XD3 = 0xd3,

        /// <summary>
        ///
        /// </summary>
        XD4 = 0xd4,

        /// <summary>
        ///
        /// </summary>
        XD5 = 0xd5,

        /// <summary>
        ///
        /// </summary>
        XD6 = 0xd6,

        /// <summary>
        ///
        /// </summary>
        XD7 = 0xd7,

        /// <summary>
        ///
        /// </summary>
        XD8 = 0xd8,

        /// <summary>
        ///
        /// </summary>
        XD9 = 0xd9,

        /// <summary>
        ///
        /// </summary>
        XDA = 0xda,

        /// <summary>
        ///
        /// </summary>
        XDB = 0xdb,

        /// <summary>
        ///
        /// </summary>
        XDC = 0xdc,

        /// <summary>
        ///
        /// </summary>
        XDD = 0xdd,

        /// <summary>
        ///
        /// </summary>
        XDE = 0xde,

        /// <summary>
        ///
        /// </summary>
        XDF = 0xdf,

        /// <summary>
        ///
        /// </summary>
        XE0 = 0xe0,

        /// <summary>
        ///
        /// </summary>
        XE1 = 0xe1,

        /// <summary>
        ///
        /// </summary>
        XE2 = 0xe2,

        /// <summary>
        ///
        /// </summary>
        XE3 = 0xe3,

        /// <summary>
        ///
        /// </summary>
        XE4 = 0xe4,

        /// <summary>
        ///
        /// </summary>
        XE5 = 0xe5,

        /// <summary>
        ///
        /// </summary>
        XE6 = 0xe6,

        /// <summary>
        ///
        /// </summary>
        XE7 = 0xe7,

        /// <summary>
        ///
        /// </summary>
        XE8 = 0xe8,

        /// <summary>
        ///
        /// </summary>
        XE9 = 0xe9,

        /// <summary>
        ///
        /// </summary>
        XEA = 0xea,

        /// <summary>
        ///
        /// </summary>
        XEB = 0xeb,

        /// <summary>
        ///
        /// </summary>
        XEC = 0xec,

        /// <summary>
        ///
        /// </summary>
        XED = 0xed,

        /// <summary>
        ///
        /// </summary>
        XEE = 0xee,

        /// <summary>
        ///
        /// </summary>
        XEF = 0xef,

        /// <summary>
        ///
        /// </summary>
        XF0 = 0xf0,

        /// <summary>
        ///
        /// </summary>
        XF1 = 0xf1,

        /// <summary>
        ///
        /// </summary>
        XF2 = 0xf2,

        /// <summary>
        ///
        /// </summary>
        XF3 = 0xf3,

        /// <summary>
        ///
        /// </summary>
        XF4 = 0xf4,

        /// <summary>
        ///
        /// </summary>
        XF5 = 0xf5,

        /// <summary>
        ///
        /// </summary>
        XF6 = 0xf6,

        /// <summary>
        ///
        /// </summary>
        XF7 = 0xf7,

        /// <summary>
        ///
        /// </summary>
        XF8 = 0xf8,

        /// <summary>
        ///
        /// </summary>
        XF9 = 0xf9,

        /// <summary>
        ///
        /// </summary>
        XFA = 0xfa,

        /// <summary>
        ///
        /// </summary>
        XFB = 0xfb,

        /// <summary>
        ///
        /// </summary>
        XFC = 0xfc,

        /// <summary>
        ///
        /// </summary>
        XFD = 0xfd,

        /// <summary>
        ///
        /// </summary>
        XFE = 0xfe,

        /// <summary>
        ///  Pervasive and invariant truth
        /// </summary>
        XFF = 0xff,
    }
}