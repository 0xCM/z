//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[ApiHost]
public class VLut
{
    [MethodImpl(Inline), Init]
    public static VLut16 init(Vector128<byte> src)
        => new (src);

    [MethodImpl(Inline), Init]
    public static VLut16 init(ReadOnlySpan<byte> src, N16 n)
        => new (src);

    [MethodImpl(Inline), Init]
    public static VLut32 init(Vector256<byte> src)
        => new (src);

    [MethodImpl(Inline), Init]
    public static VLut32 init(ReadOnlySpan<byte> src, N32 n)
        => new (src);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> select(VLut16 lut, Vector128<byte> items)
        => vcpu.vshuf16x8(items, lut.Mask);

    [MethodImpl(Inline), Op]
    public static Vector256<byte> select(VLut32 lut, Vector256<byte> items)
        => vcpu.vshuf32x8(items, lut.Mask);
}
