//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Options), Op]
        public static object value(object src, FieldInfo field)
            => field.GetValue(src);

        [MethodImpl(Options), Op, Closures(Closure)]
        public static T value<T>(object src, FieldInfo field)
            => (T)field.GetValue(src);

        /// <summary>
        /// Reveals the natural number in bijection with a parametric type natural
        /// </summary>
        /// <param name="n">The representative, used only for method invocation type inference</param>
        /// <typeparam name="K">The natural type</typeparam>
        [MethodImpl(Inline)]
        public static ulong value<K>(K n = default)
            where K : unmanaged, ITypeNat
                => Typed.value(n);            
    }
}