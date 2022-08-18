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
    /// A value that realizes exactly one of two alternatives
    /// </summary>
    /// <typeparam name="L">The type of the left alternative</typeparam>
    /// <typeparam name="R">The type of the right alternative</typeparam>
    public readonly struct Either<L,R> : IEither<L,R>, IEquatable<Either<L,R>>
    {
        /// <summary>
        /// Tracks the chosen alternative
        /// </summary>
        EitherCase Selected {get;}

        /// <summary>
        /// Specifies the left alternative
        /// </summary>
        public L Left {get;}

        /// <summary>
        /// Specivies the right alternative
        /// </summary>
        public R Right {get;}

        [MethodImpl(Inline)]
        public static implicit operator Either<L,R>(L left)
            => new Either<L,R>(left);

        [MethodImpl(Inline)]
        public static implicit operator Either<L,R>(R right)
            => new Either<L,R>(right);

        [MethodImpl(Inline)]
        public static bool operator ==(Either<L,R> x, Either<L,R> y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator !=(Either<L,R> x, Either<L,R> y)
            => !x.Equals(y);

        /// <summary>
        /// Constructs a left-valued alternative
        /// </summary>
        /// <param name="left">The alternative value</param>
        [MethodImpl(Inline)]
        internal Either(L left)
        {
            this.Left = left;
            this.Selected = EitherCase.Left;
            this.Right = default;
        }

        /// <summary>
        /// Constructs a right-valued alternative
        /// </summary>
        /// <param name="right">The alternative value</param>
        [MethodImpl(Inline)]
        internal Either(R right)
        {
            Right = right;
            Selected = EitherCase.Right;
            Left = default;
        }

        internal enum EitherCase { Left, Right }

        /// <summary>
        /// Indicates whether the left alternative is specified
        /// </summary>
        public bool IsLeft
            => Selected == EitherCase.Left;

        /// <summary>
        /// Indicates whether the right alternative is specified
        /// </summary>
        public bool IsRight
            => Selected == EitherCase.Right;

        /// <summary>
        /// Invokes an action if the alternative is left-valued
        /// </summary>
        /// <param name="action">The action to invoke</param>
        public Either<L,R> OnLeft(Action<L> action)
        {
            if (Selected == EitherCase.Left)
                action(Left);
            return this;
        }

        /// <summary>
        /// Invokes an action if the alternative is right values
        /// </summary>
        /// <param name="action">The action to invoke</param>
        public Either<L,R> OnRight(Action<R> action)
        {
            if (Selected == EitherCase.Right)
                action(Right);
            return this;
        }

        /// <summary>
        /// Invokes exactly one of two alternative actions
        /// </summary>
        /// <param name="left">The action to invoke when the altenative is left-valued</param>
        /// <param name="right">The action to invoke when the altenative is right-valued</param>
        public void OnEither(Action<L> left, Action<R> right)
            => OnLeft(left).OnRight(right);

        /// <summary>
        /// Applies exactly one of two transformations
        /// </summary>
        /// <typeparam name="Y">The type of the output value</typeparam>
        /// <param name="left">The transformation to invoke when the alternative is left-valued</param>
        /// <param name="right">The transformation to invoke when the alternative is right-valued</param>
        public Y Map<Y>(Func<L,Y> left, Func<R,Y> right)
            => IsLeft ? left(Left) : right(Right);

        /// <summary>
        /// Defines a right-biased Linq-monad projector
        /// </summary>
        /// <param name="f">A function that projects a right value, if extant, onto a target value</param>
        /// <typeparam name="Y">The target value type</typeparam>
        public Either<L,Y> Select<Y>(Func<R,Y> f)
            => IsRight  ? f(Right) : new Either<L,Y>(Left);

        /// <summary>
        /// Defines a right-biased Linq-modad join
        /// </summary>
        /// <param name="f">A function that lifts a right value, if extant, into monadic space</param>
        /// <param name="g">A function that projects a right monadic source value onto a target-parametric target monadic value</param>
        /// <typeparam name="Y">The join type</typeparam>
        /// <typeparam name="Z">The target type</typeparam>
        public Either<L,Z> SelectMany<Y,Z>(Func<R, Either<L,Y>> f, Func<R,Y,Z> g)
        {
            if (IsLeft)
                return new Either<L,Z>(Left);

            var selected = f(Right);
            if (selected.IsLeft)
                return new Either<L,Z>(selected.Left);
            else
                return new Either<L,Z>(g(Right, selected.Right));
        }

        /// <summary>
        /// Determines structural equality
        /// </summary>
        /// <param name="src">The other either</param>
        public bool Equals(Either<L,R> src)
        {
            if (IsLeft && src.IsLeft)
                return Equals(Left, src.Left);
            else if (IsRight && src.IsRight)
                return Equals(Right, src.Right);
            else
                return false;
        }

        public override string ToString()
            => Map(left => $"Left({left})", right => $"Right({right})");

        public override int GetHashCode()
            => IsLeft ? Left.GetHashCode() : Right.GetHashCode();

        public override bool Equals(object obj)
            => obj is Either<L,R> e && Equals(e);
    }
}