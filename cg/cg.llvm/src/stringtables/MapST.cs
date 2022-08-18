namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum MapKind : uint
    {
        OB = 0,
        T8 = 1,
        TA = 2,
        TB = 3,
        T_MAP5 = 4,
        T_MAP6 = 5,
        ThreeDNow = 6,
        XOP8 = 7,
        XOP9 = 8,
        XOPA = 9,
    }

    [ApiCompleteAttribute]
    public readonly struct MapST
    {
        public const uint EntryCount = 10;

        public const uint CharCount = 41;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<MapKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[40]{0x00,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x06,0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x0e,0x00,0x00,0x00,0x14,0x00,0x00,0x00,0x1d,0x00,0x00,0x00,0x21,0x00,0x00,0x00,0x25,0x00,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[41]{'O','B','T','8','T','A','T','B','T','_','M','A','P','5','T','_','M','A','P','6','T','h','r','e','e','D','N','o','w','X','O','P','8','X','O','P','9','X','O','P','A',};
    }
}
