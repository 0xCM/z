//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using D = Z0;

    partial class Surrogates
    {
        /// <summary>
        /// Defines a delegate-predicated structural operator
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <param name="t">An operand type representative to aid type inference</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TernaryOp<T> ternary<T>(D.TernaryOp<T> f, string name, T t = default)
            => new TernaryOp<T>(f,name);

        /// <summary>
        /// Defines a delegate-predicated structural operator with identity
        /// </summary>
        /// <param name="f">The source delegate</param>
        /// <param name="id">The sfunc identity</param>
        /// <param name="t">An operand type representative to aid type inference</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TernaryOp<T> ternary<T>(D.TernaryOp<T> f, OpIdentity id, T t = default)
            => new TernaryOp<T>(f,id);
    }
}