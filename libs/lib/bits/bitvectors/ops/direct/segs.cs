//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        [MethodImpl(Inline), Op]
        public static BitVector4 seg(BitVector64 src, N4 n, byte index)
            => (BitVector4)extract(src, (byte)(index*4), 4);

        [MethodImpl(Inline), Op]
        public static BitVector64 insert(BitVector4 src, byte pos, BitVector64 dst)
        {
            var offset = pos*4;
            var mask = ~(0xFul << pos*4);
            dst &= mask;
            dst |= ((BitVector64)src) << offset;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static BitVector64 insert(BitVector4 src, N0 n, BitVector64 dst)
        {
            const byte SegWidth = 4;
            const byte SegIndex = 0;
            const byte SegOffset = SegIndex*SegWidth;
            const ulong SegMask = ~(0xFul << SegOffset);
            dst &= SegMask;
            dst |= ((BitVector64)src) << SegOffset;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static  BitVector64 insert(BitVector4 src, N1 n, BitVector64 dst)
        {
            const byte SegWidth = 4;
            const byte SegIndex = 1;
            const byte SegOffset = SegIndex*SegWidth;
            const ulong SegMask = ~(0xFul << SegOffset);
            dst &= SegMask;
            dst |= ((BitVector64)src) << SegOffset;
            return  dst;
        }

        [MethodImpl(Inline), Op]
        public static  BitVector64 insert(BitVector4 src, N2 n, BitVector64 dst)
        {
            const byte SegWidth = 4;
            const byte SegIndex = 2;
            const byte SegOffset = SegIndex*SegWidth;
            const ulong SegMask = ~(0xFul << SegOffset);
            dst &= SegMask;
            dst |= ((BitVector64)src) << SegOffset;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static BitVector64 insert(BitVector4 src, N3 n, BitVector64 dst)
        {
            const byte SegWidth = 4;
            const byte SegIndex = 3;
            const byte SegOffset = SegIndex*SegWidth;
            const ulong SegMask = ~(0xFul << SegOffset);
            dst &= SegMask;
            dst |= ((BitVector64)src) << SegOffset;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static BitVector64 insert(BitVector4 src, N4 n, BitVector64 dst)
        {
            const byte SegWidth = 4;
            const byte SegIndex = 4;
            const byte SegOffset = SegIndex*SegWidth;
            const ulong SegMask = ~(0xFul << SegOffset);
            dst &= SegMask;
            dst |= ((BitVector64)src) << SegOffset;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static BitVector64 insert(BitVector4 src, N5 n, BitVector64 dst)
        {
            const byte SegWidth = 4;
            const byte SegIndex = 5;
            const byte SegOffset = SegIndex*SegWidth;
            const ulong SegMask = ~(0xFul << SegOffset);
            dst &= SegMask;
            dst |= ((BitVector64)src) << SegOffset;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static BitVector64 insert(BitVector4 src, N6 n, BitVector64 dst)
        {
            const byte SegWidth = 4;
            const byte SegIndex = 6;
            const byte SegOffset = SegIndex*SegWidth;
            const ulong SegMask = ~(0xFul << SegOffset);
            dst &= SegMask;
            dst |= ((BitVector64)src) << SegOffset;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static BitVector64 insert(BitVector4 src, N7 n, BitVector64 dst)
        {
            const byte SegWidth = 4;
            const byte SegIndex = 7;
            const byte SegOffset = SegIndex*SegWidth;
            const ulong SegMask = ~(0xFul << SegOffset);
            dst &= SegMask;
            dst |= ((BitVector64)src) << SegOffset;
            return dst;
        }
    }
}