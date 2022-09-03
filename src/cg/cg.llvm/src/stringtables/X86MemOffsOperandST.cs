namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum X86MemOffsOperandKind : uint
    {
        offset16_16 = 0,
        offset16_32 = 1,
        offset16_8 = 2,
        offset32_16 = 3,
        offset32_32 = 4,
        offset32_64 = 5,
        offset32_8 = 6,
        offset64_16 = 7,
        offset64_32 = 8,
        offset64_64 = 9,
        offset64_8 = 10,
    }

    [ApiCompleteAttribute]
    public readonly struct X86MemOffsOperandST
    {
        public const uint EntryCount = 11;

        public const uint CharCount = 118;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<X86MemOffsOperandKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[44]{0x00,0x00,0x00,0x00,0x0b,0x00,0x00,0x00,0x16,0x00,0x00,0x00,0x20,0x00,0x00,0x00,0x2b,0x00,0x00,0x00,0x36,0x00,0x00,0x00,0x41,0x00,0x00,0x00,0x4b,0x00,0x00,0x00,0x56,0x00,0x00,0x00,0x61,0x00,0x00,0x00,0x6c,0x00,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[118]{'o','f','f','s','e','t','1','6','_','1','6','o','f','f','s','e','t','1','6','_','3','2','o','f','f','s','e','t','1','6','_','8','o','f','f','s','e','t','3','2','_','1','6','o','f','f','s','e','t','3','2','_','3','2','o','f','f','s','e','t','3','2','_','6','4','o','f','f','s','e','t','3','2','_','8','o','f','f','s','e','t','6','4','_','1','6','o','f','f','s','e','t','6','4','_','3','2','o','f','f','s','e','t','6','4','_','6','4','o','f','f','s','e','t','6','4','_','8',};
    }
}
