//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ClrLiterals
    {
        [MethodImpl(Inline), Op]
        public static string name(FieldInfo src)
            => src.Name;

        [MethodImpl(Inline), Op]
        public static string name(Type src)
            => src.Name;

        [MethodImpl(Inline), Op]
        public static Label name(PropertyInfo src)
            => src.Name;

        [MethodImpl(Inline), Op]
        public static Label name(MethodBase src)
            => src.Name;
    }
}