//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Algs;

    partial struct Clr
    {
        /// <summary>
        /// Defines a <see cref='ClrAssembly'/> over an <see cref='Assembly'/>
        /// </summary>
        /// <param name="src">The source module</param>
        [MethodImpl(Inline), Op]
        public static ClrAssembly adapt(Assembly src)
            => src;

        /// <summary>
        /// Defines a <see cref='ClrModuleAdapter'/> over a <see cref='Module'/>
        /// </summary>
        /// <param name="src">The source module</param>
        [MethodImpl(Inline), Op]
        public static ClrModuleAdapter adapt(Module src)
            => src;

        /// <summary>
        /// Defines a <see cref='ClrFieldAdapter'/> over a <see cref='FieldInfo'/>
        /// </summary>
        /// <param name="src">The source module</param>
        [MethodImpl(Inline), Op]
        public static ClrFieldAdapter adapt(FieldInfo src)
            => src;

        /// <summary>
        /// Defines a <see cref='ClrParameterAdapter'/> over the source
        /// </summary>
        /// <param name="src">The source module</param>
        [MethodImpl(Inline), Op]
        public static ClrParameterAdapter adapt(ParameterInfo src)
            => src;

        /// <summary>
        /// Defines a <see cref='ClrMethodAdapter'/> over the source
        /// </summary>
        /// <param name="src">The source module</param>
        [MethodImpl(Inline), Op]
        public static ClrMethodAdapter adapt(MethodInfo src)
            => src;

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrAssembly> adapt(Assembly[] src)
            => adapt<Assembly,ClrAssembly>(src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrTypeAdapter> adapt(Type[] src)
            => adapt<Type,ClrTypeAdapter>(src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrModuleAdapter> adapt(Module[] src)
            => adapt<Module,ClrModuleAdapter>(src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrMethodAdapter> adapt(MethodInfo[] src)
            => adapt<MethodInfo,ClrMethodAdapter>(src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrFieldAdapter> adapt(FieldInfo[] src)
            => adapt<FieldInfo,ClrFieldAdapter>(src);

        [MethodImpl(Inline), Op]
        internal static ReadOnlySpan<V> adapt<S,V>(S[] src)
            => recover<S,V>(@readonly(src));
    }
}