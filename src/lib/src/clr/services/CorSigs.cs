//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// These functions follow https://github.com/dotnet/coreclr/blob/e879597385221df7131042d1e0830b87f7632a01/src/inc/cor.h#L2090-L2514
    /// </summary>
    [ApiHost]
    public readonly unsafe struct CorSigs
    {
        /// <summary>
        /// Computes the size of a compressed integer in a signature
        /// </summary>
        /// <param name="pSrc">A pointer to the source byte</param>
        [MethodImpl(Inline), Op]
        public static byte size(byte* pSrc)
        {
            if( (*pSrc & 0x80) == 0 )
                return 1;
            else if((*pSrc & 0xC0) == 0x80)
                return 2;
            else
                return 4;
        }

        [MethodImpl(Inline), Op]
        public static uint expand(ref byte* pSrc)
        {
            var result = 0u;
            if((*pSrc & 0x80) == 0)
                result = *pSrc++;
            else if ((*pSrc & 0xC0) == 0x80)
            {
                result = (uint)((*pSrc++ & 0x3f) << 8);
                result |= *pSrc++;
            }
            else
            {
                result = (*pSrc++ & 0x1fu) << 24;
                result |= (uint)(*pSrc++ << 16);
                result |= (uint)(*pSrc++ << 8);
                result |= *pSrc++;
            }
            return result;
        }

        [Op]
        public static unsafe bool expand(byte* pSrc, uint srcSize, ref uint* pDst, out uint dstSize)
        {
            var result = true;

            if ((*pSrc & 0x80) == 0x00)
            {
                if (srcSize < 1)
                {
                    *pDst = 0;
                    dstSize = 0;
                    result = false;
                }
                else
                {
                    *pDst = *pSrc;
                    dstSize = 1;
                }
            }
            else if ((*pSrc & 0xC0) == 0x80)
            {
                if (srcSize < 2)
                {
                    *pDst = 0;
                    dstSize = 0;
                    result = false;
                }
                else
                {
                    *pDst = (uint)(((*pSrc & 0x3f) << 8 | *(pSrc+1)));
                    dstSize = 2;
                }
            }
            else if ((*pSrc & 0xE0) == 0xC0)
            {
                if (srcSize < 4)
                {
                    *pDst = 0;
                    dstSize = 0;
                    result = false;
                }
                else
                {
                    *pDst = (uint)(((*pSrc & 0x1f) << 24 | *(pSrc+1) << 16 | *(pSrc+2) << 8 | *(pSrc+3)));
                    dstSize = 4;
                }
            }
            else
            {
                *pDst = 0;
                dstSize = 0;
                result = false;
            }

            return result;
        }
    }

    public unsafe readonly struct CorSig
    {
        readonly byte* Data;

        readonly ushort Size;

        [MethodImpl(Inline)]
        public CorSig(byte* pSrc, ushort size)
        {
            Data = pSrc;
            Size = size;
        }
    }
}