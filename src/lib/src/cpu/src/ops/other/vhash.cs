//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    partial struct gcpu
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint vhash<T>(Vector128<T> src)
            where T : unmanaged
        {
            var v = v64u(src);
            return alg.hash.combine(cpu.vcell(v,0), cpu.vcell(v,1));
        }

        /// <summary>
        /// Creates a 128-bit hash code predicated on four type parameters
        /// </summary>
        /// <typeparam name="A">The first type</typeparam>
        /// <typeparam name="B">The second type</typeparam>
        /// <typeparam name="C">The third type</typeparam>
        /// <typeparam name="D">The fourth type</typeparam>
        [MethodImpl(Inline)]
        public static Vector128<uint> vhash<A,B,C,D>()
            => cpu.vparts(w128, alg.ghash.calc<A>(), alg.ghash.calc<B>(), alg.ghash.calc<C>(), alg.ghash.calc<D>());
    }
}