//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Characterizes (to the extent that the language conveniently supports) a disjoint union
    /// of parametric arity 2, a categorically natural dual to a pairing
    /// </summary>
    /// <typeparam name="L">The type of the potential left value</typeparam>
    /// <typeparam name="R">The type of the potential left value</typeparam>
    public readonly struct Copair<L,R>
    {
        /// <summary>
        /// The potential left value
        /// </summary>
        readonly Option<L> Left;

        /// <summary>
        /// The potential right value
        /// </summary>
        readonly Option<R> Right;

        [MethodImpl(Inline)]
        public Copair(L left)
        {
            Left = left;
            Right = Option.none<R>();
        }

        [MethodImpl(Inline)]
        public Copair(R right)
        {
            Left = Option.none<L>();
            Right = right;
        }
    }
}