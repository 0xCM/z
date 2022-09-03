//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Linq.Expressions;

    using static Root;

    /// <summary>
    /// Wraps a delegate that implicitly converts into a LINQ expression
    /// </summary>
    /// <typeparam name="X">The function argument type</typeparam>
    /// <typeparam name="Y">The function return type</typeparam>
    public readonly struct XFunc<X,R>
    {
        /// <summary>
        /// The expression derived from the source function
        /// </summary>
        public Expression<Func<X,R>> Fx {get;}

        /// <summary>
        /// Implicitly converts a func expression to linq expression
        /// </summary>
        /// <param name="fx">The source func expression</param>
        [MethodImpl(Inline)]
        public static implicit operator Expression<Func<X,R>>(XFunc<X,R> fx)
            => fx.Fx;

        /// <summary>
        /// Implicitly constructs a func expression from a func
        /// </summary>
        /// <param name="f">The source function</param>
        [MethodImpl(Inline)]
        public static implicit operator XFunc<X,R>(Func<X,R> f)
            => new XFunc<X,R>(f);

        [MethodImpl(Inline)]
        public XFunc(Func<X,R> f)
            => Fx = x => f(x);
    }
}