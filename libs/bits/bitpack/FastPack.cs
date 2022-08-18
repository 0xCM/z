//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// J:\source\limire-SIMDCompressionAndIntersection\src\bitpacking.cpp
    /// </summary>
    [ApiHost]
    public unsafe readonly struct FastPack
    {
        [Op]
        public static void unpack(N1 n, uint* pSrc, uint* pDst)
        {
            *pDst = ((*pSrc) >> 0) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 1) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 2) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 3) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 4) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 5) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 6) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 7) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 8) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 9) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 10) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 11) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 12) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 13) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 14) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 15) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 16) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 17) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 18) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 19) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 20) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 21) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 22) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 23) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 24) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 25) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 26) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 27) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 28) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 29) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 30) & 1;
            pDst++;
            *pDst = ((*pSrc) >> 31);
        }

        [Op]
        public static unsafe void unpack(N2 n, uint* pIn, uint* pOut)
        {
            *pOut = ((*pIn) >> 0) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 2) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 4) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 6) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 8) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 10) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 12) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 14) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 16) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 18) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 20) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 22) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 24) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 26) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 28) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 30);
            ++pIn;
            pOut++;
            *pOut = ((*pIn) >> 0) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 2) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 4) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 6) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 8) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 10) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 12) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 14) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 16) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 18) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 20) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 22) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 24) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 26) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 28) % (1U << 2);
            pOut++;
            *pOut = ((*pIn) >> 30);
        }

        [Op]
        public static void unpack(N3 n, uint* pIn, uint* pOut)
        {
            *pOut = ((*pIn) >> 0) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 3) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 6) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 9) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 12) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 15) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 18) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 21) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 24) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 27) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 30);
            ++pIn;
            *pOut |= ((*pIn) % (1U << 1)) << (3 - 1);
            pOut++;
            *pOut = ((*pIn) >> 1) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 4) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 7) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 10) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 13) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 16) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 19) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 22) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 25) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 28) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 31);
            ++pIn;
            *pOut |= ((*pIn) % (1U << 2)) << (3 - 2);
            pOut++;
            *pOut = ((*pIn) >> 2) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 5) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 8) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 11) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 14) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 17) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 20) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 23) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 26) % (1U << 3);
            pOut++;
            *pOut = ((*pIn) >> 29);
        }
    }
}