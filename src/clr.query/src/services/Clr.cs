//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class Clr
    {
        [MethodImpl(Inline), Op]
        public static FieldInfo field(Module src, EcmaToken token)
            => src.ResolveField((int)token);

        [MethodImpl(Inline), Op]
        public static FieldInfo field(Type type, string name)
            => type.GetField(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        [MethodImpl(Inline), Op]
        public static MethodBase method(Module src, EcmaToken token)
            => src.ResolveMethod((int)token);

        [MethodImpl(Inline), Op]
        public static MethodInfo method(Type type, string name)
            => type.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        [MethodImpl(Inline), Op]
        public static ClrFieldAdapter adapt(FieldInfo src)
            => src;

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrTypeAdapter> adapt(Type[] src)
            => adapt<Type,ClrTypeAdapter>(src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrFieldAdapter> adapt(FieldInfo[] src)
            => adapt<FieldInfo,ClrFieldAdapter>(src);

        [MethodImpl(Inline), Op]
        internal static ReadOnlySpan<V> adapt<S,V>(S[] src)
            => recover<S,V>(@readonly(src));
    }
}