//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PolyBits
    {
        [MethodImpl(Inline), Op]
        public static num3 pack(num2 a, bit b)
            => (num3)((uint)a | (uint)b << num2.Width);

        [MethodImpl(Inline), Op]
        public static num3 pack(bit a, num2 b)
            => (num3)((uint)a | (uint)b << 1);

        [MethodImpl(Inline), Op]
        public static num3 pack(bit a, bit b, bit c)
            => (num3)((uint)a | (uint)b << 1 | (uint)c << 2);
    }
}