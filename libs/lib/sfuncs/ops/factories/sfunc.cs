//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct SFx
    {
        /// <summary>
        /// Creates a structural function of specified parametric type
        /// </summary>
        /// <typeparam name="S">The host type</typeparam>
        [MethodImpl(Inline)]
        public static S sfunc<S>()
            where S : unmanaged, IFunc
                => default(S);

        /// <summary>
        /// Creates a structural function of specified parametric type
        /// </summary>
        /// <typeparam name="S">The host type</typeparam>
        [MethodImpl(Inline)]
        public static S sfunc<W,S>(W w = default, S s = default)
            where S : unmanaged, IFuncW<W>
            where W : unmanaged, ITypeWidth
                => default(S);

        /// <summary>
        /// Creates a structural function of specified parametric type
        /// </summary>
        /// <typeparam name="S">The host type</typeparam>
        [MethodImpl(Inline)]
        public static S sfunc<W,S,T>(W w = default, S s = default, T t = default)
            where S : unmanaged, IFuncWT<W,T>
            where W : unmanaged, ITypeWidth
                => default(S);
    }
}