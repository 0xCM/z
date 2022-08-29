//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ByteBlocks
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> inflate16u(in ByteBlock4 src)
        {
            var storage = 0ul;
            var input = u32(src);
            ref var dst = ref @as<ulong,char>(storage);
            seek(dst, 0) = (char)(byte)(input >> 0);
            seek(dst, 1) = (char)(byte)(input >> 8);
            seek(dst, 2) = (char)(byte)(input >> 16);
            seek(dst, 3) = (char)(byte)(input >> 24);
            return cover(dst, 4);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> inflate16u(in ByteBlock8 src)
            => recover<char>(bytes(cpu.vlo(vpack.vinflate256x16u(cpu.vbytes(w128, u64(src))))));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> inflate16u(in ByteBlock16 src)
            => recover<char>(bytes(cpu.vlo(vpack.vinflate256x16u(cpu.vbytes(w128, u64(src))))));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> inflate16u(in ByteBlock32 src)
        {
            var v = cpu.vload(w256, src.Bytes);
            var lo = vpack.vinflatelo256x16u(v);
            var hi = vpack.vinflatehi256x16u(v);
            return recover<char>(core.bytes(new V256x2(lo,hi)));
        }
    }
}