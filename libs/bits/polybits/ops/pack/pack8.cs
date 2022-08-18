//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PolyBits
    {
        [MethodImpl(Inline), Op]
        public static num8 pack(num2 a, num6 b)
            => (num8)((uint)a | (uint)b << num2.Width);

        [MethodImpl(Inline), Op]
        public static num8 pack(num3 a, num5 b)
            => (num8)((uint)a | (uint)b << num3.Width);

        [MethodImpl(Inline), Op]
        public static num8 pack(num4 a, num4 b)
            => (num8)((uint)a | (uint)b << num4.Width);

        [MethodImpl(Inline), Op]
        public static num8 pack(num5 a, num3 b)
            => (num8)((uint)a | (uint)b << num5.Width);

        [MethodImpl(Inline), Op]
        public static num8 pack(num6 a, bit b)
            => (num8)a | ((num8)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num8 pack(num6 a, num2 b)
            => (num8)a | ((num8)b << num6.Width);
    }
}