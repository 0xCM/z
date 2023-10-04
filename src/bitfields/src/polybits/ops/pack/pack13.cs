//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class PolyBits
{
    [MethodImpl(Inline), Op]
    public static num13 pack(num2 a, num11 b)
        => (num13)((uint)a | (uint)b << num2.Width);

    [MethodImpl(Inline), Op]
    public static num13 pack(num9 a, num4 b)
        => (num13)((uint)a |((uint)b << num9.Width));
}
