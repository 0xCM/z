//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Creates an untyped delegate
        /// </summary>
        /// <param name="src">The target method</param>
        /// <param name="type">The delegate type</param>
        /// <param name="host">The host instance if not static</param>
        [MethodImpl(Options), Op]
        public static Delegate @delegate(MethodInfo src, Type type, object host)
            => Delegate.CreateDelegate(type, host, src);
    }
}