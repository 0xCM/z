//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class PolyBits
{
    [MethodImpl(Inline), Op]
    public static num32 pack(num16 a, num16 b)
        => (num32)((uint)a | (uint)b << num16.Width);

    [MethodImpl(Inline), Op]
    public static num32 pack(num3 a, num7 b, num2 c, num16 d)
        => (num32)a
        | ((num32)b << num3.Width)
        | ((num32)c << (num3.Width + num7.Width))
        | (num32)d << (num3.Width + num7.Width + num2.Width);

    [MethodImpl(Inline), Op]
    public static num32 pack(num8 a0, num8 a1, num8 a2, num8 a3)
        => (num32)a0 | ((num32)a1 << (num8.Width)) |((num32)a2 << (num8.Width*2)) | ((num32)a3 << (num8.Width*3));
}
