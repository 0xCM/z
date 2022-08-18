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
        /// Removes a layer of parametricity from a projector
        /// </summary>
        /// <param name="src">The source projector</param>
        /// <typeparam name="S">The source domain</typeparam>
        /// <typeparam name="T">The target domain</typeparam>
        [MethodImpl(Inline)]
        public static ValueProjector<T> reduce<S,T>(ValueProjector<S,T> src)
            where S : struct
            where T : struct
                => reduce(src, sys.alloc<T>(1));

        /// <summary>
        /// Removes a layer of parametricity from a projector
        /// </summary>
        /// <param name="src">The source projector</param>
        /// <typeparam name="S">The source domain</typeparam>
        /// <typeparam name="T">The target domain</typeparam>
        [MethodImpl(Inline)]
        static ValueProjector<T> reduce<S,T>(ValueProjector<S,T> src, T[] dst)
            where S : struct
            where T : struct
                => new ValueProjector<T>(boxed(src.map, dst));
    }
}