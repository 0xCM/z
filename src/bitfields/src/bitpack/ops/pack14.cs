//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitPack
{
    [MethodImpl(Inline), Op]
    public static num14 pack(num2 a, num12 b)
        => (num14)((uint)a | ((uint)b << num2.Width));

    [MethodImpl(Inline), Op]
    public static num14 pack(num9 a, num5 b)
        => (num14)((uint)a |( (uint)b << num9.Width));
}
