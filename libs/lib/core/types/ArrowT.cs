//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Arrow<T> : IArrow<T>
    {
        public readonly T Source;

        public readonly T Target;

        [MethodImpl(Inline)]
        public Arrow(T src, T dst)
        {
            Source = src;
            Target = dst;
        }

        public string IdentityText
        {
            [MethodImpl(Inline)]
            get => string.Format(RpOps.Arrow, Source, Target);
        }

        T IArrow<T,T>.Source
            => Source;

        T IArrow<T,T>.Target
            => Target;

        public string Format()
            => IdentityText;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Arrow<T>((T src, T dst) x)
            => new Arrow<T>(x.src,x.dst);

        [MethodImpl(Inline)]
        public static implicit operator (T src, T dst)(Arrow<T> a)
            => (a.Source, a.Target);
    }
}