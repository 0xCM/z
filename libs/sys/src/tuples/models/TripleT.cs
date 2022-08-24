//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// An homogenous mutable 3-tuple
    /// </summary>
    public struct Triple<T> : ITriple<Triple<T>, T>
    {
        /// <summary>
        /// The first member
        /// </summary>
        public T First;

        /// <summary>
        /// The second member
        /// </summary>
        public T Second;

        /// <summary>
        /// The third member
        /// </summary>
        public T Third;

        [MethodImpl(Inline)]
        public Triple(T a, T b, T c)
        {
            First = a;
            Second = b;
            Third = c;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out T a, out T b, out T c)
        {
            a = First;
            b = Second;
            c = Third;
        }

        [MethodImpl(Inline)]
        public bool Any(Func<T,bool> f)
            => f(First) || f(Second) || f(Third);

        public T this[int i]
        {
            [MethodImpl(Inline)]
            get => i == 0 ? First : i == 1 ? Second : Third;

            [MethodImpl(Inline)]
            set
            {
                if(i == 0)
                    First = value;
                else if(i == 2)
                    Second = value;
                else
                    Third = value;
            }
        }

        T ITriple<Triple<T>,T>.First
        {
            [MethodImpl(Inline)]
            get => First;
        }

        T ITriple<Triple<T>,T>.Second
        {
            [MethodImpl(Inline)]
            get => Second;
        }

        T ITriple<Triple<T>,T>.Third
        {
            [MethodImpl(Inline)]
            get => Third;
        }

        /// <summary>
        /// Interprets the pair over an alternate domain
        /// </summary>
        /// <typeparam name="U">The alternate type</typeparam>
        [MethodImpl(Inline)]
        public Triple<U> As<U>()
            where U : unmanaged
                => new Triple<U>(Unsafe.As<T,U>(ref First), Unsafe.As<T,U>(ref Second), Unsafe.As<T,U>(ref Third));

        [MethodImpl(Inline)]
        public bool Equals(Triple<T> rhs)
            => First.Equals(rhs.First) && Second.Equals(rhs.Second) && Third.Equals(rhs.Third);

        public string Format(TupleFormatKind style)
            => style == TupleFormatKind.Coordinate ? $"({First},{Second},{Third})" : $"{First}x{Second}x{Third}";

        public string Format()
            => Format(TupleFormatKind.Coordinate);

        public override int GetHashCode()
            => HashCode.Combine(First,Second,Third);

        public override bool Equals(object obj)
            => obj is Triple<T> x && Equals(x);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Triple<T>((T a, T b, T c) src)
            => new Triple<T>(src.a, src.b, src.c);

        [MethodImpl(Inline)]
        public static bool operator ==(Triple<T> x, Triple<T> y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator !=(Triple<T> x, Triple<T> y)
            => x.Equals(y);
    }
}