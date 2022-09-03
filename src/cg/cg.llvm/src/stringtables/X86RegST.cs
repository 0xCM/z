namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum X86RegKind : uint
    {
        AH = 0,
        AL = 1,
        AX = 2,
        BH = 3,
        BL = 4,
        BP = 5,
        BPH = 6,
        BPL = 7,
        BX = 8,
        CH = 9,
        CL = 10,
        CR0 = 11,
        CR1 = 12,
        CR10 = 13,
        CR11 = 14,
        CR12 = 15,
        CR13 = 16,
        CR14 = 17,
        CR15 = 18,
        CR2 = 19,
        CR3 = 20,
        CR4 = 21,
        CR5 = 22,
        CR6 = 23,
        CR7 = 24,
        CR8 = 25,
        CR9 = 26,
        CS = 27,
        CX = 28,
        DF = 29,
        DH = 30,
        DI = 31,
        DIH = 32,
        DIL = 33,
        DL = 34,
        DR0 = 35,
        DR1 = 36,
        DR10 = 37,
        DR11 = 38,
        DR12 = 39,
        DR13 = 40,
        DR14 = 41,
        DR15 = 42,
        DR2 = 43,
        DR3 = 44,
        DR4 = 45,
        DR5 = 46,
        DR6 = 47,
        DR7 = 48,
        DR8 = 49,
        DR9 = 50,
        DS = 51,
        DX = 52,
        EAX = 53,
        EBP = 54,
        EBX = 55,
        ECX = 56,
        EDI = 57,
        EDX = 58,
        EFLAGS = 59,
        EIP = 60,
        EIZ = 61,
        ES = 62,
        ESI = 63,
        ESP = 64,
        FP0 = 65,
        FP1 = 66,
        FP2 = 67,
        FP3 = 68,
        FP4 = 69,
        FP5 = 70,
        FP6 = 71,
        FP7 = 72,
        FPCW = 73,
        FPSW = 74,
        FS = 75,
        GS = 76,
        HAX = 77,
        HBP = 78,
        HBX = 79,
        HCX = 80,
        HDI = 81,
        HDX = 82,
        HIP = 83,
        HSI = 84,
        HSP = 85,
        IP = 86,
        K0 = 87,
        K1 = 88,
        K2 = 89,
        K3 = 90,
        K4 = 91,
        K5 = 92,
        K6 = 93,
        K7 = 94,
        MM0 = 95,
        MM1 = 96,
        MM2 = 97,
        MM3 = 98,
        MM4 = 99,
        MM5 = 100,
        MM6 = 101,
        MM7 = 102,
        MXCSR = 103,
        R10 = 104,
        R10B = 105,
        R10BH = 106,
        R10D = 107,
        R10W = 108,
        R10WH = 109,
        R11 = 110,
        R11B = 111,
        R11BH = 112,
        R11D = 113,
        R11W = 114,
        R11WH = 115,
        R12 = 116,
        R12B = 117,
        R12BH = 118,
        R12D = 119,
        R12W = 120,
        R12WH = 121,
        R13 = 122,
        R13B = 123,
        R13BH = 124,
        R13D = 125,
        R13W = 126,
        R13WH = 127,
        R14 = 128,
        R14B = 129,
        R14BH = 130,
        R14D = 131,
        R14W = 132,
        R14WH = 133,
        R15 = 134,
        R15B = 135,
        R15BH = 136,
        R15D = 137,
        R15W = 138,
        R15WH = 139,
        R8 = 140,
        R8B = 141,
        R8BH = 142,
        R8D = 143,
        R8W = 144,
        R8WH = 145,
        R9 = 146,
        R9B = 147,
        R9BH = 148,
        R9D = 149,
        R9W = 150,
        R9WH = 151,
        RAX = 152,
        RBP = 153,
        RBX = 154,
        RCX = 155,
        RDI = 156,
        RDX = 157,
        RIP = 158,
        RIZ = 159,
        RSI = 160,
        RSP = 161,
        SI = 162,
        SIH = 163,
        SIL = 164,
        SP = 165,
        SPH = 166,
        SPL = 167,
        SS = 168,
        SSP = 169,
        ST0 = 170,
        ST1 = 171,
        ST2 = 172,
        ST3 = 173,
        ST4 = 174,
        ST5 = 175,
        ST6 = 176,
        ST7 = 177,
        TMM0 = 178,
        TMM1 = 179,
        TMM2 = 180,
        TMM3 = 181,
        TMM4 = 182,
        TMM5 = 183,
        TMM6 = 184,
        TMM7 = 185,
        TMMCFG = 186,
        XMM0 = 187,
        XMM1 = 188,
        XMM10 = 189,
        XMM11 = 190,
        XMM12 = 191,
        XMM13 = 192,
        XMM14 = 193,
        XMM15 = 194,
        XMM16 = 195,
        XMM17 = 196,
        XMM18 = 197,
        XMM19 = 198,
        XMM2 = 199,
        XMM20 = 200,
        XMM21 = 201,
        XMM22 = 202,
        XMM23 = 203,
        XMM24 = 204,
        XMM25 = 205,
        XMM26 = 206,
        XMM27 = 207,
        XMM28 = 208,
        XMM29 = 209,
        XMM3 = 210,
        XMM30 = 211,
        XMM31 = 212,
        XMM4 = 213,
        XMM5 = 214,
        XMM6 = 215,
        XMM7 = 216,
        XMM8 = 217,
        XMM9 = 218,
        YMM0 = 219,
        YMM1 = 220,
        YMM10 = 221,
        YMM11 = 222,
        YMM12 = 223,
        YMM13 = 224,
        YMM14 = 225,
        YMM15 = 226,
        YMM16 = 227,
        YMM17 = 228,
        YMM18 = 229,
        YMM19 = 230,
        YMM2 = 231,
        YMM20 = 232,
        YMM21 = 233,
        YMM22 = 234,
        YMM23 = 235,
        YMM24 = 236,
        YMM25 = 237,
        YMM26 = 238,
        YMM27 = 239,
        YMM28 = 240,
        YMM29 = 241,
        YMM3 = 242,
        YMM30 = 243,
        YMM31 = 244,
        YMM4 = 245,
        YMM5 = 246,
        YMM6 = 247,
        YMM7 = 248,
        YMM8 = 249,
        YMM9 = 250,
        ZMM0 = 251,
        ZMM1 = 252,
        ZMM10 = 253,
        ZMM11 = 254,
        ZMM12 = 255,
        ZMM13 = 256,
        ZMM14 = 257,
        ZMM15 = 258,
        ZMM16 = 259,
        ZMM17 = 260,
        ZMM18 = 261,
        ZMM19 = 262,
        ZMM2 = 263,
        ZMM20 = 264,
        ZMM21 = 265,
        ZMM22 = 266,
        ZMM23 = 267,
        ZMM24 = 268,
        ZMM25 = 269,
        ZMM26 = 270,
        ZMM27 = 271,
        ZMM28 = 272,
        ZMM29 = 273,
        ZMM3 = 274,
        ZMM30 = 275,
        ZMM31 = 276,
        ZMM4 = 277,
        ZMM5 = 278,
        ZMM6 = 279,
        ZMM7 = 280,
        ZMM8 = 281,
        ZMM9 = 282,
    }

    [ApiCompleteAttribute]
    public readonly struct X86RegST
    {
        public const uint EntryCount = 283;

        public const uint CharCount = 1053;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<X86RegKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[1132]{0x00,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x06,0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x0a,0x00,0x00,0x00,0x0c,0x00,0x00,0x00,0x0f,0x00,0x00,0x00,0x12,0x00,0x00,0x00,0x14,0x00,0x00,0x00,0x16,0x00,0x00,0x00,0x18,0x00,0x00,0x00,0x1b,0x00,0x00,0x00,0x1e,0x00,0x00,0x00,0x22,0x00,0x00,0x00,0x26,0x00,0x00,0x00,0x2a,0x00,0x00,0x00,0x2e,0x00,0x00,0x00,0x32,0x00,0x00,0x00,0x36,0x00,0x00,0x00,0x39,0x00,0x00,0x00,0x3c,0x00,0x00,0x00,0x3f,0x00,0x00,0x00,0x42,0x00,0x00,0x00,0x45,0x00,0x00,0x00,0x48,0x00,0x00,0x00,0x4b,0x00,0x00,0x00,0x4e,0x00,0x00,0x00,0x50,0x00,0x00,0x00,0x52,0x00,0x00,0x00,0x54,0x00,0x00,0x00,0x56,0x00,0x00,0x00,0x58,0x00,0x00,0x00,0x5b,0x00,0x00,0x00,0x5e,0x00,0x00,0x00,0x60,0x00,0x00,0x00,0x63,0x00,0x00,0x00,0x66,0x00,0x00,0x00,0x6a,0x00,0x00,0x00,0x6e,0x00,0x00,0x00,0x72,0x00,0x00,0x00,0x76,0x00,0x00,0x00,0x7a,0x00,0x00,0x00,0x7e,0x00,0x00,0x00,0x81,0x00,0x00,0x00,0x84,0x00,0x00,0x00,0x87,0x00,0x00,0x00,0x8a,0x00,0x00,0x00,0x8d,0x00,0x00,0x00,0x90,0x00,0x00,0x00,0x93,0x00,0x00,0x00,0x96,0x00,0x00,0x00,0x98,0x00,0x00,0x00,0x9a,0x00,0x00,0x00,0x9d,0x00,0x00,0x00,0xa0,0x00,0x00,0x00,0xa3,0x00,0x00,0x00,0xa6,0x00,0x00,0x00,0xa9,0x00,0x00,0x00,0xac,0x00,0x00,0x00,0xb2,0x00,0x00,0x00,0xb5,0x00,0x00,0x00,0xb8,0x00,0x00,0x00,0xba,0x00,0x00,0x00,0xbd,0x00,0x00,0x00,0xc0,0x00,0x00,0x00,0xc3,0x00,0x00,0x00,0xc6,0x00,0x00,0x00,0xc9,0x00,0x00,0x00,0xcc,0x00,0x00,0x00,0xcf,0x00,0x00,0x00,0xd2,0x00,0x00,0x00,0xd5,0x00,0x00,0x00,0xd8,0x00,0x00,0x00,0xdc,0x00,0x00,0x00,0xe0,0x00,0x00,0x00,0xe2,0x00,0x00,0x00,0xe4,0x00,0x00,0x00,0xe7,0x00,0x00,0x00,0xea,0x00,0x00,0x00,0xed,0x00,0x00,0x00,0xf0,0x00,0x00,0x00,0xf3,0x00,0x00,0x00,0xf6,0x00,0x00,0x00,0xf9,0x00,0x00,0x00,0xfc,0x00,0x00,0x00,0xff,0x00,0x00,0x00,0x01,0x01,0x00,0x00,0x03,0x01,0x00,0x00,0x05,0x01,0x00,0x00,0x07,0x01,0x00,0x00,0x09,0x01,0x00,0x00,0x0b,0x01,0x00,0x00,0x0d,0x01,0x00,0x00,0x0f,0x01,0x00,0x00,0x11,0x01,0x00,0x00,0x14,0x01,0x00,0x00,0x17,0x01,0x00,0x00,0x1a,0x01,0x00,0x00,0x1d,0x01,0x00,0x00,0x20,0x01,0x00,0x00,0x23,0x01,0x00,0x00,0x26,0x01,0x00,0x00,0x29,0x01,0x00,0x00,0x2e,0x01,0x00,0x00,0x31,0x01,0x00,0x00,0x35,0x01,0x00,0x00,0x3a,0x01,0x00,0x00,0x3e,0x01,0x00,0x00,0x42,0x01,0x00,0x00,0x47,0x01,0x00,0x00,0x4a,0x01,0x00,0x00,0x4e,0x01,0x00,0x00,0x53,0x01,0x00,0x00,0x57,0x01,0x00,0x00,0x5b,0x01,0x00,0x00,0x60,0x01,0x00,0x00,0x63,0x01,0x00,0x00,0x67,0x01,0x00,0x00,0x6c,0x01,0x00,0x00,0x70,0x01,0x00,0x00,0x74,0x01,0x00,0x00,0x79,0x01,0x00,0x00,0x7c,0x01,0x00,0x00,0x80,0x01,0x00,0x00,0x85,0x01,0x00,0x00,0x89,0x01,0x00,0x00,0x8d,0x01,0x00,0x00,0x92,0x01,0x00,0x00,0x95,0x01,0x00,0x00,0x99,0x01,0x00,0x00,0x9e,0x01,0x00,0x00,0xa2,0x01,0x00,0x00,0xa6,0x01,0x00,0x00,0xab,0x01,0x00,0x00,0xae,0x01,0x00,0x00,0xb2,0x01,0x00,0x00,0xb7,0x01,0x00,0x00,0xbb,0x01,0x00,0x00,0xbf,0x01,0x00,0x00,0xc4,0x01,0x00,0x00,0xc6,0x01,0x00,0x00,0xc9,0x01,0x00,0x00,0xcd,0x01,0x00,0x00,0xd0,0x01,0x00,0x00,0xd3,0x01,0x00,0x00,0xd7,0x01,0x00,0x00,0xd9,0x01,0x00,0x00,0xdc,0x01,0x00,0x00,0xe0,0x01,0x00,0x00,0xe3,0x01,0x00,0x00,0xe6,0x01,0x00,0x00,0xea,0x01,0x00,0x00,0xed,0x01,0x00,0x00,0xf0,0x01,0x00,0x00,0xf3,0x01,0x00,0x00,0xf6,0x01,0x00,0x00,0xf9,0x01,0x00,0x00,0xfc,0x01,0x00,0x00,0xff,0x01,0x00,0x00,0x02,0x02,0x00,0x00,0x05,0x02,0x00,0x00,0x08,0x02,0x00,0x00,0x0a,0x02,0x00,0x00,0x0d,0x02,0x00,0x00,0x10,0x02,0x00,0x00,0x12,0x02,0x00,0x00,0x15,0x02,0x00,0x00,0x18,0x02,0x00,0x00,0x1a,0x02,0x00,0x00,0x1d,0x02,0x00,0x00,0x20,0x02,0x00,0x00,0x23,0x02,0x00,0x00,0x26,0x02,0x00,0x00,0x29,0x02,0x00,0x00,0x2c,0x02,0x00,0x00,0x2f,0x02,0x00,0x00,0x32,0x02,0x00,0x00,0x35,0x02,0x00,0x00,0x39,0x02,0x00,0x00,0x3d,0x02,0x00,0x00,0x41,0x02,0x00,0x00,0x45,0x02,0x00,0x00,0x49,0x02,0x00,0x00,0x4d,0x02,0x00,0x00,0x51,0x02,0x00,0x00,0x55,0x02,0x00,0x00,0x5b,0x02,0x00,0x00,0x5f,0x02,0x00,0x00,0x63,0x02,0x00,0x00,0x68,0x02,0x00,0x00,0x6d,0x02,0x00,0x00,0x72,0x02,0x00,0x00,0x77,0x02,0x00,0x00,0x7c,0x02,0x00,0x00,0x81,0x02,0x00,0x00,0x86,0x02,0x00,0x00,0x8b,0x02,0x00,0x00,0x90,0x02,0x00,0x00,0x95,0x02,0x00,0x00,0x99,0x02,0x00,0x00,0x9e,0x02,0x00,0x00,0xa3,0x02,0x00,0x00,0xa8,0x02,0x00,0x00,0xad,0x02,0x00,0x00,0xb2,0x02,0x00,0x00,0xb7,0x02,0x00,0x00,0xbc,0x02,0x00,0x00,0xc1,0x02,0x00,0x00,0xc6,0x02,0x00,0x00,0xcb,0x02,0x00,0x00,0xcf,0x02,0x00,0x00,0xd4,0x02,0x00,0x00,0xd9,0x02,0x00,0x00,0xdd,0x02,0x00,0x00,0xe1,0x02,0x00,0x00,0xe5,0x02,0x00,0x00,0xe9,0x02,0x00,0x00,0xed,0x02,0x00,0x00,0xf1,0x02,0x00,0x00,0xf5,0x02,0x00,0x00,0xf9,0x02,0x00,0x00,0xfe,0x02,0x00,0x00,0x03,0x03,0x00,0x00,0x08,0x03,0x00,0x00,0x0d,0x03,0x00,0x00,0x12,0x03,0x00,0x00,0x17,0x03,0x00,0x00,0x1c,0x03,0x00,0x00,0x21,0x03,0x00,0x00,0x26,0x03,0x00,0x00,0x2b,0x03,0x00,0x00,0x2f,0x03,0x00,0x00,0x34,0x03,0x00,0x00,0x39,0x03,0x00,0x00,0x3e,0x03,0x00,0x00,0x43,0x03,0x00,0x00,0x48,0x03,0x00,0x00,0x4d,0x03,0x00,0x00,0x52,0x03,0x00,0x00,0x57,0x03,0x00,0x00,0x5c,0x03,0x00,0x00,0x61,0x03,0x00,0x00,0x65,0x03,0x00,0x00,0x6a,0x03,0x00,0x00,0x6f,0x03,0x00,0x00,0x73,0x03,0x00,0x00,0x77,0x03,0x00,0x00,0x7b,0x03,0x00,0x00,0x7f,0x03,0x00,0x00,0x83,0x03,0x00,0x00,0x87,0x03,0x00,0x00,0x8b,0x03,0x00,0x00,0x8f,0x03,0x00,0x00,0x94,0x03,0x00,0x00,0x99,0x03,0x00,0x00,0x9e,0x03,0x00,0x00,0xa3,0x03,0x00,0x00,0xa8,0x03,0x00,0x00,0xad,0x03,0x00,0x00,0xb2,0x03,0x00,0x00,0xb7,0x03,0x00,0x00,0xbc,0x03,0x00,0x00,0xc1,0x03,0x00,0x00,0xc5,0x03,0x00,0x00,0xca,0x03,0x00,0x00,0xcf,0x03,0x00,0x00,0xd4,0x03,0x00,0x00,0xd9,0x03,0x00,0x00,0xde,0x03,0x00,0x00,0xe3,0x03,0x00,0x00,0xe8,0x03,0x00,0x00,0xed,0x03,0x00,0x00,0xf2,0x03,0x00,0x00,0xf7,0x03,0x00,0x00,0xfb,0x03,0x00,0x00,0x00,0x04,0x00,0x00,0x05,0x04,0x00,0x00,0x09,0x04,0x00,0x00,0x0d,0x04,0x00,0x00,0x11,0x04,0x00,0x00,0x15,0x04,0x00,0x00,0x19,0x04,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[1053]{'A','H','A','L','A','X','B','H','B','L','B','P','B','P','H','B','P','L','B','X','C','H','C','L','C','R','0','C','R','1','C','R','1','0','C','R','1','1','C','R','1','2','C','R','1','3','C','R','1','4','C','R','1','5','C','R','2','C','R','3','C','R','4','C','R','5','C','R','6','C','R','7','C','R','8','C','R','9','C','S','C','X','D','F','D','H','D','I','D','I','H','D','I','L','D','L','D','R','0','D','R','1','D','R','1','0','D','R','1','1','D','R','1','2','D','R','1','3','D','R','1','4','D','R','1','5','D','R','2','D','R','3','D','R','4','D','R','5','D','R','6','D','R','7','D','R','8','D','R','9','D','S','D','X','E','A','X','E','B','P','E','B','X','E','C','X','E','D','I','E','D','X','E','F','L','A','G','S','E','I','P','E','I','Z','E','S','E','S','I','E','S','P','F','P','0','F','P','1','F','P','2','F','P','3','F','P','4','F','P','5','F','P','6','F','P','7','F','P','C','W','F','P','S','W','F','S','G','S','H','A','X','H','B','P','H','B','X','H','C','X','H','D','I','H','D','X','H','I','P','H','S','I','H','S','P','I','P','K','0','K','1','K','2','K','3','K','4','K','5','K','6','K','7','M','M','0','M','M','1','M','M','2','M','M','3','M','M','4','M','M','5','M','M','6','M','M','7','M','X','C','S','R','R','1','0','R','1','0','B','R','1','0','B','H','R','1','0','D','R','1','0','W','R','1','0','W','H','R','1','1','R','1','1','B','R','1','1','B','H','R','1','1','D','R','1','1','W','R','1','1','W','H','R','1','2','R','1','2','B','R','1','2','B','H','R','1','2','D','R','1','2','W','R','1','2','W','H','R','1','3','R','1','3','B','R','1','3','B','H','R','1','3','D','R','1','3','W','R','1','3','W','H','R','1','4','R','1','4','B','R','1','4','B','H','R','1','4','D','R','1','4','W','R','1','4','W','H','R','1','5','R','1','5','B','R','1','5','B','H','R','1','5','D','R','1','5','W','R','1','5','W','H','R','8','R','8','B','R','8','B','H','R','8','D','R','8','W','R','8','W','H','R','9','R','9','B','R','9','B','H','R','9','D','R','9','W','R','9','W','H','R','A','X','R','B','P','R','B','X','R','C','X','R','D','I','R','D','X','R','I','P','R','I','Z','R','S','I','R','S','P','S','I','S','I','H','S','I','L','S','P','S','P','H','S','P','L','S','S','S','S','P','S','T','0','S','T','1','S','T','2','S','T','3','S','T','4','S','T','5','S','T','6','S','T','7','T','M','M','0','T','M','M','1','T','M','M','2','T','M','M','3','T','M','M','4','T','M','M','5','T','M','M','6','T','M','M','7','T','M','M','C','F','G','X','M','M','0','X','M','M','1','X','M','M','1','0','X','M','M','1','1','X','M','M','1','2','X','M','M','1','3','X','M','M','1','4','X','M','M','1','5','X','M','M','1','6','X','M','M','1','7','X','M','M','1','8','X','M','M','1','9','X','M','M','2','X','M','M','2','0','X','M','M','2','1','X','M','M','2','2','X','M','M','2','3','X','M','M','2','4','X','M','M','2','5','X','M','M','2','6','X','M','M','2','7','X','M','M','2','8','X','M','M','2','9','X','M','M','3','X','M','M','3','0','X','M','M','3','1','X','M','M','4','X','M','M','5','X','M','M','6','X','M','M','7','X','M','M','8','X','M','M','9','Y','M','M','0','Y','M','M','1','Y','M','M','1','0','Y','M','M','1','1','Y','M','M','1','2','Y','M','M','1','3','Y','M','M','1','4','Y','M','M','1','5','Y','M','M','1','6','Y','M','M','1','7','Y','M','M','1','8','Y','M','M','1','9','Y','M','M','2','Y','M','M','2','0','Y','M','M','2','1','Y','M','M','2','2','Y','M','M','2','3','Y','M','M','2','4','Y','M','M','2','5','Y','M','M','2','6','Y','M','M','2','7','Y','M','M','2','8','Y','M','M','2','9','Y','M','M','3','Y','M','M','3','0','Y','M','M','3','1','Y','M','M','4','Y','M','M','5','Y','M','M','6','Y','M','M','7','Y','M','M','8','Y','M','M','9','Z','M','M','0','Z','M','M','1','Z','M','M','1','0','Z','M','M','1','1','Z','M','M','1','2','Z','M','M','1','3','Z','M','M','1','4','Z','M','M','1','5','Z','M','M','1','6','Z','M','M','1','7','Z','M','M','1','8','Z','M','M','1','9','Z','M','M','2','Z','M','M','2','0','Z','M','M','2','1','Z','M','M','2','2','Z','M','M','2','3','Z','M','M','2','4','Z','M','M','2','5','Z','M','M','2','6','Z','M','M','2','7','Z','M','M','2','8','Z','M','M','2','9','Z','M','M','3','Z','M','M','3','0','Z','M','M','3','1','Z','M','M','4','Z','M','M','5','Z','M','M','6','Z','M','M','7','Z','M','M','8','Z','M','M','9',};
    }
}