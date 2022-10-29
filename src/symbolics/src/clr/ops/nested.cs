//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrTypeAdapter> nested(Type src)
            => recover<Type,ClrTypeAdapter>(src.GetNestedTypes());
    }
}