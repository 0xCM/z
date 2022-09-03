//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct Arrow<S,T> : IArrow<S,T>
    {
        /// <summary>
        /// The source
        /// </summary>
        public readonly S Source;

        /// <summary>
        /// The target
        /// </summary>
        public readonly T Target;

        [MethodImpl(Inline)]
        public Arrow(S src, T dst)
        {
            Source = src;
            Target = dst;
        }

        S IArrow<S,T>.Source
            => Source;

        T IArrow<S,T>.Target
            => Target;

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RP.Arrow, Source, Target);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Arrow<S,T>((S src, T dst) x)
            => new Arrow<S,T>(x.src, x.dst);

        [MethodImpl(Inline)]
        public static implicit operator (S src, T dst)(Arrow<S,T> a)
            => (a.Source, a.Target);
    }
}