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
    /// <typeparam name="X">The function return type</typeparam>
    public readonly struct XFunc<X>
    {
       /// <summary>
        /// The expression derived from the source function
        /// </summary>
        public Expression<Func<X>> Fx {get;}

        /// <summary>
        /// Implicitly converts a func expression to linq expression
        /// </summary>
        /// <param name="fx">The source func expression</param>
        [MethodImpl(Inline)]
        public static implicit operator Expression<Func<X>>(XFunc<X> fx)
            => fx.Fx;

        /// <summary>
        /// Implicitly constructs a func expression from a func
        /// </summary>
        /// <param name="f">The source function</param>
        [MethodImpl(Inline)]
        public static implicit operator XFunc<X>(Func<X> f)
            => new XFunc<X>(f);

        [MethodImpl(Inline)]
        public XFunc(Func<X> f)
            => Fx = () => f();
    }
}