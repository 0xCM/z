//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial struct AsmPrototypes
    {
        [ApiHost(prototypes + "statics")]
        public unsafe struct Statics
        {
            [FixedAddressValueType]
            static Index<ulong> Store0x64;

            [FixedAddressValueType]
            static Index<ulong> Store1x64;

            static MemoryAddress SourceAddress;

            static MemoryAddress TargetAddress;

            static ulong[] Source = new ulong[16]{0x0,0x1,0x2,0x3,0x4,0x5,0x6,0x7,0x8,0x9,0xa,0xb,0xc,0xd,0xe,0xf};

            static ulong[] Target = new ulong[256];

            [Op]
            static void init()
            {
                Store0x64 = Source;
                Store1x64 = Target;
                SourceAddress = address(Store0x64);
                TargetAddress = address(Store1x64);
            }

            static Statics()
            {
                init();
            }
        }
    }
}