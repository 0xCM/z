//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmPrototypes
    {
        [ApiHost(prototypes + "dec")]
        public unsafe readonly struct Dec
        {
           [Op]
            public static void dec_p8u(byte* pSrc)
                => *pSrc = math.dec(*pSrc);

            [Op]
            public static void dec_p16u(ushort* pSrc)
                => *pSrc = math.dec(*pSrc);

            [Op]
            public static void dec_p32u(uint* pSrc)
                => *pSrc = math.dec(*pSrc);

            [Op]
            public static void dec_p64u(ulong* pSrc)
                => *pSrc = math.dec(*pSrc);
        }
    }
}
