//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PolyBits
    {
        [MethodImpl(Inline), Op]
        public static num12 pack(num2 a, num10 b)
            => (num12)((uint)a | (uint)b << num2.Width);

        [MethodImpl(Inline), Op]
        public static num12 pack(num3 a, num9 b)
            => (num12)((uint)a |((uint)b << num3.Width));

        [MethodImpl(Inline), Op]
        public static num12 pack(num9 a, num3 b)
            => (num12)((uint)a |((uint)b << num9.Width));
    }
}