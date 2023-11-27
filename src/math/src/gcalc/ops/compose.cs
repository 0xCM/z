//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct gcalc
    {
        /// <summary>
        /// Computes y := f(x,g(x)) for a unary operator g, and binary operator f
        /// </summary>
        /// <param name="x">The input value</param>
        /// <param name="f">A binary operator</param>
        /// <param name="g">A unary operator</param>
        /// <typeparam name="F">The binary operator type</typeparam>
        /// <typeparam name="G">The unary operator type</typeparam>
        /// <typeparam name="T">The type over which the operators are defined</typeparam>
        [MethodImpl(Inline)]
        public static T compose<F,G,T>(T x, F f, G g)
            where F : IBinaryOp<T>
            where G : IUnaryOp<T>
                => f.Invoke(x, g.Invoke(x));

        /// <summary>
        /// Computes y := f(g(x),g(y)) for a unary operator g, and binary operator f
        /// </summary>
        /// <param name="x">The input value</param>
        /// <param name="f">A binary operator</param>
        /// <param name="g">A unary operator</param>
        /// <typeparam name="F">The binary operator type</typeparam>
        /// <typeparam name="G">The unary operator type</typeparam>
        /// <typeparam name="T">The type over which the operators are defined</typeparam>
        [MethodImpl(Inline)]
        public static T compose<F,G,T>(T x, T y, F f, G g)
            where F : IBinaryOp<T>
            where G : IUnaryOp<T>
                => f.Invoke(g.Invoke(x), g.Invoke(y));
    }
}