//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmPrototypes
    {
        [ApiHost(prototypes + "increment")]
        public unsafe readonly struct Increment
        {
            [Op]
            public static void inc_pref8u(ref byte* pSrc)
                => pSrc++;

            [Op]
            public static void inc_pref8i(ref sbyte* pSrc)
                => pSrc++;

            [Op]
            public static void inc_pref16i(ref short* pSrc)
                => pSrc++;

            [Op]
            public static void inc_pref16u(ref ushort* pSrc)
                => pSrc++;

            [Op]
            public static void inc_pref32i(ref int* pSrc)
                => pSrc++;

            [Op]
            public static void inc_pref32u(ref uint* pSrc)
                => pSrc++;

            [Op]
            public static void inc_pref64i(ref long* pSrc)
                => pSrc++;

            [Op]
            public static void inc_pref64u(ref ulong* pSrc)
                => pSrc++;

            [Op]
            public static void inc(ref float* pSrc)
                => pSrc++;

            [Op]
            public static void inc_pref64f(ref double* pSrc)
                => pSrc++;

            [Op]
            public static void inc_pref256(ref Cell256* pSrc)
                => pSrc++;

            [Op]
            public static void inc_p8u(byte* pSrc)
                => *pSrc = math.inc(*pSrc);

            [Op]
            public static void inc_p16u(ushort* pSrc)
                => *pSrc = math.inc(*pSrc);

            [Op]
            public static void inc_p32u(uint* pSrc)
                => *pSrc = math.inc(*pSrc);

            [Op]
            public static void inc_p64u(ulong* pSrc)
                => *pSrc = math.inc(*pSrc);
        }
    }
}