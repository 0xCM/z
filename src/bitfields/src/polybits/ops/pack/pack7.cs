//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class PolyBits
{
    [MethodImpl(Inline), Op]
    public static num7 pack(num3 a, num4 b)
        => (num7)((uint)a | (uint)b << num3.Width);

    [MethodImpl(Inline), Op]
    public static num7 pack(num5 a, num2 b)
        => (num7)((uint)a | (uint)b << num5.Width);

    [MethodImpl(Inline), Op]
    public static num7 pack(num2 a, num5 b)
        => (num7)((uint)a | (uint)b << num2.Width);
}
