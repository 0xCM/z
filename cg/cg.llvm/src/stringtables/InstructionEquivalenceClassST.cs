namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum InstructionEquivalenceClassKind : uint
    {
        anonymous_12213 = 0,
        anonymous_12214 = 1,
        anonymous_12215 = 2,
        anonymous_13242 = 3,
        anonymous_14222 = 4,
        anonymous_15007 = 5,
        anonymous_15008 = 6,
        anonymous_15913 = 7,
        anonymous_15914 = 8,
        anonymous_15915 = 9,
        anonymous_15916 = 10,
        anonymous_15918 = 11,
        anonymous_15920 = 12,
        anonymous_15921 = 13,
        anonymous_15922 = 14,
        anonymous_15923 = 15,
        anonymous_15924 = 16,
        anonymous_17768 = 17,
        anonymous_17781 = 18,
        anonymous_17782 = 19,
        anonymous_17783 = 20,
        anonymous_17784 = 21,
        anonymous_17786 = 22,
        anonymous_17787 = 23,
        anonymous_18742 = 24,
        anonymous_18743 = 25,
        anonymous_18745 = 26,
        anonymous_18746 = 27,
        anonymous_18747 = 28,
        anonymous_19626 = 29,
        anonymous_19627 = 30,
        anonymous_19630 = 31,
        anonymous_21649 = 32,
    }

    [ApiCompleteAttribute]
    public readonly struct InstructionEquivalenceClassST
    {
        public const uint EntryCount = 33;

        public const uint CharCount = 495;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<InstructionEquivalenceClassKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[132]{0x00,0x00,0x00,0x00,0x0f,0x00,0x00,0x00,0x1e,0x00,0x00,0x00,0x2d,0x00,0x00,0x00,0x3c,0x00,0x00,0x00,0x4b,0x00,0x00,0x00,0x5a,0x00,0x00,0x00,0x69,0x00,0x00,0x00,0x78,0x00,0x00,0x00,0x87,0x00,0x00,0x00,0x96,0x00,0x00,0x00,0xa5,0x00,0x00,0x00,0xb4,0x00,0x00,0x00,0xc3,0x00,0x00,0x00,0xd2,0x00,0x00,0x00,0xe1,0x00,0x00,0x00,0xf0,0x00,0x00,0x00,0xff,0x00,0x00,0x00,0x0e,0x01,0x00,0x00,0x1d,0x01,0x00,0x00,0x2c,0x01,0x00,0x00,0x3b,0x01,0x00,0x00,0x4a,0x01,0x00,0x00,0x59,0x01,0x00,0x00,0x68,0x01,0x00,0x00,0x77,0x01,0x00,0x00,0x86,0x01,0x00,0x00,0x95,0x01,0x00,0x00,0xa4,0x01,0x00,0x00,0xb3,0x01,0x00,0x00,0xc2,0x01,0x00,0x00,0xd1,0x01,0x00,0x00,0xe0,0x01,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[495]{'a','n','o','n','y','m','o','u','s','_','1','2','2','1','3','a','n','o','n','y','m','o','u','s','_','1','2','2','1','4','a','n','o','n','y','m','o','u','s','_','1','2','2','1','5','a','n','o','n','y','m','o','u','s','_','1','3','2','4','2','a','n','o','n','y','m','o','u','s','_','1','4','2','2','2','a','n','o','n','y','m','o','u','s','_','1','5','0','0','7','a','n','o','n','y','m','o','u','s','_','1','5','0','0','8','a','n','o','n','y','m','o','u','s','_','1','5','9','1','3','a','n','o','n','y','m','o','u','s','_','1','5','9','1','4','a','n','o','n','y','m','o','u','s','_','1','5','9','1','5','a','n','o','n','y','m','o','u','s','_','1','5','9','1','6','a','n','o','n','y','m','o','u','s','_','1','5','9','1','8','a','n','o','n','y','m','o','u','s','_','1','5','9','2','0','a','n','o','n','y','m','o','u','s','_','1','5','9','2','1','a','n','o','n','y','m','o','u','s','_','1','5','9','2','2','a','n','o','n','y','m','o','u','s','_','1','5','9','2','3','a','n','o','n','y','m','o','u','s','_','1','5','9','2','4','a','n','o','n','y','m','o','u','s','_','1','7','7','6','8','a','n','o','n','y','m','o','u','s','_','1','7','7','8','1','a','n','o','n','y','m','o','u','s','_','1','7','7','8','2','a','n','o','n','y','m','o','u','s','_','1','7','7','8','3','a','n','o','n','y','m','o','u','s','_','1','7','7','8','4','a','n','o','n','y','m','o','u','s','_','1','7','7','8','6','a','n','o','n','y','m','o','u','s','_','1','7','7','8','7','a','n','o','n','y','m','o','u','s','_','1','8','7','4','2','a','n','o','n','y','m','o','u','s','_','1','8','7','4','3','a','n','o','n','y','m','o','u','s','_','1','8','7','4','5','a','n','o','n','y','m','o','u','s','_','1','8','7','4','6','a','n','o','n','y','m','o','u','s','_','1','8','7','4','7','a','n','o','n','y','m','o','u','s','_','1','9','6','2','6','a','n','o','n','y','m','o','u','s','_','1','9','6','2','7','a','n','o','n','y','m','o','u','s','_','1','9','6','3','0','a','n','o','n','y','m','o','u','s','_','2','1','6','4','9',};
    }
}
