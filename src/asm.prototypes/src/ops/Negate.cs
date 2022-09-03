//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.Intrinsics;

    using static core;
    using static Root;

    partial struct AsmPrototypes
    {
        [ApiHost(prototypes + "negate")]
        public readonly struct Negate
        {
            [Op]
            public static byte negate_8u(byte src)
                => math.negate(src);

            [Op]
            public static ushort negate_16u(ushort src)
                => math.negate(src);

            [Op]
            public static uint negate_32u(uint src)
                => math.negate(src);

            [Op]
            public static ulong negate_64u(ulong src)
                => math.negate(src);

            [Op]
            public static int negate_32i(int src)
                => math.negate(src);

            [Op]
            public static long negate_64i(long src)
                => math.negate(src);

            [Op]
            public static unsafe void negate_p8u(byte* pSrc)
                => *pSrc = math.negate(*pSrc);

            [Op]
            public static unsafe void negate_p16u(ushort* pSrc)
                => *pSrc = math.negate(*pSrc);

            [Op]
            public static unsafe void negate_p32u(uint* pSrc)
                => *pSrc = math.negate(*pSrc);

            [Op]
            public static unsafe void negate_p64u(ulong* pSrc)
                => *pSrc = math.negate(*pSrc);

            [Op]
            public static unsafe void negate_p32i(int* pSrc)
                => *pSrc = math.negate(*pSrc);

            [Op]
            public static unsafe void negate_p64i(long* pSrc)
                => *pSrc = math.negate(*pSrc);

            [Op]
            public static unsafe void negate_p8u(byte* pSrc, byte scale, uint index)
                => *(pSrc + scale*index) = math.negate(*pSrc);

            [Op]
            public static unsafe void negate_p8u(ushort* pSrc, byte scale, uint index)
                => *(pSrc + scale*index) = math.negate(*pSrc);

            [Op]
            public static unsafe void negate_p32u(uint* pSrc, byte scale, uint index)
                => *(pSrc + scale*index) = math.negate(*pSrc);

            [Op]
            public static unsafe void negate_p32u(ulong* pSrc, byte scale, uint index)
                => *(pSrc + scale*index) = math.negate(*pSrc);
        }
    }
}