namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum MCInstPredicateKind : uint
    {
        CheckLockPrefix = 0,
        IsAtomicCompareAndSwap = 1,
        IsAtomicCompareAndSwap16B = 2,
        IsAtomicCompareAndSwap8B = 3,
        IsAtomicCompareAndSwap_8 = 4,
        IsCMOVArm_Or_CMOVBErm = 5,
        IsCMOVArr_Or_CMOVBErr = 6,
        IsCompareAndSwap16B = 7,
        IsCompareAndSwap8B = 8,
        IsRegMemCompareAndSwap = 9,
        IsRegMemCompareAndSwap_16_32_64 = 10,
        IsRegMemCompareAndSwap_8 = 11,
        IsRegRegCompareAndSwap = 12,
        IsRegRegCompareAndSwap_16_32_64 = 13,
        IsRegRegCompareAndSwap_8 = 14,
        IsSETAm_Or_SETBEm = 15,
        IsSETAr_Or_SETBEr = 16,
        IsThreeOperandsLEAFn = 17,
        IsThreeOperandsLEAPredicate = 18,
        ZeroIdiomPredicate = 19,
        ZeroIdiomVPERMPredicate = 20,
        anonymous_10404 = 21,
        anonymous_10405 = 22,
        anonymous_10406 = 23,
        anonymous_10407 = 24,
        anonymous_10408 = 25,
        anonymous_10409 = 26,
        anonymous_10410 = 27,
        anonymous_10411 = 28,
        anonymous_10412 = 29,
        anonymous_10413 = 30,
        anonymous_10414 = 31,
        anonymous_10415 = 32,
        anonymous_10416 = 33,
        anonymous_10419 = 34,
        anonymous_10420 = 35,
        anonymous_10421 = 36,
        anonymous_10422 = 37,
        anonymous_10423 = 38,
        anonymous_10424 = 39,
        anonymous_10425 = 40,
        anonymous_10426 = 41,
        anonymous_13222 = 42,
        anonymous_13223 = 43,
        anonymous_13224 = 44,
        anonymous_13225 = 45,
        anonymous_13226 = 46,
        anonymous_13227 = 47,
        anonymous_13228 = 48,
        anonymous_13229 = 49,
        anonymous_15919 = 50,
        anonymous_16882 = 51,
        anonymous_16883 = 52,
        anonymous_16884 = 53,
        anonymous_16885 = 54,
        anonymous_16886 = 55,
        anonymous_17923 = 56,
        anonymous_17926 = 57,
        anonymous_17929 = 58,
        anonymous_17932 = 59,
        anonymous_17940 = 60,
        anonymous_17943 = 61,
        anonymous_17946 = 62,
        anonymous_17949 = 63,
    }

    [ApiCompleteAttribute]
    public readonly struct MCInstPredicateST
    {
        public const uint EntryCount = 64;

        public const uint CharCount = 1110;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<MCInstPredicateKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[256]{0x00,0x00,0x00,0x00,0x0f,0x00,0x00,0x00,0x25,0x00,0x00,0x00,0x3e,0x00,0x00,0x00,0x56,0x00,0x00,0x00,0x6e,0x00,0x00,0x00,0x83,0x00,0x00,0x00,0x98,0x00,0x00,0x00,0xab,0x00,0x00,0x00,0xbd,0x00,0x00,0x00,0xd3,0x00,0x00,0x00,0xf2,0x00,0x00,0x00,0x0a,0x01,0x00,0x00,0x20,0x01,0x00,0x00,0x3f,0x01,0x00,0x00,0x57,0x01,0x00,0x00,0x68,0x01,0x00,0x00,0x79,0x01,0x00,0x00,0x8d,0x01,0x00,0x00,0xa8,0x01,0x00,0x00,0xba,0x01,0x00,0x00,0xd1,0x01,0x00,0x00,0xe0,0x01,0x00,0x00,0xef,0x01,0x00,0x00,0xfe,0x01,0x00,0x00,0x0d,0x02,0x00,0x00,0x1c,0x02,0x00,0x00,0x2b,0x02,0x00,0x00,0x3a,0x02,0x00,0x00,0x49,0x02,0x00,0x00,0x58,0x02,0x00,0x00,0x67,0x02,0x00,0x00,0x76,0x02,0x00,0x00,0x85,0x02,0x00,0x00,0x94,0x02,0x00,0x00,0xa3,0x02,0x00,0x00,0xb2,0x02,0x00,0x00,0xc1,0x02,0x00,0x00,0xd0,0x02,0x00,0x00,0xdf,0x02,0x00,0x00,0xee,0x02,0x00,0x00,0xfd,0x02,0x00,0x00,0x0c,0x03,0x00,0x00,0x1b,0x03,0x00,0x00,0x2a,0x03,0x00,0x00,0x39,0x03,0x00,0x00,0x48,0x03,0x00,0x00,0x57,0x03,0x00,0x00,0x66,0x03,0x00,0x00,0x75,0x03,0x00,0x00,0x84,0x03,0x00,0x00,0x93,0x03,0x00,0x00,0xa2,0x03,0x00,0x00,0xb1,0x03,0x00,0x00,0xc0,0x03,0x00,0x00,0xcf,0x03,0x00,0x00,0xde,0x03,0x00,0x00,0xed,0x03,0x00,0x00,0xfc,0x03,0x00,0x00,0x0b,0x04,0x00,0x00,0x1a,0x04,0x00,0x00,0x29,0x04,0x00,0x00,0x38,0x04,0x00,0x00,0x47,0x04,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[1110]{'C','h','e','c','k','L','o','c','k','P','r','e','f','i','x','I','s','A','t','o','m','i','c','C','o','m','p','a','r','e','A','n','d','S','w','a','p','I','s','A','t','o','m','i','c','C','o','m','p','a','r','e','A','n','d','S','w','a','p','1','6','B','I','s','A','t','o','m','i','c','C','o','m','p','a','r','e','A','n','d','S','w','a','p','8','B','I','s','A','t','o','m','i','c','C','o','m','p','a','r','e','A','n','d','S','w','a','p','_','8','I','s','C','M','O','V','A','r','m','_','O','r','_','C','M','O','V','B','E','r','m','I','s','C','M','O','V','A','r','r','_','O','r','_','C','M','O','V','B','E','r','r','I','s','C','o','m','p','a','r','e','A','n','d','S','w','a','p','1','6','B','I','s','C','o','m','p','a','r','e','A','n','d','S','w','a','p','8','B','I','s','R','e','g','M','e','m','C','o','m','p','a','r','e','A','n','d','S','w','a','p','I','s','R','e','g','M','e','m','C','o','m','p','a','r','e','A','n','d','S','w','a','p','_','1','6','_','3','2','_','6','4','I','s','R','e','g','M','e','m','C','o','m','p','a','r','e','A','n','d','S','w','a','p','_','8','I','s','R','e','g','R','e','g','C','o','m','p','a','r','e','A','n','d','S','w','a','p','I','s','R','e','g','R','e','g','C','o','m','p','a','r','e','A','n','d','S','w','a','p','_','1','6','_','3','2','_','6','4','I','s','R','e','g','R','e','g','C','o','m','p','a','r','e','A','n','d','S','w','a','p','_','8','I','s','S','E','T','A','m','_','O','r','_','S','E','T','B','E','m','I','s','S','E','T','A','r','_','O','r','_','S','E','T','B','E','r','I','s','T','h','r','e','e','O','p','e','r','a','n','d','s','L','E','A','F','n','I','s','T','h','r','e','e','O','p','e','r','a','n','d','s','L','E','A','P','r','e','d','i','c','a','t','e','Z','e','r','o','I','d','i','o','m','P','r','e','d','i','c','a','t','e','Z','e','r','o','I','d','i','o','m','V','P','E','R','M','P','r','e','d','i','c','a','t','e','a','n','o','n','y','m','o','u','s','_','1','0','4','0','4','a','n','o','n','y','m','o','u','s','_','1','0','4','0','5','a','n','o','n','y','m','o','u','s','_','1','0','4','0','6','a','n','o','n','y','m','o','u','s','_','1','0','4','0','7','a','n','o','n','y','m','o','u','s','_','1','0','4','0','8','a','n','o','n','y','m','o','u','s','_','1','0','4','0','9','a','n','o','n','y','m','o','u','s','_','1','0','4','1','0','a','n','o','n','y','m','o','u','s','_','1','0','4','1','1','a','n','o','n','y','m','o','u','s','_','1','0','4','1','2','a','n','o','n','y','m','o','u','s','_','1','0','4','1','3','a','n','o','n','y','m','o','u','s','_','1','0','4','1','4','a','n','o','n','y','m','o','u','s','_','1','0','4','1','5','a','n','o','n','y','m','o','u','s','_','1','0','4','1','6','a','n','o','n','y','m','o','u','s','_','1','0','4','1','9','a','n','o','n','y','m','o','u','s','_','1','0','4','2','0','a','n','o','n','y','m','o','u','s','_','1','0','4','2','1','a','n','o','n','y','m','o','u','s','_','1','0','4','2','2','a','n','o','n','y','m','o','u','s','_','1','0','4','2','3','a','n','o','n','y','m','o','u','s','_','1','0','4','2','4','a','n','o','n','y','m','o','u','s','_','1','0','4','2','5','a','n','o','n','y','m','o','u','s','_','1','0','4','2','6','a','n','o','n','y','m','o','u','s','_','1','3','2','2','2','a','n','o','n','y','m','o','u','s','_','1','3','2','2','3','a','n','o','n','y','m','o','u','s','_','1','3','2','2','4','a','n','o','n','y','m','o','u','s','_','1','3','2','2','5','a','n','o','n','y','m','o','u','s','_','1','3','2','2','6','a','n','o','n','y','m','o','u','s','_','1','3','2','2','7','a','n','o','n','y','m','o','u','s','_','1','3','2','2','8','a','n','o','n','y','m','o','u','s','_','1','3','2','2','9','a','n','o','n','y','m','o','u','s','_','1','5','9','1','9','a','n','o','n','y','m','o','u','s','_','1','6','8','8','2','a','n','o','n','y','m','o','u','s','_','1','6','8','8','3','a','n','o','n','y','m','o','u','s','_','1','6','8','8','4','a','n','o','n','y','m','o','u','s','_','1','6','8','8','5','a','n','o','n','y','m','o','u','s','_','1','6','8','8','6','a','n','o','n','y','m','o','u','s','_','1','7','9','2','3','a','n','o','n','y','m','o','u','s','_','1','7','9','2','6','a','n','o','n','y','m','o','u','s','_','1','7','9','2','9','a','n','o','n','y','m','o','u','s','_','1','7','9','3','2','a','n','o','n','y','m','o','u','s','_','1','7','9','4','0','a','n','o','n','y','m','o','u','s','_','1','7','9','4','3','a','n','o','n','y','m','o','u','s','_','1','7','9','4','6','a','n','o','n','y','m','o','u','s','_','1','7','9','4','9',};
    }
}
