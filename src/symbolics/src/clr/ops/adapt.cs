//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Clr
    {
        public static ReadOnlySeq<IRuntimeMember> join<A,B>(ReadOnlySpan<A> head, ReadOnlySpan<B> tail)
            where A : IRuntimeMember
            where B : IRuntimeMember
        {
            var count = head.Length + tail.Length;
            var dst = alloc<IRuntimeMember>(count);
            var j=0;
            for(var i=0; i<head.Length; i++)
                seek(dst,j++) = skip(head,i);
            for(var i=0; i<tail.Length; i++)
                seek(dst,j++) = skip(tail,i);

            return dst;
        }

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
        /// Covers a <see cref='FieldInfo'/> sequence with r a <see cref='ClrFieldAdapter'/> sequence
        /// </summary>
        /// <param name="src">The source module</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrFieldAdapter> adapt(FieldInfo[] src)
            => adapt<FieldInfo,ClrFieldAdapter>(src);

        /// <summary>
        /// Covers a <see cref='PropertyInfo'/> with a <see cref='ClrPropertyAdapter'/>
        /// </summary>
        /// <param name="src">The source module</param>
        [MethodImpl(Inline), Op]
        public static ClrPropertyAdapter adapt(PropertyInfo src)
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
        internal static ReadOnlySpan<V> adapt<S,V>(S[] src)
            => recover<S,V>(@readonly(src));
    }
}