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
        /// Defines a delegate-predicated structural predicate
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <param name="t">An operand type representative to aid type inference</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryPredicate<T> predicate<T>(D.BinaryPredicate<T> f, string name, T t = default)
            => new BinaryPredicate<T>(f,name);

        /// <summary>
        /// Defines a delegate-predicated structural predicate with identity
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <param name="id">The sfunc identity</param>
        /// <param name="t">An operand type representative to aid type inference</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static UnaryPredicate<T> predicate<T>(D.UnaryPredicate<T> f, OpIdentity id, T t = default)
            => new UnaryPredicate<T>(f, id);

        /// <summary>
        /// Defines a delegate-predicated structural predicate with identity
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <param name="id">The sfunc identity</param>
        /// <param name="t">An operand type representative to aid type inference</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryPredicate<T> predicate<T>(D.BinaryPredicate<T> f, OpIdentity id, T t = default)
            => new BinaryPredicate<T>(f,id);
    }
}