// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
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