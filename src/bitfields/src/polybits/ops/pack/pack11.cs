//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class PolyBits
{
    [MethodImpl(Inline), Op]
    public static num11 pack(num2 a, num9 b)
        => (num11)((uint)a |((uint)b << num2.Width));

    [MethodImpl(Inline), Op]
    public static num11 pack(num3 a, byte b)
        => (num11)((uint)a | (uint)b << num3.Width);

    [MethodImpl(Inline), Op]
    public static num11 pack(num9 a, num2 b)
        => (num11)((uint)a |((uint)b << num9.Width));

    [MethodImpl(Inline), Op]
    public static num11 pack(bit a, bit b, num9 c)
        => (num11)((uint)a | (uint)b << 1 | (uint)c << 2);
}
