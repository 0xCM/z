//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static ClrMemberName membername(string src)
            => new (src);

        [MethodImpl(Inline), Op]
        public static ClrAssemblyName name(Assembly src)
            => new (src);

        [MethodImpl(Inline), Op]
        public static ClrMemberName name(FieldInfo src)
            => new (src);

        [MethodImpl(Inline), Op]
        public static ClrMemberName name(PropertyInfo src)
            => new (src);

        [MethodImpl(Inline), Op]
        public static ClrMemberName name(MethodInfo src)
            => new (src);

        [MethodImpl(Inline), Op]
        public static ClrMemberName name(EventInfo src)
            => new (src);

        [MethodImpl(Inline), Op]
        public static ClrTypeName name(Type src)
            => new (src);
    }
}