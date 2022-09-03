//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Constructs and manipulates <see cref="IEither"/> values
    /// </summary>
    /// <remarks>
    /// API surface inspired by https://github.com/ekmett/either
    /// </remarks>
    public static class Either
    {
        /// <summary>
        /// Constructs a left-valued either
        /// </summary>
        /// <typeparam name="L">The left value type</typeparam>
        /// <typeparam name="R">The right value type</typeparam>
        /// <param name="left">The right value</param>
        [MethodImpl(Inline)]
        public static Either<L,R> make<L,R>(L left)
            => new Either<L,R>(left);

        /// <summary>
        /// Constructs a left-valued either
        /// </summary>
        /// <typeparam name="L">The left value type</typeparam>
        /// <typeparam name="R">The right value type</typeparam>
        /// <param name="left">The right value</param>
        [MethodImpl(Inline)]
        public static Either<L,R> left<L,R>(L src)
            => new Either<L,R>(src);

        /// <summary>
        /// Constructs a right-valued either
        /// </summary>
        /// <typeparam name="L">The left value type</typeparam>
        /// <typeparam name="R">The right value type</typeparam>
        /// <param name="left">The right value</param>
        [MethodImpl(Inline)]
        public static Either<L,R> right<L,R>(R src)
            => new Either<L,R>(src);

        /// <summary>
        /// Constructs a right-valued either
        /// </summary>
        /// <typeparam name="L">The left value type</typeparam>
        /// <typeparam name="R">The right value type</typeparam>
        /// <param name="right">The right value</param>
        [MethodImpl(Inline)]
        public static Either<L,R> make<L,R>(R right)
            => new Either<L,R>(right);

        /// <summary>
        /// If either is Left, returns the left value; otherwise, raises an error
        /// </summary>
        /// <typeparam name="L">The left type</typeparam>
        /// <typeparam name="R">The right type</typeparam>
        /// <param name="e">The either</param>
        [MethodImpl(Inline)]
        public static L left<L,R>(Either<L,R> e)
            => e.IsLeft ? e.Left : fail<L>(NotLeft(e));

        /// <summary>
        /// If either is Left, returns the left value; otherwise, raises an error
        /// </summary>
        /// <typeparam name="L">The left type</typeparam>
        /// <typeparam name="R">The right type</typeparam>
        /// <param name="e">The either</param>
        [MethodImpl(Inline)]
        public static R right<L,R>(Either<L,R> e)
            => e.IsRight ? e.Right : fail<R>(NotRight(e));

        /// <summary>
        /// Applies the left function if the either is left-values and the right function if right
        /// </summary>
        /// <typeparam name="L">The left value type</typeparam>
        /// <typeparam name="R">The right value type</typeparam>
        /// <typeparam name="X">The left codomain</typeparam>
        /// <typeparam name="Y">The right codomain</typeparam>
        /// <param name="lf">The left function</param>
        /// <param name="rf">The right function</param>
        /// <param name="e">The either</param>
        [MethodImpl(Inline)]
        public static Either<X,Y> map<L,R,X,Y>(Func<L,X> lf, Func<R,Y> rf, Either<L,R> e)
            => e.IsLeft ? make<X,Y>(lf(e.Left)) : make<X,Y>(rf(e.Right));

        /// <summary>
        /// Applies a left function if the either is left-valued; otherwise, passes the right
        /// value through untransformed
        /// </summary>
        /// <typeparam name="L">The left value type</typeparam>
        /// <typeparam name="R">The right value type</typeparam>
        /// <typeparam name="Y">The codomain of the left function</typeparam>
        /// <param name="lf">The function to apply to the left value if present</param>
        /// <param name="e">The either</param>
        [MethodImpl(Inline)]
        public static Either<Y,R> map<L,R,Y>(Func<L,Y> lf, Either<L,R> e)
            => e.IsLeft ? make<Y,R>(lf(e.Left)) : make<Y,R>(e.Right);

        /// <summary>
        /// Applies a right function if the either is right-valued; otherwise, passes the left
        /// value through untransformed
        /// </summary>
        /// <typeparam name="L">The left value type</typeparam>
        /// <typeparam name="R">The right value type</typeparam>
        /// <typeparam name="Y">The codomain of the right function</typeparam>
        /// <param name="rf">The function to apply to the right value if present</param>
        /// <param name="e">The either</param>
        [MethodImpl(Inline)]
        public static Either<L,Y> map<L,R,Y>(Func<R,Y> rf, Either<L,R> e)
            => e.IsLeft ? make<L,Y>(e.Left) : make<L,Y>(rf(e.Right));

        /// <summary>
        /// Determines whether the either is left-valued
        /// </summary>
        /// <typeparam name="L">The left type</typeparam>
        /// <typeparam name="R">The right type</typeparam>
        /// <param name="e">The either</param>
        [MethodImpl(Inline)]
        public static bool isLeft<L,R>(Either<L,R> e)
            => e.IsLeft;

        /// <summary>
        /// Determines whether the either is right-valued
        /// </summary>
        /// <typeparam name="L">The left type</typeparam>
        /// <typeparam name="R">The right type</typeparam>
        /// <param name="e">The either</param>
        [MethodImpl(Inline)]
        public static bool isRight<L,R>(Either<L,R> e)
            => e.IsRight;

        static T fail<T>(string reason)
            => throw new Exception(reason);

        static string NotLeft<L,R>(Either<L,R> e)
            => $"The either value {e} is not a left value";

        static string NotRight<L,R>(Either<L,R> e)
            => $"The either value {e} is not a right value";
    }
}