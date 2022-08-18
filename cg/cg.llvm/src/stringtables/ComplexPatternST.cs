namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum ComplexPatternKind : uint
    {
        addr = 0,
        lea32addr = 1,
        lea64_32addr = 2,
        lea64addr = 3,
        mov64imm32 = 4,
        relocImm = 5,
        tls32addr = 6,
        tls32baseaddr = 7,
        tls64addr = 8,
        tls64baseaddr = 9,
        vectoraddr = 10,
    }

    [ApiCompleteAttribute]
    public readonly struct ComplexPatternST
    {
        public const uint EntryCount = 11;

        public const uint CharCount = 106;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<ComplexPatternKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[44]{0x00,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x0d,0x00,0x00,0x00,0x19,0x00,0x00,0x00,0x22,0x00,0x00,0x00,0x2c,0x00,0x00,0x00,0x34,0x00,0x00,0x00,0x3d,0x00,0x00,0x00,0x4a,0x00,0x00,0x00,0x53,0x00,0x00,0x00,0x60,0x00,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[106]{'a','d','d','r','l','e','a','3','2','a','d','d','r','l','e','a','6','4','_','3','2','a','d','d','r','l','e','a','6','4','a','d','d','r','m','o','v','6','4','i','m','m','3','2','r','e','l','o','c','I','m','m','t','l','s','3','2','a','d','d','r','t','l','s','3','2','b','a','s','e','a','d','d','r','t','l','s','6','4','a','d','d','r','t','l','s','6','4','b','a','s','e','a','d','d','r','v','e','c','t','o','r','a','d','d','r',};
    }
}
