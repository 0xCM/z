//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PolyBits
    {
        [MethodImpl(Inline), Op]
        public static num4 pack(bit a, bit b, bit c, bit d)
            => (num4)((uint)a | (uint)b << 1 | (uint)c << 2 | (uint)d << 3);

        [MethodImpl(Inline), Op]
        public static num4 pack(num2 a, num2 b)
            => (num4)((uint)a | (uint)b << num2.Width);

        [MethodImpl(Inline), Op]
        public static num4 pack(bit a, num3 b)
            => (num4)((uint)a | (uint)b << 1);

        [MethodImpl(Inline), Op]
        public static num4 pack(num3 a, bit b)
            => (num4)((uint)a | (uint)b << num3.Width);
    }
}