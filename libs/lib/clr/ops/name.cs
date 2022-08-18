//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static ClrMemberName membername(string src)
            => new ClrMemberName(src);

        [MethodImpl(Inline), Op]
        public static ClrAssemblyName name(Assembly src)
            => new ClrAssemblyName(src);

        [MethodImpl(Inline), Op]
        public static ClrMemberName name(FieldInfo src)
            => new ClrMemberName(src);

        [MethodImpl(Inline), Op]
        public static ClrMemberName name(PropertyInfo src)
            => new ClrMemberName(src);

        [MethodImpl(Inline), Op]
        public static ClrMemberName name(MethodInfo src)
            => new ClrMemberName(src);

        [MethodImpl(Inline), Op]
        public static ClrMemberName name(EventInfo src)
            => new ClrMemberName(src);

        [MethodImpl(Inline), Op]
        public static ClrTypeName name(Type src)
            => new ClrTypeName(src);
    }
}