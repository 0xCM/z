//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PolyBits
    {
        [MethodImpl(Inline), Op]
        public static num17 pack(num6 a, num11 b)
            => (num17)a | ((num17)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num17 pack(num16 a, num1 b)
            => (num17)((uint)a | (uint)b << num16.Width);

        [MethodImpl(Inline), Op]
        public static num17 pack(num9 a, num8 b)
            => (num17)((uint)a |((uint)b << num9.Width));
    }
}