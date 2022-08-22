//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// An homogenous mutable 2-tuple
    /// </summary>
    public record struct Pair<T> : ITupledPair<Pair<T>,T>
    {
        /// <summary>
        /// The first member
        /// </summary>
        public T Left;

        /// <summary>
        /// The second member
        /// </summary>
        public T Right;

        [MethodImpl(Inline)]
        public Pair(T left, T right)
        {
            Left = left;
            Right = right;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out T a, out T b)
        {
            a = Left;
            b = Right;
        }

        public T this[int i]
        {
            [MethodImpl(Inline)]
            get => i == 0 ? Left : Right;

            [MethodImpl(Inline)]
            set
            {
                if(i == 0)
                    Left = value;
                else
                    Right = value;
            }
        }

        /// <summary>
        /// Interprets the pair over an alternate domain
        /// </summary>
        /// <typeparam name="U">The alternate type</typeparam>
        [MethodImpl(Inline)]
        public Pair<U> As<U>()
            where U : unmanaged
                => Unsafe.As<Pair<T>,Pair<U>>(ref this);

        [MethodImpl(Inline)]
        public bool Equals(Pair<T> rhs)
            => Left.Equals(rhs.Left) && Right.Equals(rhs.Right);

        public string Format(TupleFormatKind style)
            => style == TupleFormatKind.Coordinate ? $"({Left},{Right})" : $"{Left}x{Right}";

        public string Format()
            => Format(TupleFormatKind.Coordinate);

        public override int GetHashCode()
            => HashCode.Combine(Left,Right);

        public override string ToString()
            => Format();

        public static Pair<T> Empty
            => new Pair<T>(default,default);

        T ITupledPair<Pair<T>,T>.Left
        {
            [MethodImpl(Inline)]
            get => Left;
        }

        T ITupledPair<Pair<T>, T>.Right
        {
            [MethodImpl(Inline)]
            get => Right;
        }

        [MethodImpl(Inline)]
        public static implicit operator Pair<T>((T a, T b) src)
            => new Pair<T>(src.a, src.b);
    }
}