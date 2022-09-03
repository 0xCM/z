//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using D = Z0;

    partial class Surrogates
    {
        /// <summary>
        /// Defines a delegate-predicated structural emitter
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <param name="t">An operand type representative to aid type inference</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Emitter<T> emitter<T>(D.Producer<T> f, string name, T t = default)
            => new Emitter<T>(f,name);

        /// <summary>
        /// Defines an identified structural emitter predicated on a delegate
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <param name="id">The sfunc identity</param>
        /// <param name="t">An operand type representative to aid type inference</param>
        /// <typeparam name="T">The emission type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Emitter<T> emitter<T>(D.Producer<T> f, OpIdentity id, T t = default)
            => new Emitter<T>(f,id);
    }
}