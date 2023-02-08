//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes an individual term of a permutation p, i.e. the point
    /// of evaluation i and its image p(i)
    /// </summary>
    public readonly struct PermTerm
    {
        /// <summary>
        /// The point at which the permutation is evaluated
        /// </summary>
        public readonly int Source;

        /// <summary>
        /// The result of evaluating the permutation over the source
        /// </summary>
        public readonly int Target;

        [MethodImpl(Inline)]
        public PermTerm(int src, int dst)
        {
            Source = src;
            Target = dst;
        }

        public bool IsDegenerate
        {
            [MethodImpl(Inline)]
            get => Source == Target;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out int src, out int dst)
        {
            src = Source;
            dst = Target;
        }
        public string Format()
            => $"{Source} -> {Target}";

        [MethodImpl(Inline)]
        public bool Equals(PermTerm y)
            => Source == y.Source && Target == y.Target;

        [MethodImpl(Inline)]
        public override bool Equals(object obj)
            => obj is PermTerm t && Equals(t);

        public override int GetHashCode()
            => HashCode.Combine(Source,Target);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator PermTerm((int src, int dst) x)
            => new PermTerm(x.src, x.dst);

        [MethodImpl(Inline)]
        public static implicit operator (int src, int dst)(PermTerm x)
            => (x.Source, x.Target);

        [MethodImpl(Inline)]
        public static bool operator ==(PermTerm lhs, PermTerm rhs)
            => lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static bool operator !=(PermTerm lhs, PermTerm rhs)
            => !lhs.Equals(rhs);
    }
}