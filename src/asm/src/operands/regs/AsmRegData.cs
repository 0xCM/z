// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2023
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0.Asm;

// using static sys;
// using static NativeSizeCode;
// using static RegClassCode;
// using static RegIndexCode;
// using static RegFacets;
// using static AsmRegBits;

// [ApiHost]
// public readonly struct AsmRegData
// {
//     [MethodImpl(Inline), Op]
//     public static uint regops(RegClassCode @class, NativeSizeCode w, Span<RegOp> dst)
//     {
//         ref var r = ref first(dst);
//         var count = regcount(@class);
//         var counter = 0u;
//         for(var i=0; i<count; i++)
//             seek(r,counter++) = reg(w, @class, (RegIndexCode)i);
//         return counter;
//     }

//     [MethodImpl(Inline), Op]
//     public static byte regcount(RegClassCode @class)
//         => skip(RegClassCounts, (byte)@class);

//     [MethodImpl(Inline), Op]
//     public static ReadOnlySpan<NativeSizeCode> widths()
//         => RegWidthCodes;

//     [MethodImpl(Inline), Op]
//     public static ReadOnlySpan<RegClassCode> classes()
//         => RegClasses;

//     [MethodImpl(Inline), Op]
//     public static ReadOnlySpan<RegIndexCode> indices()
//         => RegIndexCodes;

//     internal static ReadOnlySpan<byte> RegClassCounts
//         => new byte[ClassCount]{
//             64,     // GP (no hi)
//             8,      // MASK
//             32,     // XMM
//             32,     // YMM
//             32,     // ZMM
//             8,      // MMX
//             6,      // SEG
//             3,      // FLAG
//             8,      // CR
//             1,      // XCR
//             8,      // DB
//             8,      // ST
//             4,      // BND
//             3,      // SPTR
//             3,      // IPTR
//             8,      // TR
//             8,      // TMM
//         };

//     internal static ReadOnlySpan<RegClassCode> RegClasses
//         => new RegClassCode[ClassCount]
//             {
//                 GP,
//                 MASK,
//                 XMM,
//                 YMM,
//                 ZMM,
//                 MMX,
//                 SEG,
//                 FLAG,
//                 CR,
//                 XCR,
//                 DB,
//                 ST,
//                 BND,
//                 SPTR,
//                 IPTR,
//                 TR,
//                 TMM
//             };

//     internal static ReadOnlySpan<NativeSizeCode> RegWidthCodes
//         => new NativeSizeCode[WidthCount]
//         {
//             W8,
//             W16,
//             W32,
//             W64,
//             W128,
//             W256,
//             W512,
//             W80,
//         };

//     internal static ReadOnlySpan<RegIndexCode> RegIndexCodes
//         => new RegIndexCode[IndexCount]
//         {
//             r0,
//             r1,
//             r2,
//             r3,
//             r4,
//             r5,
//             r6,
//             r7,
//             r8,
//             r9,
//             r10,
//             r11,
//             r12,
//             r13,
//             r14,
//             r15,
//             r16,
//             r17,
//             r18,
//             r19,
//             r20,
//             r21,
//             r22,
//             r23,
//             r24,
//             r25,
//             r26,
//             r27,
//             r28,
//             r29,
//             r30,
//             r31
//         };
// }
