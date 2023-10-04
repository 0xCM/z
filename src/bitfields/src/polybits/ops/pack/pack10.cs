//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class PolyBits
{
    [MethodImpl(Inline), Op]
    public static num10 pack(num2 a, byte b)
        => (num10)((uint)a | (uint)b << num2.Width);

    [MethodImpl(Inline), Op]
    public static num10 pack(num5 a, num5 b)
        => (num10)((uint)a | (uint)b << num5.Width);

    [MethodImpl(Inline), Op]
    public static num10 pack(num9 a, bit b)
        => (num10)((uint)a |((uint)b << num9.Width));
}
