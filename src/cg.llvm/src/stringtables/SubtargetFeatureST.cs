namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum SubtargetFeatureKind : uint
    {
        Feature3DNow = 0,
        Feature3DNowA = 1,
        Feature64Bit = 2,
        FeatureADX = 3,
        FeatureAES = 4,
        FeatureAMXBF16 = 5,
        FeatureAMXINT8 = 6,
        FeatureAMXTILE = 7,
        FeatureAVX = 8,
        FeatureAVX2 = 9,
        FeatureAVX512 = 10,
        FeatureAVXVNNI = 11,
        FeatureBF16 = 12,
        FeatureBITALG = 13,
        FeatureBMI = 14,
        FeatureBMI2 = 15,
        FeatureBWI = 16,
        FeatureCDI = 17,
        FeatureCLDEMOTE = 18,
        FeatureCLFLUSHOPT = 19,
        FeatureCLWB = 20,
        FeatureCLZERO = 21,
        FeatureCMOV = 22,
        FeatureCMPXCHG16B = 23,
        FeatureCMPXCHG8B = 24,
        FeatureCRC32 = 25,
        FeatureDQI = 26,
        FeatureENQCMD = 27,
        FeatureERI = 28,
        FeatureERMSB = 29,
        FeatureF16C = 30,
        FeatureFMA = 31,
        FeatureFMA4 = 32,
        FeatureFP16 = 33,
        FeatureFSGSBase = 34,
        FeatureFSRM = 35,
        FeatureFXSR = 36,
        FeatureGFNI = 37,
        FeatureHRESET = 38,
        FeatureIFMA = 39,
        FeatureINVPCID = 40,
        FeatureKL = 41,
        FeatureLAHFSAHF = 42,
        FeatureLVIControlFlowIntegrity = 43,
        FeatureLVILoadHardening = 44,
        FeatureLWP = 45,
        FeatureLZCNT = 46,
        FeatureMMX = 47,
        FeatureMOVBE = 48,
        FeatureMOVDIR64B = 49,
        FeatureMOVDIRI = 50,
        FeatureMWAITX = 51,
        FeatureNOPL = 52,
        FeaturePCLMUL = 53,
        FeaturePCONFIG = 54,
        FeaturePFI = 55,
        FeaturePKU = 56,
        FeaturePOPCNT = 57,
        FeaturePREFETCHWT1 = 58,
        FeaturePRFCHW = 59,
        FeaturePTWRITE = 60,
        FeatureRDPID = 61,
        FeatureRDRAND = 62,
        FeatureRDSEED = 63,
        FeatureRTM = 64,
        FeatureRetpoline = 65,
        FeatureRetpolineExternalThunk = 66,
        FeatureRetpolineIndirectBranches = 67,
        FeatureRetpolineIndirectCalls = 68,
        FeatureSERIALIZE = 69,
        FeatureSGX = 70,
        FeatureSHA = 71,
        FeatureSHSTK = 72,
        FeatureSSE1 = 73,
        FeatureSSE2 = 74,
        FeatureSSE3 = 75,
        FeatureSSE41 = 76,
        FeatureSSE42 = 77,
        FeatureSSE4A = 78,
        FeatureSSEUnalignedMem = 79,
        FeatureSSSE3 = 80,
        FeatureSoftFloat = 81,
        FeatureSpeculativeExecutionSideEffectSuppression = 82,
        FeatureTBM = 83,
        FeatureTSXLDTRK = 84,
        FeatureTaggedGlobals = 85,
        FeatureUINTR = 86,
        FeatureUseAA = 87,
        FeatureVAES = 88,
        FeatureVBMI = 89,
        FeatureVBMI2 = 90,
        FeatureVLX = 91,
        FeatureVNNI = 92,
        FeatureVP2INTERSECT = 93,
        FeatureVPCLMULQDQ = 94,
        FeatureVPOPCNTDQ = 95,
        FeatureWAITPKG = 96,
        FeatureWBNOINVD = 97,
        FeatureWIDEKL = 98,
        FeatureX87 = 99,
        FeatureXOP = 100,
        FeatureXSAVE = 101,
        FeatureXSAVEC = 102,
        FeatureXSAVEOPT = 103,
        FeatureXSAVES = 104,
        Mode16Bit = 105,
        Mode32Bit = 106,
        Mode64Bit = 107,
        ProcIntelAtom = 108,
        TuningBranchFusion = 109,
        TuningFast11ByteNOP = 110,
        TuningFast15ByteNOP = 111,
        TuningFast7ByteNOP = 112,
        TuningFastBEXTR = 113,
        TuningFastGather = 114,
        TuningFastHorizontalOps = 115,
        TuningFastLZCNT = 116,
        TuningFastMOVBE = 117,
        TuningFastSHLDRotate = 118,
        TuningFastScalarFSQRT = 119,
        TuningFastScalarShiftMasks = 120,
        TuningFastVariableCrossLaneShuffle = 121,
        TuningFastVariablePerLaneShuffle = 122,
        TuningFastVectorFSQRT = 123,
        TuningFastVectorShiftMasks = 124,
        TuningInsertVZEROUPPER = 125,
        TuningLEAForSP = 126,
        TuningLEAUsesAG = 127,
        TuningLZCNTFalseDeps = 128,
        TuningMacroFusion = 129,
        TuningPOPCNTFalseDeps = 130,
        TuningPadShortFunctions = 131,
        TuningPrefer128Bit = 132,
        TuningPrefer256Bit = 133,
        TuningPreferMaskRegisters = 134,
        TuningSlow3OpsLEA = 135,
        TuningSlowDivide32 = 136,
        TuningSlowDivide64 = 137,
        TuningSlowIncDec = 138,
        TuningSlowLEA = 139,
        TuningSlowPMADDWD = 140,
        TuningSlowPMULLD = 141,
        TuningSlowSHLD = 142,
        TuningSlowTwoMemOps = 143,
        TuningSlowUAMem16 = 144,
        TuningSlowUAMem32 = 145,
        TuningUseGLMDivSqrtCosts = 146,
        TuningUseSLMArithCosts = 147,
    }

    [ApiCompleteAttribute]
    public readonly struct SubtargetFeatureST
    {
        public const uint EntryCount = 148;

        public const uint CharCount = 2237;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<SubtargetFeatureKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[592]{0x00,0x00,0x00,0x00,0x0c,0x00,0x00,0x00,0x19,0x00,0x00,0x00,0x25,0x00,0x00,0x00,0x2f,0x00,0x00,0x00,0x39,0x00,0x00,0x00,0x47,0x00,0x00,0x00,0x55,0x00,0x00,0x00,0x63,0x00,0x00,0x00,0x6d,0x00,0x00,0x00,0x78,0x00,0x00,0x00,0x85,0x00,0x00,0x00,0x93,0x00,0x00,0x00,0x9e,0x00,0x00,0x00,0xab,0x00,0x00,0x00,0xb5,0x00,0x00,0x00,0xc0,0x00,0x00,0x00,0xca,0x00,0x00,0x00,0xd4,0x00,0x00,0x00,0xe3,0x00,0x00,0x00,0xf4,0x00,0x00,0x00,0xff,0x00,0x00,0x00,0x0c,0x01,0x00,0x00,0x17,0x01,0x00,0x00,0x28,0x01,0x00,0x00,0x38,0x01,0x00,0x00,0x44,0x01,0x00,0x00,0x4e,0x01,0x00,0x00,0x5b,0x01,0x00,0x00,0x65,0x01,0x00,0x00,0x71,0x01,0x00,0x00,0x7c,0x01,0x00,0x00,0x86,0x01,0x00,0x00,0x91,0x01,0x00,0x00,0x9c,0x01,0x00,0x00,0xab,0x01,0x00,0x00,0xb6,0x01,0x00,0x00,0xc1,0x01,0x00,0x00,0xcc,0x01,0x00,0x00,0xd9,0x01,0x00,0x00,0xe4,0x01,0x00,0x00,0xf2,0x01,0x00,0x00,0xfb,0x01,0x00,0x00,0x0a,0x02,0x00,0x00,0x28,0x02,0x00,0x00,0x3f,0x02,0x00,0x00,0x49,0x02,0x00,0x00,0x55,0x02,0x00,0x00,0x5f,0x02,0x00,0x00,0x6b,0x02,0x00,0x00,0x7b,0x02,0x00,0x00,0x89,0x02,0x00,0x00,0x96,0x02,0x00,0x00,0xa1,0x02,0x00,0x00,0xae,0x02,0x00,0x00,0xbc,0x02,0x00,0x00,0xc6,0x02,0x00,0x00,0xd0,0x02,0x00,0x00,0xdd,0x02,0x00,0x00,0xef,0x02,0x00,0x00,0xfc,0x02,0x00,0x00,0x0a,0x03,0x00,0x00,0x16,0x03,0x00,0x00,0x23,0x03,0x00,0x00,0x30,0x03,0x00,0x00,0x3a,0x03,0x00,0x00,0x4a,0x03,0x00,0x00,0x67,0x03,0x00,0x00,0x87,0x03,0x00,0x00,0xa4,0x03,0x00,0x00,0xb4,0x03,0x00,0x00,0xbe,0x03,0x00,0x00,0xc8,0x03,0x00,0x00,0xd4,0x03,0x00,0x00,0xdf,0x03,0x00,0x00,0xea,0x03,0x00,0x00,0xf5,0x03,0x00,0x00,0x01,0x04,0x00,0x00,0x0d,0x04,0x00,0x00,0x19,0x04,0x00,0x00,0x2f,0x04,0x00,0x00,0x3b,0x04,0x00,0x00,0x4b,0x04,0x00,0x00,0x7b,0x04,0x00,0x00,0x85,0x04,0x00,0x00,0x94,0x04,0x00,0x00,0xa8,0x04,0x00,0x00,0xb4,0x04,0x00,0x00,0xc0,0x04,0x00,0x00,0xcb,0x04,0x00,0x00,0xd6,0x04,0x00,0x00,0xe2,0x04,0x00,0x00,0xec,0x04,0x00,0x00,0xf7,0x04,0x00,0x00,0x0a,0x05,0x00,0x00,0x1b,0x05,0x00,0x00,0x2b,0x05,0x00,0x00,0x39,0x05,0x00,0x00,0x48,0x05,0x00,0x00,0x55,0x05,0x00,0x00,0x5f,0x05,0x00,0x00,0x69,0x05,0x00,0x00,0x75,0x05,0x00,0x00,0x82,0x05,0x00,0x00,0x91,0x05,0x00,0x00,0x9e,0x05,0x00,0x00,0xa7,0x05,0x00,0x00,0xb0,0x05,0x00,0x00,0xb9,0x05,0x00,0x00,0xc6,0x05,0x00,0x00,0xd8,0x05,0x00,0x00,0xeb,0x05,0x00,0x00,0xfe,0x05,0x00,0x00,0x10,0x06,0x00,0x00,0x1f,0x06,0x00,0x00,0x2f,0x06,0x00,0x00,0x46,0x06,0x00,0x00,0x55,0x06,0x00,0x00,0x64,0x06,0x00,0x00,0x78,0x06,0x00,0x00,0x8d,0x06,0x00,0x00,0xa7,0x06,0x00,0x00,0xc9,0x06,0x00,0x00,0xe9,0x06,0x00,0x00,0xfe,0x06,0x00,0x00,0x18,0x07,0x00,0x00,0x2e,0x07,0x00,0x00,0x3c,0x07,0x00,0x00,0x4b,0x07,0x00,0x00,0x5f,0x07,0x00,0x00,0x70,0x07,0x00,0x00,0x85,0x07,0x00,0x00,0x9c,0x07,0x00,0x00,0xae,0x07,0x00,0x00,0xc0,0x07,0x00,0x00,0xd9,0x07,0x00,0x00,0xea,0x07,0x00,0x00,0xfc,0x07,0x00,0x00,0x0e,0x08,0x00,0x00,0x1e,0x08,0x00,0x00,0x2b,0x08,0x00,0x00,0x3c,0x08,0x00,0x00,0x4c,0x08,0x00,0x00,0x5a,0x08,0x00,0x00,0x6d,0x08,0x00,0x00,0x7e,0x08,0x00,0x00,0x8f,0x08,0x00,0x00,0xa7,0x08,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[2237]{'F','e','a','t','u','r','e','3','D','N','o','w','F','e','a','t','u','r','e','3','D','N','o','w','A','F','e','a','t','u','r','e','6','4','B','i','t','F','e','a','t','u','r','e','A','D','X','F','e','a','t','u','r','e','A','E','S','F','e','a','t','u','r','e','A','M','X','B','F','1','6','F','e','a','t','u','r','e','A','M','X','I','N','T','8','F','e','a','t','u','r','e','A','M','X','T','I','L','E','F','e','a','t','u','r','e','A','V','X','F','e','a','t','u','r','e','A','V','X','2','F','e','a','t','u','r','e','A','V','X','5','1','2','F','e','a','t','u','r','e','A','V','X','V','N','N','I','F','e','a','t','u','r','e','B','F','1','6','F','e','a','t','u','r','e','B','I','T','A','L','G','F','e','a','t','u','r','e','B','M','I','F','e','a','t','u','r','e','B','M','I','2','F','e','a','t','u','r','e','B','W','I','F','e','a','t','u','r','e','C','D','I','F','e','a','t','u','r','e','C','L','D','E','M','O','T','E','F','e','a','t','u','r','e','C','L','F','L','U','S','H','O','P','T','F','e','a','t','u','r','e','C','L','W','B','F','e','a','t','u','r','e','C','L','Z','E','R','O','F','e','a','t','u','r','e','C','M','O','V','F','e','a','t','u','r','e','C','M','P','X','C','H','G','1','6','B','F','e','a','t','u','r','e','C','M','P','X','C','H','G','8','B','F','e','a','t','u','r','e','C','R','C','3','2','F','e','a','t','u','r','e','D','Q','I','F','e','a','t','u','r','e','E','N','Q','C','M','D','F','e','a','t','u','r','e','E','R','I','F','e','a','t','u','r','e','E','R','M','S','B','F','e','a','t','u','r','e','F','1','6','C','F','e','a','t','u','r','e','F','M','A','F','e','a','t','u','r','e','F','M','A','4','F','e','a','t','u','r','e','F','P','1','6','F','e','a','t','u','r','e','F','S','G','S','B','a','s','e','F','e','a','t','u','r','e','F','S','R','M','F','e','a','t','u','r','e','F','X','S','R','F','e','a','t','u','r','e','G','F','N','I','F','e','a','t','u','r','e','H','R','E','S','E','T','F','e','a','t','u','r','e','I','F','M','A','F','e','a','t','u','r','e','I','N','V','P','C','I','D','F','e','a','t','u','r','e','K','L','F','e','a','t','u','r','e','L','A','H','F','S','A','H','F','F','e','a','t','u','r','e','L','V','I','C','o','n','t','r','o','l','F','l','o','w','I','n','t','e','g','r','i','t','y','F','e','a','t','u','r','e','L','V','I','L','o','a','d','H','a','r','d','e','n','i','n','g','F','e','a','t','u','r','e','L','W','P','F','e','a','t','u','r','e','L','Z','C','N','T','F','e','a','t','u','r','e','M','M','X','F','e','a','t','u','r','e','M','O','V','B','E','F','e','a','t','u','r','e','M','O','V','D','I','R','6','4','B','F','e','a','t','u','r','e','M','O','V','D','I','R','I','F','e','a','t','u','r','e','M','W','A','I','T','X','F','e','a','t','u','r','e','N','O','P','L','F','e','a','t','u','r','e','P','C','L','M','U','L','F','e','a','t','u','r','e','P','C','O','N','F','I','G','F','e','a','t','u','r','e','P','F','I','F','e','a','t','u','r','e','P','K','U','F','e','a','t','u','r','e','P','O','P','C','N','T','F','e','a','t','u','r','e','P','R','E','F','E','T','C','H','W','T','1','F','e','a','t','u','r','e','P','R','F','C','H','W','F','e','a','t','u','r','e','P','T','W','R','I','T','E','F','e','a','t','u','r','e','R','D','P','I','D','F','e','a','t','u','r','e','R','D','R','A','N','D','F','e','a','t','u','r','e','R','D','S','E','E','D','F','e','a','t','u','r','e','R','T','M','F','e','a','t','u','r','e','R','e','t','p','o','l','i','n','e','F','e','a','t','u','r','e','R','e','t','p','o','l','i','n','e','E','x','t','e','r','n','a','l','T','h','u','n','k','F','e','a','t','u','r','e','R','e','t','p','o','l','i','n','e','I','n','d','i','r','e','c','t','B','r','a','n','c','h','e','s','F','e','a','t','u','r','e','R','e','t','p','o','l','i','n','e','I','n','d','i','r','e','c','t','C','a','l','l','s','F','e','a','t','u','r','e','S','E','R','I','A','L','I','Z','E','F','e','a','t','u','r','e','S','G','X','F','e','a','t','u','r','e','S','H','A','F','e','a','t','u','r','e','S','H','S','T','K','F','e','a','t','u','r','e','S','S','E','1','F','e','a','t','u','r','e','S','S','E','2','F','e','a','t','u','r','e','S','S','E','3','F','e','a','t','u','r','e','S','S','E','4','1','F','e','a','t','u','r','e','S','S','E','4','2','F','e','a','t','u','r','e','S','S','E','4','A','F','e','a','t','u','r','e','S','S','E','U','n','a','l','i','g','n','e','d','M','e','m','F','e','a','t','u','r','e','S','S','S','E','3','F','e','a','t','u','r','e','S','o','f','t','F','l','o','a','t','F','e','a','t','u','r','e','S','p','e','c','u','l','a','t','i','v','e','E','x','e','c','u','t','i','o','n','S','i','d','e','E','f','f','e','c','t','S','u','p','p','r','e','s','s','i','o','n','F','e','a','t','u','r','e','T','B','M','F','e','a','t','u','r','e','T','S','X','L','D','T','R','K','F','e','a','t','u','r','e','T','a','g','g','e','d','G','l','o','b','a','l','s','F','e','a','t','u','r','e','U','I','N','T','R','F','e','a','t','u','r','e','U','s','e','A','A','F','e','a','t','u','r','e','V','A','E','S','F','e','a','t','u','r','e','V','B','M','I','F','e','a','t','u','r','e','V','B','M','I','2','F','e','a','t','u','r','e','V','L','X','F','e','a','t','u','r','e','V','N','N','I','F','e','a','t','u','r','e','V','P','2','I','N','T','E','R','S','E','C','T','F','e','a','t','u','r','e','V','P','C','L','M','U','L','Q','D','Q','F','e','a','t','u','r','e','V','P','O','P','C','N','T','D','Q','F','e','a','t','u','r','e','W','A','I','T','P','K','G','F','e','a','t','u','r','e','W','B','N','O','I','N','V','D','F','e','a','t','u','r','e','W','I','D','E','K','L','F','e','a','t','u','r','e','X','8','7','F','e','a','t','u','r','e','X','O','P','F','e','a','t','u','r','e','X','S','A','V','E','F','e','a','t','u','r','e','X','S','A','V','E','C','F','e','a','t','u','r','e','X','S','A','V','E','O','P','T','F','e','a','t','u','r','e','X','S','A','V','E','S','M','o','d','e','1','6','B','i','t','M','o','d','e','3','2','B','i','t','M','o','d','e','6','4','B','i','t','P','r','o','c','I','n','t','e','l','A','t','o','m','T','u','n','i','n','g','B','r','a','n','c','h','F','u','s','i','o','n','T','u','n','i','n','g','F','a','s','t','1','1','B','y','t','e','N','O','P','T','u','n','i','n','g','F','a','s','t','1','5','B','y','t','e','N','O','P','T','u','n','i','n','g','F','a','s','t','7','B','y','t','e','N','O','P','T','u','n','i','n','g','F','a','s','t','B','E','X','T','R','T','u','n','i','n','g','F','a','s','t','G','a','t','h','e','r','T','u','n','i','n','g','F','a','s','t','H','o','r','i','z','o','n','t','a','l','O','p','s','T','u','n','i','n','g','F','a','s','t','L','Z','C','N','T','T','u','n','i','n','g','F','a','s','t','M','O','V','B','E','T','u','n','i','n','g','F','a','s','t','S','H','L','D','R','o','t','a','t','e','T','u','n','i','n','g','F','a','s','t','S','c','a','l','a','r','F','S','Q','R','T','T','u','n','i','n','g','F','a','s','t','S','c','a','l','a','r','S','h','i','f','t','M','a','s','k','s','T','u','n','i','n','g','F','a','s','t','V','a','r','i','a','b','l','e','C','r','o','s','s','L','a','n','e','S','h','u','f','f','l','e','T','u','n','i','n','g','F','a','s','t','V','a','r','i','a','b','l','e','P','e','r','L','a','n','e','S','h','u','f','f','l','e','T','u','n','i','n','g','F','a','s','t','V','e','c','t','o','r','F','S','Q','R','T','T','u','n','i','n','g','F','a','s','t','V','e','c','t','o','r','S','h','i','f','t','M','a','s','k','s','T','u','n','i','n','g','I','n','s','e','r','t','V','Z','E','R','O','U','P','P','E','R','T','u','n','i','n','g','L','E','A','F','o','r','S','P','T','u','n','i','n','g','L','E','A','U','s','e','s','A','G','T','u','n','i','n','g','L','Z','C','N','T','F','a','l','s','e','D','e','p','s','T','u','n','i','n','g','M','a','c','r','o','F','u','s','i','o','n','T','u','n','i','n','g','P','O','P','C','N','T','F','a','l','s','e','D','e','p','s','T','u','n','i','n','g','P','a','d','S','h','o','r','t','F','u','n','c','t','i','o','n','s','T','u','n','i','n','g','P','r','e','f','e','r','1','2','8','B','i','t','T','u','n','i','n','g','P','r','e','f','e','r','2','5','6','B','i','t','T','u','n','i','n','g','P','r','e','f','e','r','M','a','s','k','R','e','g','i','s','t','e','r','s','T','u','n','i','n','g','S','l','o','w','3','O','p','s','L','E','A','T','u','n','i','n','g','S','l','o','w','D','i','v','i','d','e','3','2','T','u','n','i','n','g','S','l','o','w','D','i','v','i','d','e','6','4','T','u','n','i','n','g','S','l','o','w','I','n','c','D','e','c','T','u','n','i','n','g','S','l','o','w','L','E','A','T','u','n','i','n','g','S','l','o','w','P','M','A','D','D','W','D','T','u','n','i','n','g','S','l','o','w','P','M','U','L','L','D','T','u','n','i','n','g','S','l','o','w','S','H','L','D','T','u','n','i','n','g','S','l','o','w','T','w','o','M','e','m','O','p','s','T','u','n','i','n','g','S','l','o','w','U','A','M','e','m','1','6','T','u','n','i','n','g','S','l','o','w','U','A','M','e','m','3','2','T','u','n','i','n','g','U','s','e','G','L','M','D','i','v','S','q','r','t','C','o','s','t','s','T','u','n','i','n','g','U','s','e','S','L','M','A','r','i','t','h','C','o','s','t','s',};
    }
}
