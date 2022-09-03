namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum AsmOperandClassKind : uint
    {
        AVX512RCOperand = 0,
        ImmAsmOperand = 1,
        ImmSExti16i8AsmOperand = 2,
        ImmSExti32i8AsmOperand = 3,
        ImmSExti64i32AsmOperand = 4,
        ImmSExti64i8AsmOperand = 5,
        ImmUnsignedi4AsmOperand = 6,
        ImmUnsignedi8AsmOperand = 7,
        VK16PairAsmOperand = 8,
        VK1PairAsmOperand = 9,
        VK2PairAsmOperand = 10,
        VK4PairAsmOperand = 11,
        VK8PairAsmOperand = 12,
        X86AbsMem16AsmOperand = 13,
        X86AbsMemAsmOperand = 14,
        X86DstIdx16Operand = 15,
        X86DstIdx32Operand = 16,
        X86DstIdx64Operand = 17,
        X86DstIdx8Operand = 18,
        X86GR16orGR32orGR64AsmOperand = 19,
        X86GR32orGR64AsmOperand = 20,
        X86Mem128AsmOperand = 21,
        X86Mem128_RC128Operand = 22,
        X86Mem128_RC128XOperand = 23,
        X86Mem128_RC256Operand = 24,
        X86Mem128_RC256XOperand = 25,
        X86Mem16AsmOperand = 26,
        X86Mem256AsmOperand = 27,
        X86Mem256_RC128Operand = 28,
        X86Mem256_RC128XOperand = 29,
        X86Mem256_RC256Operand = 30,
        X86Mem256_RC256XOperand = 31,
        X86Mem256_RC512Operand = 32,
        X86Mem32AsmOperand = 33,
        X86Mem512AsmOperand = 34,
        X86Mem512_RC256XOperand = 35,
        X86Mem512_RC512Operand = 36,
        X86Mem64AsmOperand = 37,
        X86Mem64_RC128Operand = 38,
        X86Mem64_RC128XOperand = 39,
        X86Mem80AsmOperand = 40,
        X86Mem8AsmOperand = 41,
        X86MemAsmOperand = 42,
        X86MemOffs16_16AsmOperand = 43,
        X86MemOffs16_32AsmOperand = 44,
        X86MemOffs16_8AsmOperand = 45,
        X86MemOffs32_16AsmOperand = 46,
        X86MemOffs32_32AsmOperand = 47,
        X86MemOffs32_64AsmOperand = 48,
        X86MemOffs32_8AsmOperand = 49,
        X86MemOffs64_16AsmOperand = 50,
        X86MemOffs64_32AsmOperand = 51,
        X86MemOffs64_64AsmOperand = 52,
        X86MemOffs64_8AsmOperand = 53,
        X86SibMemOperand = 54,
        X86SrcIdx16Operand = 55,
        X86SrcIdx32Operand = 56,
        X86SrcIdx64Operand = 57,
        X86SrcIdx8Operand = 58,
    }

    [ApiCompleteAttribute]
    public readonly struct AsmOperandClassST
    {
        public const uint EntryCount = 59;

        public const uint CharCount = 1223;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<AsmOperandClassKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[236]{0x00,0x00,0x00,0x00,0x0f,0x00,0x00,0x00,0x1c,0x00,0x00,0x00,0x32,0x00,0x00,0x00,0x48,0x00,0x00,0x00,0x5f,0x00,0x00,0x00,0x75,0x00,0x00,0x00,0x8c,0x00,0x00,0x00,0xa3,0x00,0x00,0x00,0xb5,0x00,0x00,0x00,0xc6,0x00,0x00,0x00,0xd7,0x00,0x00,0x00,0xe8,0x00,0x00,0x00,0xf9,0x00,0x00,0x00,0x0e,0x01,0x00,0x00,0x21,0x01,0x00,0x00,0x33,0x01,0x00,0x00,0x45,0x01,0x00,0x00,0x57,0x01,0x00,0x00,0x68,0x01,0x00,0x00,0x85,0x01,0x00,0x00,0x9c,0x01,0x00,0x00,0xaf,0x01,0x00,0x00,0xc5,0x01,0x00,0x00,0xdc,0x01,0x00,0x00,0xf2,0x01,0x00,0x00,0x09,0x02,0x00,0x00,0x1b,0x02,0x00,0x00,0x2e,0x02,0x00,0x00,0x44,0x02,0x00,0x00,0x5b,0x02,0x00,0x00,0x71,0x02,0x00,0x00,0x88,0x02,0x00,0x00,0x9e,0x02,0x00,0x00,0xb0,0x02,0x00,0x00,0xc3,0x02,0x00,0x00,0xda,0x02,0x00,0x00,0xf0,0x02,0x00,0x00,0x02,0x03,0x00,0x00,0x17,0x03,0x00,0x00,0x2d,0x03,0x00,0x00,0x3f,0x03,0x00,0x00,0x50,0x03,0x00,0x00,0x60,0x03,0x00,0x00,0x79,0x03,0x00,0x00,0x92,0x03,0x00,0x00,0xaa,0x03,0x00,0x00,0xc3,0x03,0x00,0x00,0xdc,0x03,0x00,0x00,0xf5,0x03,0x00,0x00,0x0d,0x04,0x00,0x00,0x26,0x04,0x00,0x00,0x3f,0x04,0x00,0x00,0x58,0x04,0x00,0x00,0x70,0x04,0x00,0x00,0x80,0x04,0x00,0x00,0x92,0x04,0x00,0x00,0xa4,0x04,0x00,0x00,0xb6,0x04,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[1223]{'A','V','X','5','1','2','R','C','O','p','e','r','a','n','d','I','m','m','A','s','m','O','p','e','r','a','n','d','I','m','m','S','E','x','t','i','1','6','i','8','A','s','m','O','p','e','r','a','n','d','I','m','m','S','E','x','t','i','3','2','i','8','A','s','m','O','p','e','r','a','n','d','I','m','m','S','E','x','t','i','6','4','i','3','2','A','s','m','O','p','e','r','a','n','d','I','m','m','S','E','x','t','i','6','4','i','8','A','s','m','O','p','e','r','a','n','d','I','m','m','U','n','s','i','g','n','e','d','i','4','A','s','m','O','p','e','r','a','n','d','I','m','m','U','n','s','i','g','n','e','d','i','8','A','s','m','O','p','e','r','a','n','d','V','K','1','6','P','a','i','r','A','s','m','O','p','e','r','a','n','d','V','K','1','P','a','i','r','A','s','m','O','p','e','r','a','n','d','V','K','2','P','a','i','r','A','s','m','O','p','e','r','a','n','d','V','K','4','P','a','i','r','A','s','m','O','p','e','r','a','n','d','V','K','8','P','a','i','r','A','s','m','O','p','e','r','a','n','d','X','8','6','A','b','s','M','e','m','1','6','A','s','m','O','p','e','r','a','n','d','X','8','6','A','b','s','M','e','m','A','s','m','O','p','e','r','a','n','d','X','8','6','D','s','t','I','d','x','1','6','O','p','e','r','a','n','d','X','8','6','D','s','t','I','d','x','3','2','O','p','e','r','a','n','d','X','8','6','D','s','t','I','d','x','6','4','O','p','e','r','a','n','d','X','8','6','D','s','t','I','d','x','8','O','p','e','r','a','n','d','X','8','6','G','R','1','6','o','r','G','R','3','2','o','r','G','R','6','4','A','s','m','O','p','e','r','a','n','d','X','8','6','G','R','3','2','o','r','G','R','6','4','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','1','2','8','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','1','2','8','_','R','C','1','2','8','O','p','e','r','a','n','d','X','8','6','M','e','m','1','2','8','_','R','C','1','2','8','X','O','p','e','r','a','n','d','X','8','6','M','e','m','1','2','8','_','R','C','2','5','6','O','p','e','r','a','n','d','X','8','6','M','e','m','1','2','8','_','R','C','2','5','6','X','O','p','e','r','a','n','d','X','8','6','M','e','m','1','6','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','2','5','6','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','2','5','6','_','R','C','1','2','8','O','p','e','r','a','n','d','X','8','6','M','e','m','2','5','6','_','R','C','1','2','8','X','O','p','e','r','a','n','d','X','8','6','M','e','m','2','5','6','_','R','C','2','5','6','O','p','e','r','a','n','d','X','8','6','M','e','m','2','5','6','_','R','C','2','5','6','X','O','p','e','r','a','n','d','X','8','6','M','e','m','2','5','6','_','R','C','5','1','2','O','p','e','r','a','n','d','X','8','6','M','e','m','3','2','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','5','1','2','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','5','1','2','_','R','C','2','5','6','X','O','p','e','r','a','n','d','X','8','6','M','e','m','5','1','2','_','R','C','5','1','2','O','p','e','r','a','n','d','X','8','6','M','e','m','6','4','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','6','4','_','R','C','1','2','8','O','p','e','r','a','n','d','X','8','6','M','e','m','6','4','_','R','C','1','2','8','X','O','p','e','r','a','n','d','X','8','6','M','e','m','8','0','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','8','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','O','f','f','s','1','6','_','1','6','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','O','f','f','s','1','6','_','3','2','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','O','f','f','s','1','6','_','8','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','O','f','f','s','3','2','_','1','6','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','O','f','f','s','3','2','_','3','2','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','O','f','f','s','3','2','_','6','4','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','O','f','f','s','3','2','_','8','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','O','f','f','s','6','4','_','1','6','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','O','f','f','s','6','4','_','3','2','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','O','f','f','s','6','4','_','6','4','A','s','m','O','p','e','r','a','n','d','X','8','6','M','e','m','O','f','f','s','6','4','_','8','A','s','m','O','p','e','r','a','n','d','X','8','6','S','i','b','M','e','m','O','p','e','r','a','n','d','X','8','6','S','r','c','I','d','x','1','6','O','p','e','r','a','n','d','X','8','6','S','r','c','I','d','x','3','2','O','p','e','r','a','n','d','X','8','6','S','r','c','I','d','x','6','4','O','p','e','r','a','n','d','X','8','6','S','r','c','I','d','x','8','O','p','e','r','a','n','d',};
    }
}
