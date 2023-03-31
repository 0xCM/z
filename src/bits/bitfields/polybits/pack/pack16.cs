//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PolyBits
    {
        [MethodImpl(Inline), Op]
        public static num16 pack(num6 a, num3 b)
            => (num16)a | ((num16)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num6 a, num4 b)
            => (num16)a | ((num16)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num6 a, num5 b)
            => (num16)a | ((num16)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num6 a, num7 b)
            => (num16)a | ((num16)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num6 a, num8 b)
            => (num16)a | ((num16)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num6 a, num9 b)
            => (num16)a | ((num16)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num6 a, num10 b)
            => (num16)a | ((num16)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num9 a, num7 b)
            => (num16)((uint)a |((uint)b << num9.Width));

        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, bit b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, num2 b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, num3 b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, num4 b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, num5 b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, num6 b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, num7 b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, num8 b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(byte a, byte b)
            => (num16)a | ((num16)b << num8.Width);
    }
}