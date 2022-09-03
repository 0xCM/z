//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PolyBits
    {
        [MethodImpl(Inline), Op]
        public static num5 pack(bit a, num4 b)
            => (num5)((uint)a | (uint)b << 1);

        [MethodImpl(Inline), Op]
        public static num5 pack(num3 a, num2 b)
            => (num5)((uint)a | (uint)b << num3.Width);

        [MethodImpl(Inline), Op]
        public static num5 pack(num2 a, num3 b)
            => (num5)((uint)a | (uint)b << num2.Width);
    }
}