namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum CondCodeKind : uint
    {
        SETEQ = 0,
        SETGE = 1,
        SETGT = 2,
        SETLE = 3,
        SETLT = 4,
        SETNE = 5,
        SETO = 6,
        SETOEQ = 7,
        SETOGE = 8,
        SETOGT = 9,
        SETOLE = 10,
        SETOLT = 11,
        SETONE = 12,
        SETUEQ = 13,
        SETUGE = 14,
        SETUGT = 15,
        SETULE = 16,
        SETULT = 17,
        SETUNE = 18,
        SETUO = 19,
    }

    [ApiCompleteAttribute]
    public readonly struct CondCodeST
    {
        public const uint EntryCount = 20;

        public const uint CharCount = 111;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<CondCodeKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[80]{0x00,0x00,0x00,0x00,0x05,0x00,0x00,0x00,0x0a,0x00,0x00,0x00,0x0f,0x00,0x00,0x00,0x14,0x00,0x00,0x00,0x19,0x00,0x00,0x00,0x1e,0x00,0x00,0x00,0x22,0x00,0x00,0x00,0x28,0x00,0x00,0x00,0x2e,0x00,0x00,0x00,0x34,0x00,0x00,0x00,0x3a,0x00,0x00,0x00,0x40,0x00,0x00,0x00,0x46,0x00,0x00,0x00,0x4c,0x00,0x00,0x00,0x52,0x00,0x00,0x00,0x58,0x00,0x00,0x00,0x5e,0x00,0x00,0x00,0x64,0x00,0x00,0x00,0x6a,0x00,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[111]{'S','E','T','E','Q','S','E','T','G','E','S','E','T','G','T','S','E','T','L','E','S','E','T','L','T','S','E','T','N','E','S','E','T','O','S','E','T','O','E','Q','S','E','T','O','G','E','S','E','T','O','G','T','S','E','T','O','L','E','S','E','T','O','L','T','S','E','T','O','N','E','S','E','T','U','E','Q','S','E','T','U','G','E','S','E','T','U','G','T','S','E','T','U','L','E','S','E','T','U','L','T','S','E','T','U','N','E','S','E','T','U','O',};
    }
}
