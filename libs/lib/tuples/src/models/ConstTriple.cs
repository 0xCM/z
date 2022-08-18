//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// An homogenous immutable 3-tuple
    /// </summary>
    public readonly struct ConstTriple<T> : ITriple<ConstTriple<T>, T>
    {
        /// <summary>
        /// The first member
        /// </summary>
        public readonly T First;

        /// <summary>
        /// The second member
        /// </summary>
        public readonly T Second;

        /// <summary>
        /// The third member
        /// </summary>
        public readonly T Third;

        [MethodImpl(Inline)]
        public ConstTriple(T a, T b, T c)
        {
            First = a; Second = b; Third = c;
        }

        public T this[int i]
        {
            [MethodImpl(Inline)]
            get => i == 0 ? First : i == 1 ? Second : Third;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out T a, out T b, out T c)
        {
            a = First; b = Second; c = Third;
        }

        /// <summary>
        /// Interprets the pair over an alternate domain
        /// </summary>
        /// <typeparam name="U">The alternate type</typeparam>
        [MethodImpl(Inline)]
        public ConstTriple<U> As<U>()
            where U : unmanaged
                => Unsafe.As<ConstTriple<T>,ConstTriple<U>>(ref Unsafe.AsRef(in this));

        [MethodImpl(Inline)]
        public bool Equals(ConstTriple<T> rhs)
            => First.Equals(rhs.First) && Second.Equals(rhs.Second) && Third.Equals(rhs.Third);

        public string Format(TupleFormatKind style)
            => style == TupleFormatKind.Coordinate ? $"({First},{Second},{Third})" : $"{First}x{Second}x{Third}";

        public string Format() => Format(TupleFormatKind.Coordinate);

        public override int GetHashCode()
            => Algs.hash(First,Second,Third);

        public override bool Equals(object obj)
            => obj is ConstTriple<T> x && Equals(x);

        public override string ToString()
            => Format();

        T ITriple<ConstTriple<T>,T>.First
        {
            [MethodImpl(Inline)]
            get => First;
        }

        T ITriple<ConstTriple<T>,T>.Second
        {
            [MethodImpl(Inline)]
            get => Second;
        }

        T ITriple<ConstTriple<T>,T>.Third
        {
            [MethodImpl(Inline)]
            get => Third;
        }


        [MethodImpl(Inline)]
        public static implicit operator ConstTriple<T>((T a, T b, T c) src)
            => new ConstTriple<T>(src.a,src.b,src.c);

        [MethodImpl(Inline)]
        public static bool operator ==(in ConstTriple<T> a, in ConstTriple<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(in ConstTriple<T> a, in ConstTriple<T> b)
            => a.Equals(b);
    }
}