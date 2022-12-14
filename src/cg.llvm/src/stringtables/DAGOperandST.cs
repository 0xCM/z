namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum DAGOperandKind : uint
    {
        AVX512RC = 0,
        CCR = 1,
        CONTROL_REG = 2,
        DEBUG_REG = 3,
        DFCCR = 4,
        FPCCR = 5,
        FR16X = 6,
        FR32 = 7,
        FR32X = 8,
        FR64 = 9,
        FR64X = 10,
        GR16 = 11,
        GR16_ABCD = 12,
        GR16_NOREX = 13,
        GR16orGR32orGR64 = 14,
        GR32 = 15,
        GR32_ABCD = 16,
        GR32_AD = 17,
        GR32_BPSP = 18,
        GR32_BSI = 19,
        GR32_CB = 20,
        GR32_DC = 21,
        GR32_DIBP = 22,
        GR32_NOREX = 23,
        GR32_NOREX_NOSP = 24,
        GR32_NOSP = 25,
        GR32_SIDI = 26,
        GR32_TC = 27,
        GR32orGR64 = 28,
        GR64 = 29,
        GR64PLTSafe = 30,
        GR64_ABCD = 31,
        GR64_AD = 32,
        GR64_NOREX = 33,
        GR64_NOREX_NOSP = 34,
        GR64_NOSP = 35,
        GR64_TC = 36,
        GR64_TCW64 = 37,
        GR8 = 38,
        GR8_ABCD_H = 39,
        GR8_ABCD_L = 40,
        GR8_NOREX = 41,
        GRH16 = 42,
        GRH8 = 43,
        LOW32_ADDR_ACCESS = 44,
        LOW32_ADDR_ACCESS_RBP = 45,
        RFP32 = 46,
        RFP64 = 47,
        RFP80 = 48,
        RFP80_7 = 49,
        RST = 50,
        RSTi = 51,
        SEGMENT_REG = 52,
        TILE = 53,
        VK1 = 54,
        VK16 = 55,
        VK16PAIR = 56,
        VK16Pair = 57,
        VK16WM = 58,
        VK1PAIR = 59,
        VK1Pair = 60,
        VK1WM = 61,
        VK2 = 62,
        VK2PAIR = 63,
        VK2Pair = 64,
        VK2WM = 65,
        VK32 = 66,
        VK32WM = 67,
        VK4 = 68,
        VK4PAIR = 69,
        VK4Pair = 70,
        VK4WM = 71,
        VK64 = 72,
        VK64WM = 73,
        VK8 = 74,
        VK8PAIR = 75,
        VK8Pair = 76,
        VK8WM = 77,
        VR128 = 78,
        VR128X = 79,
        VR256 = 80,
        VR256X = 81,
        VR512 = 82,
        VR512_0_15 = 83,
        VR64 = 84,
        anymem = 85,
        brtarget = 86,
        brtarget16 = 87,
        brtarget32 = 88,
        brtarget8 = 89,
        ccode = 90,
        dstidx16 = 91,
        dstidx32 = 92,
        dstidx64 = 93,
        dstidx8 = 94,
        f128mem = 95,
        f16mem = 96,
        f256mem = 97,
        f32imm = 98,
        f32mem = 99,
        f512mem = 100,
        f64imm = 101,
        f64mem = 102,
        f80mem = 103,
        i128mem = 104,
        i16i8imm = 105,
        i16imm = 106,
        i16imm_brtarget = 107,
        i16mem = 108,
        i16u8imm = 109,
        i1imm = 110,
        i256mem = 111,
        i32i8imm = 112,
        i32imm = 113,
        i32imm_brtarget = 114,
        i32mem = 115,
        i32mem_TC = 116,
        i32u8imm = 117,
        i512mem = 118,
        i64i32imm = 119,
        i64i32imm_brtarget = 120,
        i64i8imm = 121,
        i64imm = 122,
        i64mem = 123,
        i64mem_TC = 124,
        i64u8imm = 125,
        i8imm = 126,
        i8mem = 127,
        i8mem_NOREX = 128,
        lea64_32mem = 129,
        lea64mem = 130,
        offset16_16 = 131,
        offset16_32 = 132,
        offset16_8 = 133,
        offset32_16 = 134,
        offset32_32 = 135,
        offset32_64 = 136,
        offset32_8 = 137,
        offset64_16 = 138,
        offset64_32 = 139,
        offset64_64 = 140,
        offset64_8 = 141,
        opaquemem = 142,
        ptype0 = 143,
        ptype1 = 144,
        ptype2 = 145,
        ptype3 = 146,
        ptype4 = 147,
        ptype5 = 148,
        sdmem = 149,
        shmem = 150,
        sibmem = 151,
        srcidx16 = 152,
        srcidx32 = 153,
        srcidx64 = 154,
        srcidx8 = 155,
        ssmem = 156,
        type0 = 157,
        type1 = 158,
        type2 = 159,
        type3 = 160,
        type4 = 161,
        type5 = 162,
        u4imm = 163,
        u8imm = 164,
        untyped_imm_0 = 165,
        vx128mem = 166,
        vx128xmem = 167,
        vx256mem = 168,
        vx256xmem = 169,
        vx64mem = 170,
        vx64xmem = 171,
        vy128mem = 172,
        vy128xmem = 173,
        vy256mem = 174,
        vy256xmem = 175,
        vy512xmem = 176,
        vz256mem = 177,
        vz512mem = 178,
    }

    [ApiCompleteAttribute]
    public readonly struct DAGOperandST
    {
        public const uint EntryCount = 179;

        public const uint CharCount = 1340;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<DAGOperandKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[716]{0x00,0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x0b,0x00,0x00,0x00,0x16,0x00,0x00,0x00,0x1f,0x00,0x00,0x00,0x24,0x00,0x00,0x00,0x29,0x00,0x00,0x00,0x2e,0x00,0x00,0x00,0x32,0x00,0x00,0x00,0x37,0x00,0x00,0x00,0x3b,0x00,0x00,0x00,0x40,0x00,0x00,0x00,0x44,0x00,0x00,0x00,0x4d,0x00,0x00,0x00,0x57,0x00,0x00,0x00,0x67,0x00,0x00,0x00,0x6b,0x00,0x00,0x00,0x74,0x00,0x00,0x00,0x7b,0x00,0x00,0x00,0x84,0x00,0x00,0x00,0x8c,0x00,0x00,0x00,0x93,0x00,0x00,0x00,0x9a,0x00,0x00,0x00,0xa3,0x00,0x00,0x00,0xad,0x00,0x00,0x00,0xbc,0x00,0x00,0x00,0xc5,0x00,0x00,0x00,0xce,0x00,0x00,0x00,0xd5,0x00,0x00,0x00,0xdf,0x00,0x00,0x00,0xe3,0x00,0x00,0x00,0xee,0x00,0x00,0x00,0xf7,0x00,0x00,0x00,0xfe,0x00,0x00,0x00,0x08,0x01,0x00,0x00,0x17,0x01,0x00,0x00,0x20,0x01,0x00,0x00,0x27,0x01,0x00,0x00,0x31,0x01,0x00,0x00,0x34,0x01,0x00,0x00,0x3e,0x01,0x00,0x00,0x48,0x01,0x00,0x00,0x51,0x01,0x00,0x00,0x56,0x01,0x00,0x00,0x5a,0x01,0x00,0x00,0x6b,0x01,0x00,0x00,0x80,0x01,0x00,0x00,0x85,0x01,0x00,0x00,0x8a,0x01,0x00,0x00,0x8f,0x01,0x00,0x00,0x96,0x01,0x00,0x00,0x99,0x01,0x00,0x00,0x9d,0x01,0x00,0x00,0xa8,0x01,0x00,0x00,0xac,0x01,0x00,0x00,0xaf,0x01,0x00,0x00,0xb3,0x01,0x00,0x00,0xbb,0x01,0x00,0x00,0xc3,0x01,0x00,0x00,0xc9,0x01,0x00,0x00,0xd0,0x01,0x00,0x00,0xd7,0x01,0x00,0x00,0xdc,0x01,0x00,0x00,0xdf,0x01,0x00,0x00,0xe6,0x01,0x00,0x00,0xed,0x01,0x00,0x00,0xf2,0x01,0x00,0x00,0xf6,0x01,0x00,0x00,0xfc,0x01,0x00,0x00,0xff,0x01,0x00,0x00,0x06,0x02,0x00,0x00,0x0d,0x02,0x00,0x00,0x12,0x02,0x00,0x00,0x16,0x02,0x00,0x00,0x1c,0x02,0x00,0x00,0x1f,0x02,0x00,0x00,0x26,0x02,0x00,0x00,0x2d,0x02,0x00,0x00,0x32,0x02,0x00,0x00,0x37,0x02,0x00,0x00,0x3d,0x02,0x00,0x00,0x42,0x02,0x00,0x00,0x48,0x02,0x00,0x00,0x4d,0x02,0x00,0x00,0x57,0x02,0x00,0x00,0x5b,0x02,0x00,0x00,0x61,0x02,0x00,0x00,0x69,0x02,0x00,0x00,0x73,0x02,0x00,0x00,0x7d,0x02,0x00,0x00,0x86,0x02,0x00,0x00,0x8b,0x02,0x00,0x00,0x93,0x02,0x00,0x00,0x9b,0x02,0x00,0x00,0xa3,0x02,0x00,0x00,0xaa,0x02,0x00,0x00,0xb1,0x02,0x00,0x00,0xb7,0x02,0x00,0x00,0xbe,0x02,0x00,0x00,0xc4,0x02,0x00,0x00,0xca,0x02,0x00,0x00,0xd1,0x02,0x00,0x00,0xd7,0x02,0x00,0x00,0xdd,0x02,0x00,0x00,0xe3,0x02,0x00,0x00,0xea,0x02,0x00,0x00,0xf2,0x02,0x00,0x00,0xf8,0x02,0x00,0x00,0x07,0x03,0x00,0x00,0x0d,0x03,0x00,0x00,0x15,0x03,0x00,0x00,0x1a,0x03,0x00,0x00,0x21,0x03,0x00,0x00,0x29,0x03,0x00,0x00,0x2f,0x03,0x00,0x00,0x3e,0x03,0x00,0x00,0x44,0x03,0x00,0x00,0x4d,0x03,0x00,0x00,0x55,0x03,0x00,0x00,0x5c,0x03,0x00,0x00,0x65,0x03,0x00,0x00,0x77,0x03,0x00,0x00,0x7f,0x03,0x00,0x00,0x85,0x03,0x00,0x00,0x8b,0x03,0x00,0x00,0x94,0x03,0x00,0x00,0x9c,0x03,0x00,0x00,0xa1,0x03,0x00,0x00,0xa6,0x03,0x00,0x00,0xb1,0x03,0x00,0x00,0xbc,0x03,0x00,0x00,0xc4,0x03,0x00,0x00,0xcf,0x03,0x00,0x00,0xda,0x03,0x00,0x00,0xe4,0x03,0x00,0x00,0xef,0x03,0x00,0x00,0xfa,0x03,0x00,0x00,0x05,0x04,0x00,0x00,0x0f,0x04,0x00,0x00,0x1a,0x04,0x00,0x00,0x25,0x04,0x00,0x00,0x30,0x04,0x00,0x00,0x3a,0x04,0x00,0x00,0x43,0x04,0x00,0x00,0x49,0x04,0x00,0x00,0x4f,0x04,0x00,0x00,0x55,0x04,0x00,0x00,0x5b,0x04,0x00,0x00,0x61,0x04,0x00,0x00,0x67,0x04,0x00,0x00,0x6c,0x04,0x00,0x00,0x71,0x04,0x00,0x00,0x77,0x04,0x00,0x00,0x7f,0x04,0x00,0x00,0x87,0x04,0x00,0x00,0x8f,0x04,0x00,0x00,0x96,0x04,0x00,0x00,0x9b,0x04,0x00,0x00,0xa0,0x04,0x00,0x00,0xa5,0x04,0x00,0x00,0xaa,0x04,0x00,0x00,0xaf,0x04,0x00,0x00,0xb4,0x04,0x00,0x00,0xb9,0x04,0x00,0x00,0xbe,0x04,0x00,0x00,0xc3,0x04,0x00,0x00,0xd0,0x04,0x00,0x00,0xd8,0x04,0x00,0x00,0xe1,0x04,0x00,0x00,0xe9,0x04,0x00,0x00,0xf2,0x04,0x00,0x00,0xf9,0x04,0x00,0x00,0x01,0x05,0x00,0x00,0x09,0x05,0x00,0x00,0x12,0x05,0x00,0x00,0x1a,0x05,0x00,0x00,0x23,0x05,0x00,0x00,0x2c,0x05,0x00,0x00,0x34,0x05,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[1340]{'A','V','X','5','1','2','R','C','C','C','R','C','O','N','T','R','O','L','_','R','E','G','D','E','B','U','G','_','R','E','G','D','F','C','C','R','F','P','C','C','R','F','R','1','6','X','F','R','3','2','F','R','3','2','X','F','R','6','4','F','R','6','4','X','G','R','1','6','G','R','1','6','_','A','B','C','D','G','R','1','6','_','N','O','R','E','X','G','R','1','6','o','r','G','R','3','2','o','r','G','R','6','4','G','R','3','2','G','R','3','2','_','A','B','C','D','G','R','3','2','_','A','D','G','R','3','2','_','B','P','S','P','G','R','3','2','_','B','S','I','G','R','3','2','_','C','B','G','R','3','2','_','D','C','G','R','3','2','_','D','I','B','P','G','R','3','2','_','N','O','R','E','X','G','R','3','2','_','N','O','R','E','X','_','N','O','S','P','G','R','3','2','_','N','O','S','P','G','R','3','2','_','S','I','D','I','G','R','3','2','_','T','C','G','R','3','2','o','r','G','R','6','4','G','R','6','4','G','R','6','4','P','L','T','S','a','f','e','G','R','6','4','_','A','B','C','D','G','R','6','4','_','A','D','G','R','6','4','_','N','O','R','E','X','G','R','6','4','_','N','O','R','E','X','_','N','O','S','P','G','R','6','4','_','N','O','S','P','G','R','6','4','_','T','C','G','R','6','4','_','T','C','W','6','4','G','R','8','G','R','8','_','A','B','C','D','_','H','G','R','8','_','A','B','C','D','_','L','G','R','8','_','N','O','R','E','X','G','R','H','1','6','G','R','H','8','L','O','W','3','2','_','A','D','D','R','_','A','C','C','E','S','S','L','O','W','3','2','_','A','D','D','R','_','A','C','C','E','S','S','_','R','B','P','R','F','P','3','2','R','F','P','6','4','R','F','P','8','0','R','F','P','8','0','_','7','R','S','T','R','S','T','i','S','E','G','M','E','N','T','_','R','E','G','T','I','L','E','V','K','1','V','K','1','6','V','K','1','6','P','A','I','R','V','K','1','6','P','a','i','r','V','K','1','6','W','M','V','K','1','P','A','I','R','V','K','1','P','a','i','r','V','K','1','W','M','V','K','2','V','K','2','P','A','I','R','V','K','2','P','a','i','r','V','K','2','W','M','V','K','3','2','V','K','3','2','W','M','V','K','4','V','K','4','P','A','I','R','V','K','4','P','a','i','r','V','K','4','W','M','V','K','6','4','V','K','6','4','W','M','V','K','8','V','K','8','P','A','I','R','V','K','8','P','a','i','r','V','K','8','W','M','V','R','1','2','8','V','R','1','2','8','X','V','R','2','5','6','V','R','2','5','6','X','V','R','5','1','2','V','R','5','1','2','_','0','_','1','5','V','R','6','4','a','n','y','m','e','m','b','r','t','a','r','g','e','t','b','r','t','a','r','g','e','t','1','6','b','r','t','a','r','g','e','t','3','2','b','r','t','a','r','g','e','t','8','c','c','o','d','e','d','s','t','i','d','x','1','6','d','s','t','i','d','x','3','2','d','s','t','i','d','x','6','4','d','s','t','i','d','x','8','f','1','2','8','m','e','m','f','1','6','m','e','m','f','2','5','6','m','e','m','f','3','2','i','m','m','f','3','2','m','e','m','f','5','1','2','m','e','m','f','6','4','i','m','m','f','6','4','m','e','m','f','8','0','m','e','m','i','1','2','8','m','e','m','i','1','6','i','8','i','m','m','i','1','6','i','m','m','i','1','6','i','m','m','_','b','r','t','a','r','g','e','t','i','1','6','m','e','m','i','1','6','u','8','i','m','m','i','1','i','m','m','i','2','5','6','m','e','m','i','3','2','i','8','i','m','m','i','3','2','i','m','m','i','3','2','i','m','m','_','b','r','t','a','r','g','e','t','i','3','2','m','e','m','i','3','2','m','e','m','_','T','C','i','3','2','u','8','i','m','m','i','5','1','2','m','e','m','i','6','4','i','3','2','i','m','m','i','6','4','i','3','2','i','m','m','_','b','r','t','a','r','g','e','t','i','6','4','i','8','i','m','m','i','6','4','i','m','m','i','6','4','m','e','m','i','6','4','m','e','m','_','T','C','i','6','4','u','8','i','m','m','i','8','i','m','m','i','8','m','e','m','i','8','m','e','m','_','N','O','R','E','X','l','e','a','6','4','_','3','2','m','e','m','l','e','a','6','4','m','e','m','o','f','f','s','e','t','1','6','_','1','6','o','f','f','s','e','t','1','6','_','3','2','o','f','f','s','e','t','1','6','_','8','o','f','f','s','e','t','3','2','_','1','6','o','f','f','s','e','t','3','2','_','3','2','o','f','f','s','e','t','3','2','_','6','4','o','f','f','s','e','t','3','2','_','8','o','f','f','s','e','t','6','4','_','1','6','o','f','f','s','e','t','6','4','_','3','2','o','f','f','s','e','t','6','4','_','6','4','o','f','f','s','e','t','6','4','_','8','o','p','a','q','u','e','m','e','m','p','t','y','p','e','0','p','t','y','p','e','1','p','t','y','p','e','2','p','t','y','p','e','3','p','t','y','p','e','4','p','t','y','p','e','5','s','d','m','e','m','s','h','m','e','m','s','i','b','m','e','m','s','r','c','i','d','x','1','6','s','r','c','i','d','x','3','2','s','r','c','i','d','x','6','4','s','r','c','i','d','x','8','s','s','m','e','m','t','y','p','e','0','t','y','p','e','1','t','y','p','e','2','t','y','p','e','3','t','y','p','e','4','t','y','p','e','5','u','4','i','m','m','u','8','i','m','m','u','n','t','y','p','e','d','_','i','m','m','_','0','v','x','1','2','8','m','e','m','v','x','1','2','8','x','m','e','m','v','x','2','5','6','m','e','m','v','x','2','5','6','x','m','e','m','v','x','6','4','m','e','m','v','x','6','4','x','m','e','m','v','y','1','2','8','m','e','m','v','y','1','2','8','x','m','e','m','v','y','2','5','6','m','e','m','v','y','2','5','6','x','m','e','m','v','y','5','1','2','x','m','e','m','v','z','2','5','6','m','e','m','v','z','5','1','2','m','e','m',};
    }
}
