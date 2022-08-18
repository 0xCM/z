//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    unsafe partial  class Bytes
    {
        [MethodImpl(Inline), Op]
        public static ref ByteBlock16 copy(ReadOnlySpan<byte> src, ref ByteBlock16 dst)
        {
            const ushort Size = ByteBlock16.Size;
            var w = w128;
            ref var target = ref u8(dst);
            var size = max(src.Length, Size);
            var data = slice(src, 0, size);
            if(size == Size)
                cpu.vstore(cpu.vload(w, data), ref target);
            else
                Bytes.copy(data,  ref target);

            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ByteBlock32 copy(ReadOnlySpan<byte> src, ref ByteBlock32 dst)
        {
            const ushort Size = ByteBlock32.Size;
            var w = w256;
            ref var target = ref u8(dst);
            var size = max(src.Length, Size);
            var data = slice(src, 0, size);
            if(size == Size)
                cpu.vstore(cpu.vload(w, data), ref target);
            else
                Bytes.copy(data,  ref target);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ByteBlock64 copy(ReadOnlySpan<byte> src, ref ByteBlock64 dst)
        {
            ref var lo = ref @as<ByteBlock64,ByteBlock32>(dst);
            ref var hi = ref seek(lo,1);
            copy(src, ref lo);
            copy(slice(src,32), ref hi);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ByteBlock128 copy(ReadOnlySpan<byte> src, ref ByteBlock128 dst)
        {
            const ushort Block0 = 0*32;
            const ushort Block1 = 1*32;
            const ushort Block2 = 2*32;
            const ushort Block3 = 3*32;

            var v0 = cpu.vload(w256, skip(src,Block0));
            cpu.vstore(v0, ref seek(u8(dst), Block0));

            v0 = cpu.vload(w256, skip(src, Block1));
            cpu.vstore(v0, ref seek(u8(dst), Block1));

            v0 = cpu.vload(w256, skip(src, Block2));
            cpu.vstore(v0, ref seek(u8(dst), Block2));

            v0 = cpu.vload(w256, skip(src, Block3));
            cpu.vstore(v0, ref seek(u8(dst), Block3));

            return ref dst;
        }
    }
}