//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq.Expressions;

    [ApiHost]
    public partial class Delegates
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Infers a delegate type compatible with the signature of a specified method
        /// </summary>
        /// <param name="src">The source method</param>
        public static Type type(MethodInfo src)
        {
            var args = src.ParameterTypes();
            return src.IsAction()
                ? Expression.GetActionType(args)
                : Expression.GetFuncType(sys.concat(args, sys.array(src.ReturnType)));
        }

        [Free]
        public delegate bool TernaryPredicate<W,T>(T a, T b, T c)
            where W : unmanaged, ITypeWidth;

        /// <summary>
        /// Characterizes a unary operator with known operand width
        /// </summary>
        /// <param name="a">The operand</param>
        /// <typeparam name="W">The width type</typeparam>
        /// <typeparam name="T">The operand type</typeparam>
        [Free]
        public delegate T UnaryOp<W,T>(T a)
            where W : unmanaged, ITypeWidth;

        /// <summary>
        /// Characterizes a function that produces a stream of values
        /// </summary>
        /// <param name="count">If specified, the number of elements to produce</param>
        /// <typeparam name="T">The emission type</typeparam>
        [Free]
        public delegate IEnumerable<T> StreamEmitter<T>();

        /// <summary>
        /// Characterizes a function that produces a stream of values
        /// </summary>
        /// <param name="count">If specified, the number of elements to produce</param>
        /// <typeparam name="T">The emission type</typeparam>
        [Free]
        public delegate IEnumerable<T> ValueStreamEmitter<T>()
            where T : struct;

        /// <summary>
        /// Characterizes a binary operator with known operand width
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="W">The width type</typeparam>
        /// <typeparam name="T">The operand type</typeparam>
        [Free]
        public delegate T BinaryOp<W,T>(T a, T b)
            where W : unmanaged, ITypeWidth;

        /// <summary>
        /// Characterizes a ternary operator with known operand width
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        /// <typeparam name="W">The width type</typeparam>
        /// <typeparam name="T">The operand type</typeparam>
        [Free]
        public delegate T TernaryOp<W,T>(T a, T b, T c)
            where W : unmanaged, ITypeWidth;

        [Free]
        public delegate bit UnaryPredicate<W,T>(T a)
            where W : unmanaged, ITypeWidth;

        [Free]
        public delegate T Projector<T>(in T src);

        /// <summary>
        /// Characterizes a parametric projector
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="S">The operand type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [Free]
        public delegate T Projector<S,T>(in S src);

        [Free]
        public delegate ref T RefProjector<S,T>(in T src, ref T dst);

        [Free]
        public delegate int RefComparer<T>(in T key, in T value);

        /// <summary>
        /// Characterizes a function that produces spans values
        /// </summary>
        /// <typeparam name="T">The emission type</typeparam>
        [Free]
        public delegate Span<T> SpanProducer<T>();
    }
}