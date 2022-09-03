//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SRM
    {
        [MethodImpl(Inline), Op]
        public static unsafe uint unpack(MemoryBlock src, uint offset, out ByteSize consumed)
            => unpack(src.Pointer, (uint)src.Length, offset, out consumed);

        [MethodImpl(Inline), Op]
        public static unsafe uint unpack(byte* pSrc, uint length, uint offset, out ByteSize consumed)
        {
            byte* ptr = pSrc + offset;
            var limit = length - offset;
            consumed = 0;

            if (limit == 0)
                return uint.MaxValue;

            var lead = (uint)ptr[0];
            if ((lead & 0x80) == 0)
            {
                consumed = 1;
                return lead;
            }
            else if((lead & 0x40) == 0)
            {
                if (limit >= 2)
                {
                    consumed = 2;
                    return ((lead & 0x3fu) << 8) | (uint)ptr[1];
                }
            }
            else if ((lead & 0x20) == 0)
            {
                if (limit >= 4)
                {
                    consumed = 4;
                    return ((lead & 0x1fu) << 24) | ((uint)ptr[1] << 16) | ((uint)ptr[2] << 8) | (uint)ptr[3];
                }
            }

            return uint.MaxValue;
        }
    }
}