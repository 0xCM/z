namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum RegisterOperandKind : uint
    {
        GR16orGR32orGR64 = 0,
        GR32orGR64 = 1,
        RSTi = 2,
        VK16Pair = 3,
        VK1Pair = 4,
        VK2Pair = 5,
        VK4Pair = 6,
        VK8Pair = 7,
    }

    [ApiCompleteAttribute]
    public readonly struct RegisterOperandST
    {
        public const uint EntryCount = 8;

        public const uint CharCount = 66;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<RegisterOperandKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[32]{0x00,0x00,0x00,0x00,0x10,0x00,0x00,0x00,0x1a,0x00,0x00,0x00,0x1e,0x00,0x00,0x00,0x26,0x00,0x00,0x00,0x2d,0x00,0x00,0x00,0x34,0x00,0x00,0x00,0x3b,0x00,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[66]{'G','R','1','6','o','r','G','R','3','2','o','r','G','R','6','4','G','R','3','2','o','r','G','R','6','4','R','S','T','i','V','K','1','6','P','a','i','r','V','K','1','P','a','i','r','V','K','2','P','a','i','r','V','K','4','P','a','i','r','V','K','8','P','a','i','r',};
    }
}
