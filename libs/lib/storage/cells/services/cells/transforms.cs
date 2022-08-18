//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Cells
    {
        [MethodImpl(Inline), Op]
        public static ref Cell8 lo8(in Cell16 src)
            => ref @as<Cell16,Cell8>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell8 lo8(in Cell32 src)
            => ref @as<Cell32,Cell8>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell8 lo8(in Cell128 src)
            => ref @as<Cell128,Cell8>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell8 lo8(in Cell64 src)
            => ref @as<Cell64,Cell8>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell8 lo8(in Cell512 src)
            => ref @as<Cell512,Cell8>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell8 lo8(in Cell256 src)
            => ref @as<Cell256,Cell8>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell256 lo256(in Cell512 src)
            => ref @as<Cell512,Cell256>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell128 lo128(in Cell512 src)
            => ref @as<Cell512,Cell128>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell64 lo64(in Cell512 src)
            => ref @as<Cell512,Cell64>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell32 lo32(in Cell512 src)
            => ref @as<Cell512,Cell32>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell16 lo16(in Cell512 src)
            => ref @as<Cell512,Cell16>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell16 lo16(in Cell256 src)
            => ref @as<Cell256,Cell16>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell16 lo16(in Cell128 src)
            => ref @as<Cell128,Cell16>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell16 lo16(in Cell64 src)
            => ref @as<Cell64,Cell16>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell16 lo16(in Cell32 src)
            => ref @as<Cell32,Cell16>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell128 lo128(in Cell256 src)
            => ref @as<Cell256,Cell128>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell64 lo64(in Cell256 src)
            => ref @as<Cell256,Cell64>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell32 lo32(in Cell256 src)
            => ref @as<Cell256,Cell32>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell64 lo64(in Cell128 src)
            => ref @as<Cell128,Cell64>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell32 lo32(in Cell128 src)
            => ref @as<Cell128,Cell32>(src);

        [MethodImpl(Inline), Op]
        public static ref Cell32 lo32(in Cell64 src)
            => ref @as<Cell64,Cell32>(src);
    }
}