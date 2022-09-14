//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using K = IntervalKind;

    /// <summary>
    /// Defines a closed T-interval where an ordering on T is assumed to exist and be well-defined
    /// </summary>
    public readonly struct ClosedInterval<T> : IInterval<T>, IEquatable<ClosedInterval<T>>
        where T : unmanaged, IEquatable<T>
    {
        /// <summary>
        /// The left endpoint
        /// </summary>
        public readonly T Min;

        /// <summary>
        /// The right endpoint
        /// </summary>
        public readonly T Max;

        [MethodImpl(Inline)]
        public ClosedInterval(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public ConstPair<T> Pair
        {
            [MethodImpl(Inline)]
            get => new ConstPair<T>(Min, Max);
        }

        public ulong Width
        {
            [MethodImpl(Inline)]
            get => Right64u - Left64u;
        }

        public bool Valid
        {
            [MethodImpl(Inline)]
            get => Right64i - Left64i > 0;
        }

        public bool Invalid
        {
            [MethodImpl(Inline)]
            get => !Valid;
        }

        public bool IsDegenerate
        {
            [MethodImpl(Inline)]
            get => Min.Equals(Max);
        }

        public bool IsNonDegenrate
        {
            [MethodImpl(Inline)]
            get => !Min.Equals(Max);
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out T left, out T right)
        {
            left = Min;
            right = Max;
        }

        public string Format()
            => IsDegenerate ? Min.ToString() : string.Concat(Chars.LBracket, Min, Chars.Comma, Max, Chars.RBracket);

        [MethodImpl(Inline)]
        public string Format(TupleFormatKind style)
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(ClosedInterval<T> src)
            => Min.Equals(src.Min) && Max.Equals(src.Max);

        public override string ToString()
            => Format();

        long Left64i
        {
            [MethodImpl(Inline)]
            get => @as<T,long>(Min);
        }

        long Right64i
        {
            [MethodImpl(Inline)]
            get => @as<T,long>(Max);
        }

        ulong Left64u
        {
            [MethodImpl(Inline)]
            get => @as<T,ulong>(Min);
        }

        ulong Right64u
        {
            [MethodImpl(Inline)]
            get => @as<T,ulong>(Max);
        }

        T IRange<T>.Min
            => Min;

        T IRange<T>.Max
            => Max;

        bool IInterval.LeftClosed
            => true;

        bool IInterval.RightClosed
            => true;

        /// <summary>
        /// The interval classification
        /// </summary>
        K IInterval.Kind
            => K.Closed;

        [MethodImpl(Inline)]
        public static implicit operator ClosedInterval<T>((T left, T right) x)
            => new ClosedInterval<T>(x.left, x.right);

        [MethodImpl(Inline)]
        public static implicit operator Interval<T>(ClosedInterval<T> src)
            => new Interval<T>(src.Min, src.Max, IntervalKind.Closed);

        [MethodImpl(Inline)]
        public static implicit operator (T left, T right)(ClosedInterval<T> x)
            => (x.Min, x.Max);

        [MethodImpl(Inline)]
        public static implicit operator ConstPair<T>(ClosedInterval<T> x)
            => x.Pair;

        [MethodImpl(Inline)]
        public static implicit operator ClosedInterval<T>(ConstPair<T> x)
            => new ClosedInterval<T>(x.Left, x.Right);

        /// <summary>
        /// The interval of nothingness
        /// </summary>
        public static ClosedInterval<T> Zero
            => default;

        /// <summary>
        /// The interval of everything
        /// </summary>
        public static ClosedInterval<T> Full
        {
            [MethodImpl(Inline)]
            get => new ClosedInterval<T>(Limits.minval<T>(), Limits.maxval<T>());
        }
    }
}