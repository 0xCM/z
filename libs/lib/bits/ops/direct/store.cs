//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static math;

    partial class bits
    {
        [MethodImpl(Inline), Op]
        public static ref byte store(in byte src, byte min, byte max,  ref byte dst)
        {
            dst = or(dst, sll(src, u8(max - min + 1)));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ushort store(in ushort src, byte min, byte max, ref ushort dst)
        {
            dst = or(dst, sll(src, u8(max - min + 1)));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref uint store(in uint src, byte min, byte max, ref uint dst)
        {
            dst = or(dst, sll(src, u8(max - min + 1)));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ulong store(in ulong src, byte min, byte max, ref ulong dst)
        {
            dst = or(dst, sll(src, u8(max - min + 1)));
            return ref dst;
        }
    }
}