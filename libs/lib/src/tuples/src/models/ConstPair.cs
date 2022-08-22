//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// An homogenous immutable 2-tuple
    /// </summary>
    public readonly record struct ConstPair<T> : ITupledPair<ConstPair<T>,T>
    {
        /// <summary>
        /// The first/left/lo member of the pair
        /// </summary>
        public readonly T Left;

        /// <summary>
        /// The second/right/hi member of the pair
        /// </summary>
        public readonly T Right;

        [MethodImpl(Inline)]
        public ConstPair(T left, T right)
        {
            Left = left;
            Right = right;
        }

        public T this[int i]
        {
            [MethodImpl(Inline)]
            get => i == 0 ? Left : Right;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out T left, out T right)
        {
            left = Left;
            right = Right;
        }

        T ITupledPair<ConstPair<T>,T>.Left
        {
            [MethodImpl(Inline)]
            get => Left;
        }

        T ITupledPair<ConstPair<T>,T>.Right
        {
            [MethodImpl(Inline)]
            get => Right;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Left,Right);
        }

        /// <summary>
        /// Presents the source T-pair as a U-pair
        /// </summary>
        /// <typeparam name="U">The target type</typeparam>
        [MethodImpl(Inline)]
        public ConstPair<U> As<U>()
            where U : unmanaged
                => Unsafe.As<ConstPair<T>,ConstPair<U>>(ref Unsafe.AsRef(in this));

        [MethodImpl(Inline)]
        public bool Equals(ConstPair<T> rhs)
            => Left.Equals(rhs.Left) && Right.Equals(rhs.Right);

        public string Format(TupleFormatKind style)
            => style == TupleFormatKind.Coordinate ? $"({Left},{Right})" : $"{Left}x{Right}";

        public string Format()
            => Format(TupleFormatKind.Coordinate);

        public override int GetHashCode()
            => Hash;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ConstPair<T>(in Pair<T> src)
            => new ConstPair<T>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator ConstPair<T>((T a, T b) src)
            => new ConstPair<T>(src.a, src.b);

        [MethodImpl(Inline)]
        public static bool operator ==(in ConstPair<T> left, in ConstPair<T> right)
            => left.Equals(right);

        [MethodImpl(Inline)]
        public static bool operator !=(in ConstPair<T> left, in ConstPair<T> right)
            => !left.Equals(right);
    }
}