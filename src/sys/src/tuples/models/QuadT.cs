//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    /// <summary>
    /// An homogenous immutable 4-tuple
    /// </summary>
    public record struct Quad<T> : ITupled<Quad<T>,T,T,T,T>
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

        /// <summary>
        /// The fourth member
        /// </summary>
        public T Fourth;

        [MethodImpl(Inline)]
        public Quad(T a, T b, T c, T d)
        {
            First = a;
            Second = b;
            Third = c;
            Fourth = d;
        }

        public T this[int i]
        {
            [MethodImpl(Inline)]
            get => i == 0 ? First : i == 1 ? Second : i == 2 ? Third : Fourth;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out T a, out T b, out T c, out T d)
        {
            a = First; b = Second; c = Third; d = Fourth;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(First, Second, Third, Fourth);
        }

        /// <summary>
        /// Interprets the pair over an alternate domain
        /// </summary>
        /// <typeparam name="U">The alternate type</typeparam>
        [MethodImpl(Inline)]
        public Quad<U> As<U>()
            where U : unmanaged
                => @as<Quad<T>,Quad<U>>(this);

        [MethodImpl(Inline)]
        public bool Equals(Quad<T> rhs)
            => First.Equals(rhs.First) && Second.Equals(rhs.Second) && Third.Equals(rhs.Third) && Fourth.Equals(rhs.Fourth);

        public string Format(TupleFormatKind style)
            => style == TupleFormatKind.Coordinate ? $"({First},{Second},{Third},{Fourth})" : $"{First}x{Second}x{Third}x{Fourth}";

        public string Format()
            => Format(TupleFormatKind.Coordinate);

        public override int GetHashCode()
            => Hash;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public Y Map<Y>(Func<Quad<T>,Y> f)
            => f(this);

        [MethodImpl(Inline)]
        public static implicit operator Quad<T>(in (T a, T b, T c, T d) src)
            => new Quad<T>(src.a,src.b,src.c,src.d);

        [MethodImpl(Inline)]
        public static implicit operator Quad<T>(in (ConstPair<T> a, ConstPair<T> b) src)
            => new Quad<T>(src.a.Left,src.a.Right, src.b.Left,src.b.Right);
    }
}