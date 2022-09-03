//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrTypeAdapter> types(Assembly src)
            => adapt(types(src, out var _));

        [MethodImpl(Inline), Op]
        public static Type[] types(Assembly src, out Type[] dst)
            => dst = src.GetTypes();
    }
}