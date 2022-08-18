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
        /// Computes y := x |> f = f(x) for a unary operator f
        /// </summary>
        /// <param name="x">The left domain value</param>
        /// <param name="y">The right domain value</param>
        /// <param name="f">The binary operator</param>
        /// <typeparam name="F">The binary operator type</typeparam>
        /// <typeparam name="T">The operator domain type</typeparam>
        [MethodImpl(Inline)]
        public static T pipe<F,T>(T x, F f)
            where F : IUnaryOp<T>
                => f.Invoke(x);

        /// <summary>
        /// Computes y := x |> f |> g := g(f(x)) for unary operators f and g
        /// </summary>
        /// <param name="x">The input value</param>
        /// <param name="f">A unary operator</param>
        /// <param name="g">A unary operator</param>
        /// <typeparam name="F">The type of the first unary operator</typeparam>
        /// <typeparam name="G">The type of the second unary operator</typeparam>
        /// <typeparam name="T">The operator domain type</typeparam>
        [MethodImpl(Inline)]
        public static T pipe<F,G,T>(T x, F f, G g)
            where F : IUnaryOp<T>
            where G : IUnaryOp<T>
                => g.Invoke(f.Invoke(x));

        /// <summary>
        /// Computes y := x |> f |> g |> h := h(g(f(x))) for unary operators f, g and h
        /// </summary>
        /// <param name="x">The input value</param>
        /// <param name="f">A unary operator</param>
        /// <param name="g">A unary operator</param>
        /// <typeparam name="F">The type of the first unary operator</typeparam>
        /// <typeparam name="G">The type of the second unary operator</typeparam>
        /// <typeparam name="T">The operator domain type</typeparam>
        [MethodImpl(Inline)]
        public static T pipe<F,G,H,T>(T x, F f, G g)
            where F : IUnaryOp<T>
            where G : IUnaryOp<T>
            where H : IUnaryOp<T>
                => g.Invoke(g.Invoke(f.Invoke(x)));
    }
}