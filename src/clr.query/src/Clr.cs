//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class Clr
    {
        /// <summary>
        /// Defines a <see cref='ClrModuleAdapter'/> over a <see cref='Module'/>
        /// </summary>
        /// <param name="src">The source module</param>
        /// <summary>
        /// Defines a <see cref='ClrFieldAdapter'/> over a <see cref='FieldInfo'/>
        /// </summary>
        /// <param name="src">The source module</param>
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