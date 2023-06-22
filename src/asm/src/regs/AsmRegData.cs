//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;
    using static NativeSizeCode;
    using static RegClassCode;
    using static RegIndexCode;
    using static RegFacets;
    using static AsmRegBits;

    [ApiHost]
    public readonly struct AsmRegData
    {
        [MethodImpl(Inline), Op]
        public static uint regops(RegClassCode @class, NativeSizeCode w, Span<RegOp> dst)
        {
            ref var r = ref first(dst);
            var count = regcount(@class);
            var counter = 0u;
            for(var i=0; i<count; i++)
                seek(r,counter++) = reg((NativeSizeCode)w, @class, (RegIndexCode)i);
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static byte regcount(RegClassCode @class)
            => skip(RegClassCounts, (byte)@class);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<RegOp> gp()
            => recover<RegOp>(GpRegData);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<NativeSizeCode> widths()
            => RegWidthCodes;

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<RegClassCode> classes()
            => RegClasses;

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<RegIndexCode> indices()
            => RegIndexCodes;

        internal static ReadOnlySpan<byte> RegClassCounts
            => new byte[ClassCount]{
                64,     // GP (no hi)
                8,      // MASK
                32,     // XMM
                32,     // YMM
                32,     // ZMM
                8,      // MMX
                6,      // SEG
                3,      // FLAG
                8,      // CR
                1,      // XCR
                8,      // DB
                8,      // ST
                4,      // BND
                3,      // SPTR
                3,      // IPTR
                4,      // GP8HI
                8,      // TR
                8,      // TMM
            };

        internal static ReadOnlySpan<RegClassCode> RegClasses
            => new RegClassCode[ClassCount]
                {
                    GP,
                    MASK,
                    XMM,
                    YMM,
                    ZMM,
                    MMX,
                    SEG,
                    FLAG,
                    CR,
                    XCR,
                    DB,
                    ST,
                    BND,
                    SPTR,
                    IPTR,
                    GP8HI,
                    TR,
                    TMM
                };

        internal static ReadOnlySpan<NativeSizeCode> RegWidthCodes
            => new NativeSizeCode[WidthCount]
            {
                W8,
                W16,
                W32,
                W64,
                W128,
                W256,
                W512,
                W80,
            };

        internal static ReadOnlySpan<RegIndexCode> RegIndexCodes
            => new RegIndexCode[IndexCount]
            {
                r0,
                r1,
                r2,
                r3,
                r4,
                r5,
                r6,
                r7,
                r8,
                r9,
                r10,
                r11,
                r12,
                r13,
                r14,
                r15,
                r16,
                r17,
                r18,
                r19,
                r20,
                r21,
                r22,
                r23,
                r24,
                r25,
                r26,
                r27,
                r28,
                r29,
                r30,
                r31
            };

        internal static ReadOnlySpan<byte> GpRegData
            => new byte[128]{0x23,0x00,0x22,0x00,0x21,0x00,0x20,0x00,0x23,0x04,0x22,0x04,0x21,0x04,0x20,0x04,0x23,0x08,0x22,0x08,0x21,0x08,0x20,0x08,0x23,0x0c,0x22,0x0c,0x21,0x0c,0x20,0x0c,0x23,0x10,0x22,0x10,0x21,0x10,0x20,0x10,0x23,0x14,0x22,0x14,0x21,0x14,0x20,0x14,0x23,0x18,0x22,0x18,0x21,0x18,0x20,0x18,0x23,0x1c,0x22,0x1c,0x21,0x1c,0x20,0x1c,0x23,0x20,0x22,0x20,0x21,0x20,0x20,0x20,0x23,0x24,0x22,0x24,0x21,0x24,0x20,0x24,0x23,0x28,0x22,0x28,0x21,0x28,0x20,0x28,0x23,0x2c,0x22,0x2c,0x21,0x2c,0x20,0x2c,0x23,0x30,0x22,0x30,0x21,0x30,0x20,0x30,0x23,0x34,0x22,0x34,0x21,0x34,0x20,0x34,0x23,0x38,0x22,0x38,0x21,0x38,0x20,0x38,0x23,0x3c,0x22,0x3c,0x21,0x3c,0x20,0x3c};

    }
}