//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines kinded link
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct Arrow<S,T,K> : IArrow<S,T,K>
    {
        /// <summary>
        /// The kind classifier
        /// </summary>
        public readonly K Kind;

        /// <summary>
        /// The source
        /// </summary>
        public readonly S Source;

        /// <summary>
        /// The target
        /// </summary>
        public readonly T Target;

        [MethodImpl(Inline)]
        public Arrow(S src, T dst, K kind)
        {
            Kind = kind;
            Source = src;
            Target = dst;
        }

        public string Format()
            => $"{Kind}:{Source} -> {Target}";

        public override string ToString()
            => Format();

        K IArrow<S, T, K>.Kind
            => Kind;

        S IArrow<S,T>.Source
            => Source;

        T IArrow<S,T>.Target
            => Target;

        [MethodImpl(Inline)]
        public static implicit operator Arrow<S,T,K>((K k, S s, T t) src)
            => new Arrow<S,T,K>(src.s, src.t, src.k);

        [MethodImpl(Inline)]
        public static implicit operator (K k, S s, T t)(Arrow<S,T,K> x)
            => (x.Kind, x.Source, x.Target);
    }
}