//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static math;

partial class BitPack
{
    [MethodImpl(Inline), Op]
    public static num16 pack(num6 a, num10 b)
        => (num16)a | ((num16)b << num6.Width);

    [MethodImpl(Inline), Op]
    public static num16 pack(num9 a, num7 b)
        => (num16)((uint)a |((uint)b << num9.Width));

    [MethodImpl(Inline), Op]
    public static num16 pack(num8 a, num8 b)
        => (num16)a | ((num16)b << num8.Width);
}
