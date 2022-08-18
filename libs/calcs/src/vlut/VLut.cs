//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class VLut
    {
        [MethodImpl(Inline), Init]
        public static VLut16 init(Vector128<byte> src)
            => new VLut16(src);

        [MethodImpl(Inline), Init]
        public static VLut16 init(ReadOnlySpan<byte> src, N16 n)
            => new VLut16(src);

        [MethodImpl(Inline), Init]
        public static VLut16 init(in SpanBlock128<byte> src)
            => new VLut16(src);

        [MethodImpl(Inline), Init]
        public static VLut32 init(Vector256<byte> src)
            => new VLut32(src);

        [MethodImpl(Inline), Init]
        public static VLut32 init(ReadOnlySpan<byte> src, N32 n)
            => new VLut32(src);

        [MethodImpl(Inline), Init]
        public static VLut32 init(in SpanBlock256<byte> src)
            => new VLut32(src);

        [MethodImpl(Inline), Op]
        public static Vector128<byte> select(VLut16 lut, Vector128<byte> items)
            => cpu.vshuf16x8(items, lut.Mask);

        [MethodImpl(Inline), Op]
        public static Vector256<byte> select(VLut32 lut, Vector256<byte> items)
            => cpu.vshuf32x8(items, lut.Mask);
    }
}