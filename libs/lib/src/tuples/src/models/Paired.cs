//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// A non-homogenous mutable 2-tuple
    /// </summary>
    public struct Paired<T0,T1> : ITupled<Paired<T0,T1>,T0,T1>
    {
        /// <summary>
        /// The first member
        /// </summary>
        public T0 Left;

        /// <summary>
        /// The second member
        /// </summary>
        public T1 Right;

        [MethodImpl(Inline)]
        public Paired(T0 left, T1 right)
        {
            Left = left;
            Right = right;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out T0 a, out T1 b)
        {
            a = Left;
            b = Right;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Object.Equals(Left, default(T0)) && Object.Equals(Right, default(T1));
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        /// <summary>
        /// Interprets the pair over alternate domains
        /// </summary>
        /// <typeparam name="U">The alternate type</typeparam>
        [MethodImpl(Inline)]
        public Paired<S,T> As<S,T>()
            where S : unmanaged
            where T : unmanaged
                => Unsafe.As<Paired<T0,T1>,Paired<S,T>>(ref this);

        [MethodImpl(Inline)]
        public bool Equals(Paired<T0,T1> rhs)
            => Left.Equals(rhs.Left) && Right.Equals(rhs.Right);

        public string Format(TupleFormatKind style)
            => style switch
            {
                TupleFormatKind.Dimension => $"{Left}x{Right}",
                TupleFormatKind.Attribute => $"({Left}:{Right})",
                _ => $"({Left},{Right})"
            };

        public string Format()
            => Format(TupleFormatKind.Coordinate);

        public string Format(char delimiter)
            => string.Format("({0}{1}{2})", Left, delimiter, Right);

        public string Format(string delimiter)
            => string.Format("({0}{1}{2})", Left, delimiter, Right);

        public override int GetHashCode()
            => HashCode.Combine(Left,Right);

        public override bool Equals(object obj)
            => obj is Paired<T0,T1> x && Equals(x);

        public override string ToString()
            => Format();

        T0 ITupled<Paired<T0,T1>,T0,T1>.Left
        {
            [MethodImpl(Inline)]
            get => Left;
        }

        T1 ITupled<Paired<T0,T1>,T0,T1>.Right
        {
            [MethodImpl(Inline)]
            get => Right;
        }


        [MethodImpl(Inline)]
        public static implicit operator Paired<T0,T1>((T0 a, T1 b) src)
            => new Paired<T0, T1>(src.a, src.b);

        [MethodImpl(Inline)]
        public static bool operator ==(Paired<T0,T1> x, Paired<T0,T1> y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator !=(Paired<T0,T1> x, Paired<T0,T1> y)
            => x.Equals(y);

        public static Paired<T0,T1> Empty => default;
    }
}