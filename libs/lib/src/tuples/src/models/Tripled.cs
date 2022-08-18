//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a non-homogenous mutable 3-tuple
    /// </summary>
    /// <typeparam name="T0">The type of the first member</typeparam>
    /// <typeparam name="T1">The type of the second member</typeparam>
    /// <typeparam name="T2">The type of the third member</typeparam>
    public struct Tripled<T0,T1,T2> : ITupled<Tripled<T0,T1,T2>,T0,T1,T2>
    {
        /// <summary>
        /// The first member
        /// </summary>
        public T0 First;

        /// <summary>
        /// The second member
        /// </summary>
        public T1 Second;

        /// <summary>
        /// The third member
        /// </summary>
        public T2 Third;

        [MethodImpl(Inline)]
        public Tripled(T0 a, T1 b, T2 c)
        {
            this.First = a;
            this.Second = b;
            this.Third = c;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out T0 a, out T1 b, out T2 c)
        {
            a = this.First;
            b = this.Second;
            c = this.Third;
        }

        /// <summary>
        /// Interprets the pair over alternate domains
        /// </summary>
        /// <typeparam name="U">The alternate type</typeparam>
        [MethodImpl(Inline)]
        public Tripled<S,T,U> As<S,T,U>()
            where S : unmanaged
            where T : unmanaged
            where U : unmanaged
                => Unsafe.As<Tripled<T0,T1,T2>,Tripled<S,T,U>>(ref this);

        [MethodImpl(Inline)]
        public bool Equals(Tripled<T0,T1,T2> rhs)
            => First.Equals(rhs.First) && Second.Equals(rhs.Second) && Third.Equals(rhs.Third);

        public string Format(TupleFormatKind style)
            => style == TupleFormatKind.Coordinate ? $"({First},{Second},{Third})" : $"{First}x{Second}x{Third}";
        public string Format()
            => Format(TupleFormatKind.Coordinate);

        public override int GetHashCode()
            => HashCode.Combine(First,Second);

        public override bool Equals(object obj)
            => obj is Paired<T0,T1> x && Equals(x);

        public override string ToString()
            => Format();

        T0 ITupled<Tripled<T0, T1, T2>, T0, T1, T2>.First
        {
            [MethodImpl(Inline)]
            get => First;
        }

        T1 ITupled<Tripled<T0, T1, T2>, T0, T1, T2>.Second
        {
            [MethodImpl(Inline)]
            get => Second;
        }

        T2 ITupled<Tripled<T0, T1, T2>, T0, T1, T2>.Third
        {
            [MethodImpl(Inline)]
            get => Third;
        }

        [MethodImpl(Inline)]
        public static implicit operator Tripled<T0,T1,T2>((T0 a, T1 b, T2 c) src)
            => new Tripled<T0, T1, T2>(src.a, src.b, src.c);

        [MethodImpl(Inline)]
        public static bool operator ==(Tripled<T0,T1,T2> x, Tripled<T0,T1,T2> y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator !=(Tripled<T0,T1,T2> x, Tripled<T0,T1,T2> y)
            => x.Equals(y);
    }
}