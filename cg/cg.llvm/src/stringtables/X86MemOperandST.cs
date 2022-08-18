namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum X86MemOperandKind : uint
    {
        anymem = 0,
        dstidx16 = 1,
        dstidx32 = 2,
        dstidx64 = 3,
        dstidx8 = 4,
        f128mem = 5,
        f16mem = 6,
        f256mem = 7,
        f32mem = 8,
        f512mem = 9,
        f64mem = 10,
        f80mem = 11,
        i128mem = 12,
        i16mem = 13,
        i256mem = 14,
        i32mem = 15,
        i512mem = 16,
        i64mem = 17,
        i8mem = 18,
        offset16_16 = 19,
        offset16_32 = 20,
        offset16_8 = 21,
        offset32_16 = 22,
        offset32_32 = 23,
        offset32_64 = 24,
        offset32_8 = 25,
        offset64_16 = 26,
        offset64_32 = 27,
        offset64_64 = 28,
        offset64_8 = 29,
        opaquemem = 30,
        sdmem = 31,
        shmem = 32,
        sibmem = 33,
        srcidx16 = 34,
        srcidx32 = 35,
        srcidx64 = 36,
        srcidx8 = 37,
        ssmem = 38,
        vx128mem = 39,
        vx128xmem = 40,
        vx256mem = 41,
        vx256xmem = 42,
        vx64mem = 43,
        vx64xmem = 44,
        vy128mem = 45,
        vy128xmem = 46,
        vy256mem = 47,
        vy256xmem = 48,
        vy512xmem = 49,
        vz256mem = 50,
        vz512mem = 51,
    }

    [ApiCompleteAttribute]
    public readonly struct X86MemOperandST
    {
        public const uint EntryCount = 52;

        public const uint CharCount = 413;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<X86MemOperandKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[208]{0x00,0x00,0x00,0x00,0x06,0x00,0x00,0x00,0x0e,0x00,0x00,0x00,0x16,0x00,0x00,0x00,0x1e,0x00,0x00,0x00,0x25,0x00,0x00,0x00,0x2c,0x00,0x00,0x00,0x32,0x00,0x00,0x00,0x39,0x00,0x00,0x00,0x3f,0x00,0x00,0x00,0x46,0x00,0x00,0x00,0x4c,0x00,0x00,0x00,0x52,0x00,0x00,0x00,0x59,0x00,0x00,0x00,0x5f,0x00,0x00,0x00,0x66,0x00,0x00,0x00,0x6c,0x00,0x00,0x00,0x73,0x00,0x00,0x00,0x79,0x00,0x00,0x00,0x7e,0x00,0x00,0x00,0x89,0x00,0x00,0x00,0x94,0x00,0x00,0x00,0x9e,0x00,0x00,0x00,0xa9,0x00,0x00,0x00,0xb4,0x00,0x00,0x00,0xbf,0x00,0x00,0x00,0xc9,0x00,0x00,0x00,0xd4,0x00,0x00,0x00,0xdf,0x00,0x00,0x00,0xea,0x00,0x00,0x00,0xf4,0x00,0x00,0x00,0xfd,0x00,0x00,0x00,0x02,0x01,0x00,0x00,0x07,0x01,0x00,0x00,0x0d,0x01,0x00,0x00,0x15,0x01,0x00,0x00,0x1d,0x01,0x00,0x00,0x25,0x01,0x00,0x00,0x2c,0x01,0x00,0x00,0x31,0x01,0x00,0x00,0x39,0x01,0x00,0x00,0x42,0x01,0x00,0x00,0x4a,0x01,0x00,0x00,0x53,0x01,0x00,0x00,0x5a,0x01,0x00,0x00,0x62,0x01,0x00,0x00,0x6a,0x01,0x00,0x00,0x73,0x01,0x00,0x00,0x7b,0x01,0x00,0x00,0x84,0x01,0x00,0x00,0x8d,0x01,0x00,0x00,0x95,0x01,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[413]{'a','n','y','m','e','m','d','s','t','i','d','x','1','6','d','s','t','i','d','x','3','2','d','s','t','i','d','x','6','4','d','s','t','i','d','x','8','f','1','2','8','m','e','m','f','1','6','m','e','m','f','2','5','6','m','e','m','f','3','2','m','e','m','f','5','1','2','m','e','m','f','6','4','m','e','m','f','8','0','m','e','m','i','1','2','8','m','e','m','i','1','6','m','e','m','i','2','5','6','m','e','m','i','3','2','m','e','m','i','5','1','2','m','e','m','i','6','4','m','e','m','i','8','m','e','m','o','f','f','s','e','t','1','6','_','1','6','o','f','f','s','e','t','1','6','_','3','2','o','f','f','s','e','t','1','6','_','8','o','f','f','s','e','t','3','2','_','1','6','o','f','f','s','e','t','3','2','_','3','2','o','f','f','s','e','t','3','2','_','6','4','o','f','f','s','e','t','3','2','_','8','o','f','f','s','e','t','6','4','_','1','6','o','f','f','s','e','t','6','4','_','3','2','o','f','f','s','e','t','6','4','_','6','4','o','f','f','s','e','t','6','4','_','8','o','p','a','q','u','e','m','e','m','s','d','m','e','m','s','h','m','e','m','s','i','b','m','e','m','s','r','c','i','d','x','1','6','s','r','c','i','d','x','3','2','s','r','c','i','d','x','6','4','s','r','c','i','d','x','8','s','s','m','e','m','v','x','1','2','8','m','e','m','v','x','1','2','8','x','m','e','m','v','x','2','5','6','m','e','m','v','x','2','5','6','x','m','e','m','v','x','6','4','m','e','m','v','x','6','4','x','m','e','m','v','y','1','2','8','m','e','m','v','y','1','2','8','x','m','e','m','v','y','2','5','6','m','e','m','v','y','2','5','6','x','m','e','m','v','y','5','1','2','x','m','e','m','v','z','2','5','6','m','e','m','v','z','5','1','2','m','e','m',};
    }
}
