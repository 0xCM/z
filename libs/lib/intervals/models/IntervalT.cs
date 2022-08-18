//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using K = IntervalKind;

    /// <summary>
    /// Defines a contiguous segment of homogenous values that lie within left and right boundaries
    /// </summary>
    /// <remarks>
    /// Note that models of extended real numbers may also serve as endpoints, enabling representations such as (-∞,3] and (-3, ∞).
    /// </remarks>
    public readonly struct Interval<T> : IInterval<T>
        where T : unmanaged
    {
        /// <summary>
        /// The left endpoint
        /// </summary>
        public readonly T Left;

        /// <summary>
        /// The right endpoint
        /// </summary>
        public readonly T Right;

        /// <summary>
        /// The interval classification
        /// </summary>
        public K Kind {get;}

        /// <summary>
        /// Specifies the canonical closed unit interval over the underlying primitive
        /// </summary>
        /// <typeparam name="T">The primal type</typeparam>
        public static Interval<T> U01
            => new Interval<T>(zero<T>(), one<T>(), K.Closed);

        /// <summary>
        /// Defines a closed interval that subsumes all points representable by the primal type
        /// </summary>
        public static Interval<T> Full
            => new Interval<T>(Limits.minval<T>(), Limits.maxval<T>(), K.Closed);

        /// <summary>
        /// Defines an open interval that subsumes all points representable by the primal type and all points represented
        /// by increasing the size of the primal type without altering other characteristics
        /// </summary>
        public static Interval<T> Unbound
            => new Interval<T>(Limits.minval<T>(), Limits.maxval<T>(), K.Open);

        [MethodImpl(Inline)]
        public static Interval<T> LeftUnbound(T right)
            => new Interval<T>(Limits.minval<T>(), right, K.LeftOpen);

        [MethodImpl(Inline)]
        public static Interval<T> RightUnbound(T left)
            => new Interval<T>(left, Limits.maxval<T>(), K.RightOpen);

        [MethodImpl(Inline)]
        static K Classify(bool leftclosed, bool rightclosed)
        {
            var closed = leftclosed && rightclosed;
            var open =  !leftclosed && !rightclosed;
            return
                  closed ? K.Closed
                : open ? K.Open
                : leftclosed && !rightclosed ? K.LeftClosed
                : K.RightClosed;
        }

        [MethodImpl(Inline)]
        public Interval(T left, bool leftclosed, T right, bool rightclosed)
        {
            Left = left;
            Right = right;
            Kind = Classify(leftclosed, rightclosed);
        }

        [MethodImpl(Inline)]
        public Interval(T left, T right, K kind)
        {
            Left = left;
            Right = right;
            Kind = kind;
        }

        public ulong Width
        {
            [MethodImpl(Inline)]
            get => Numeric.force<T,ulong>(Right) - Numeric.force<T,ulong>(Left);
        }

        /// <summary>
        /// Specifies whether the interval is left-closed, or equivalently right-open, denoted by [Left,Right),
        /// </summary>
        public bool LeftClosed
        {
            [MethodImpl(Inline)]
            get => Kind == K.LeftClosed;
        }

        /// <summary>
        /// Specifies whether the interval is right-closed, or equivalently left-open, denoted by (Left,Right],
        /// </summary>
        public bool RightClosed
        {
            [MethodImpl(Inline)]
            get => Kind == K.RightClosed;
        }

        /// <summary>
        /// Specifies whether the interval is open, denoted by (Left,Right)
        /// </summary>
        public bool Open
        {
            [MethodImpl(Inline)]
            get => Kind == K.Open;
        }

        /// <summary>
        /// Specifies whether the interval is closed, denoted by [Left,Right]
        /// </summary>
        public bool Closed
        {
            [MethodImpl(Inline)]
            get => Kind == K.Closed;
        }

        /// <summary>
        /// Specifies whether the interval is open on the right and closed on the left, denoted by [Left,Right)
        /// </summary>
        public bool RightOpen
        {
            [MethodImpl(Inline)]
            get => Kind == K.RightOpen;
        }

        /// <summary>
        /// Specifies whether the interval is open on the left and closed on the right, denoted by (Left,Right]
        /// </summary>
        public bool LeftOpen
        {
            [MethodImpl(Inline)]
            get => Kind == K.LeftOpen;
        }

        /// <summary>
        /// Specifies whether the interval is unbounded on the left, denoted by (-∞, right).
        /// </summary>
        public bool LeftUnbounded
        {
            [MethodImpl(Inline)]
            get => Kind == K.LeftOpen && Left.Equals(Limits.minval<T>());
        }

        /// <summary>
        /// Specifies whether the interval is unbounded on the left, denoted by (left, ∞).
        /// </summary>
        public bool RightUnbounded
        {
            [MethodImpl(Inline)]
            get => Kind == K.RightOpen && Right.Equals(Limits.maxval<T>());
        }

        /// <summary>
        /// Specifies whether the interval is unbounded on the left and right, denoted by (-∞, ∞).
        /// </summary>
        public bool Unbounded
        {
            [MethodImpl(Inline)]
            get => Kind == K.Open && Left.Equals(Limits.minval<T>()) && Right.Equals(Limits.maxval<T>());
        }

        /// <summary>
        /// Specifies whether the left and right enpoints are the same
        /// </summary>
        public bool Degenerate
        {
            [MethodImpl(Inline)]
            get => Left.Equals(Right);
        }

        /// <summary>
        /// Specifies whether the interval is the zero interval
        /// </summary>
        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Left.Equals(Right);
        }

        /// <summary>
        /// Specifies the zero interval
        /// </summary>
        public Interval<T> Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        /// <summary>
        /// Creates an open interval with endpoints from the existing interval
        /// </summary>
        [MethodImpl(Inline)]
        public Interval<T> ToOpen()
            => new Interval<T>(Left, Right, K.Open);

        /// <summary>
        /// Creates a left-open/right-closed interval with endpoints from the existing interval
        /// </summary>
        [MethodImpl(Inline)]
        public Interval<T> ToLeftOpen()
            => new Interval<T>(Left, Right, K.LeftOpen);

        /// <summary>
        /// Creates a left-open/right-closed interval with endpoints from the existing interval
        /// </summary>
        [MethodImpl(Inline)]
        public Interval<T> ToRightClosed()
            => new Interval<T>(Left, Right, K.RightClosed);

        /// <summary>
        /// Creates a left-open/right-closed interval with endpoints from the existing interval
        /// </summary>
        [MethodImpl(Inline)]
        public Interval<T> ToRightOpen()
            => new Interval<T>(Left, Right, K.RightOpen);

        /// <summary>
        /// Creates a left-closed interval with endpoints from the existing interval
        /// </summary>
        [MethodImpl(Inline)]
        public Interval<T> ToLeftClosed()
            => new Interval<T>(Left, Right, K.LeftClosed);

        /// <summary>
        /// Converts the left and right underlying values
        /// </summary>
        /// <typeparam name="U">The target type</typeparam>
        [MethodImpl(Inline)]
        public Interval<U> Convert<U>()
            where U : unmanaged, IComparable<U>, IEquatable<U>
                => new Interval<U>(Numeric.force<T,U>(Left), Numeric.force<T,U>(Right),Kind);

        /// <summary>
        /// Creates a view of the data in the inverval as seen through the
        /// lens of another type, but performs no conversion
        /// </summary>
        /// <typeparam name="U">The target type</typeparam>
        [MethodImpl(Inline)]
        public Interval<U> As<U>()
            where U : unmanaged, IComparable<U>, IEquatable<U>
                => new Interval<U>(@as<T,U>(Left), @as<T,U>(Right), Kind);

        [MethodImpl(Inline)]
        public void Deconstruct(out T left, out T right)
        {
            left = Left;
            right = Right;
        }

        [MethodImpl(Inline)]
        public Interval<T> New(T left, T right, K kind)
            => new Interval<T>(left, right, kind);

        [MethodImpl(Inline)]
        public string Format()
            => string.Concat(LeftSymbol, LeftFormat, Chars.Comma, RightFormat, RightSymbol);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public string Format(TupleFormatKind style)
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Interval<T> src)
            => Kind == src.Kind && Left.Equals(src.Left) && Right.Equals(src.Right);

        T IRange<T>.Min
            => Left;

        T IRange<T>.Max
            => Right;

        string LeftFormat
        {
            [MethodImpl(Inline)]
            get => LeftUnbounded ? "-∞" : Left.ToString();
        }

        string RightFormat
        {
            [MethodImpl(Inline)]
            get => RightUnbounded ? "∞" : Right.ToString();
        }

        char LeftSymbol
        {
            [MethodImpl(Inline)]
            get => (LeftClosed  || Closed) ? Chars.LBracket : Chars.LParen;
        }

        char RightSymbol
        {
            [MethodImpl(Inline)]
            get => (RightClosed || Closed) ? Chars.RBracket : Chars.RParen;
        }

        [MethodImpl(Inline)]
        public static implicit operator Interval<T>((T left, T right) x)
            => new Interval<T>(x.left, true, x.right, true);

        [MethodImpl(Inline)]
        public static implicit operator (T left, T right)(Interval<T> x)
            => (x.Left, x.Right);

        /// <summary>
        /// The interval of nothingness
        /// </summary>
        public static Interval<T> Empty => default;

    }
}