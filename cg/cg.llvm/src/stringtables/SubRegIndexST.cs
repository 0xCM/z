namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum SubRegIndexKind : uint
    {
        sub_16bit = 0,
        sub_16bit_hi = 1,
        sub_32bit = 2,
        sub_8bit = 3,
        sub_8bit_hi = 4,
        sub_8bit_hi_phony = 5,
        sub_mask_0 = 6,
        sub_mask_1 = 7,
        sub_xmm = 8,
        sub_ymm = 9,
    }

    [ApiCompleteAttribute]
    public readonly struct SubRegIndexST
    {
        public const uint EntryCount = 10;

        public const uint CharCount = 100;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<SubRegIndexKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[40]{0x00,0x00,0x00,0x00,0x09,0x00,0x00,0x00,0x15,0x00,0x00,0x00,0x1e,0x00,0x00,0x00,0x26,0x00,0x00,0x00,0x31,0x00,0x00,0x00,0x42,0x00,0x00,0x00,0x4c,0x00,0x00,0x00,0x56,0x00,0x00,0x00,0x5d,0x00,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[100]{'s','u','b','_','1','6','b','i','t','s','u','b','_','1','6','b','i','t','_','h','i','s','u','b','_','3','2','b','i','t','s','u','b','_','8','b','i','t','s','u','b','_','8','b','i','t','_','h','i','s','u','b','_','8','b','i','t','_','h','i','_','p','h','o','n','y','s','u','b','_','m','a','s','k','_','0','s','u','b','_','m','a','s','k','_','1','s','u','b','_','x','m','m','s','u','b','_','y','m','m',};
    }
}
