namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum X86DstIdxOperandKind : uint
    {
        dstidx16 = 0,
        dstidx32 = 1,
        dstidx64 = 2,
        dstidx8 = 3,
    }

    [ApiCompleteAttribute]
    public readonly struct X86DstIdxOperandST
    {
        public const uint EntryCount = 4;

        public const uint CharCount = 31;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<X86DstIdxOperandKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[16]{0x00,0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x10,0x00,0x00,0x00,0x18,0x00,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[31]{'d','s','t','i','d','x','1','6','d','s','t','i','d','x','3','2','d','s','t','i','d','x','6','4','d','s','t','i','d','x','8',};
    }
}
