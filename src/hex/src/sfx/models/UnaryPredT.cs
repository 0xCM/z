//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct UnaryPredSurrogate<T> : IFunc<T,bit>
    {
        public OpIdentity Id {get;}

        readonly Z0.UnaryPredicate<T> F;

        [MethodImpl(Inline)]
        public UnaryPredSurrogate(Z0.UnaryPredicate<T> f, OpIdentity id)
        {
            F = f;
            Id = id;
        }

        [MethodImpl(Inline)]
        public bit Invoke(T a)
            => F(a);

        public Z0.UnaryPredicate<T> Subject
        {
            [MethodImpl(Inline)]
            get => F;
        }

        [MethodImpl(Inline)]
        public SurrogateFunc<T,bit> AsFunc()
                => SFx.surrogate(this);

        [MethodImpl(Inline)]
        public static implicit operator SurrogateFunc<T,bit>(UnaryPredSurrogate<T> src)
            => src.AsFunc();
    }
}
