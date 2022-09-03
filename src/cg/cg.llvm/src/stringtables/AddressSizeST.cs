namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum AddressSizeKind : uint
    {
        AdSize16 = 0,
        AdSize32 = 1,
        AdSize64 = 2,
        AdSizeX = 3,
    }

    [ApiCompleteAttribute]
    public readonly struct AddressSizeST
    {
        public const uint EntryCount = 4;

        public const uint CharCount = 31;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<AddressSizeKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[16]{0x00,0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x10,0x00,0x00,0x00,0x18,0x00,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[31]{'A','d','S','i','z','e','1','6','A','d','S','i','z','e','3','2','A','d','S','i','z','e','6','4','A','d','S','i','z','e','X',};
    }
}
