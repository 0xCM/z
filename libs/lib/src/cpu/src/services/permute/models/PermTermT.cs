//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Describes an individual term of a permutation p: the point of evaluation i and its image p(i)
    /// </summary>
    public readonly struct PermTerm<T>
        where T : unmanaged
    {
        /// <summary>
        /// The point at which the permutation is evaluated
        /// </summary>
        public readonly T Source;

        /// <summary>
        /// The result of evaluating the permutation over the source
        /// </summary>
        public readonly T Target;

        [MethodImpl(Inline)]
        public PermTerm(T src, T dst)
        {
            Source = src;
            Target = dst;
        }

        public bool IsDegenerate
            => gmath.eq(Source,Target);

        [MethodImpl(Inline)]
        public void Deconstruct(out T src, out T dst)
        {
            src = Source;
            dst = Target;
        }

        [MethodImpl(Inline)]
        public (T i, T j) ToTuple()
            => (Source,Target);

        public override string ToString()
            => $"{Source} -> {Target}";

        [MethodImpl(Inline)]
        public static implicit operator PermTerm<T>((T src, T dst) x)
            => new PermTerm<T>(x.src, x.dst);

        [MethodImpl(Inline)]
        public static implicit operator (T src, T dst)(PermTerm<T> x)
            => (x.Source, x.Target);
    }
}