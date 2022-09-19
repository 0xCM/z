namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum ImmTypeKind : uint
    {
        Imm16 = 0,
        Imm16PCRel = 1,
        Imm32 = 2,
        Imm32PCRel = 3,
        Imm32S = 4,
        Imm64 = 5,
        Imm8 = 6,
        Imm8PCRel = 7,
        Imm8Reg = 8,
        NoImm = 9,
    }

    [ApiCompleteAttribute]
    public readonly struct ImmTypeST
    {
        public const uint EntryCount = 10;

        public const uint CharCount = 66;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<ImmTypeKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[40]{0x00,0x00,0x00,0x00,0x05,0x00,0x00,0x00,0x0f,0x00,0x00,0x00,0x14,0x00,0x00,0x00,0x1e,0x00,0x00,0x00,0x24,0x00,0x00,0x00,0x29,0x00,0x00,0x00,0x2d,0x00,0x00,0x00,0x36,0x00,0x00,0x00,0x3d,0x00,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[66]{'I','m','m','1','6','I','m','m','1','6','P','C','R','e','l','I','m','m','3','2','I','m','m','3','2','P','C','R','e','l','I','m','m','3','2','S','I','m','m','6','4','I','m','m','8','I','m','m','8','P','C','R','e','l','I','m','m','8','R','e','g','N','o','I','m','m',};
    }
}
