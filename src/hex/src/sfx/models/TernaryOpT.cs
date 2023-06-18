//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TernarySurrogate<T> : ITernaryOp<T>
    {
        readonly TernaryOp<T> F;

        public OpIdentity Id {get;}

        [MethodImpl(Inline)]
        public TernarySurrogate(TernaryOp<T> f, OpIdentity id)
        {
            F = f;
            Id = id;
        }

        [MethodImpl(Inline)]
        public TernarySurrogate(TernaryOp<T> f, string name)
        {
            F = f;
            Id = OpIdentity.Empty;
        }

        [MethodImpl(Inline)]
        public T Invoke(T a, T b, T c) => F(a, b, c);

        public Z0.TernaryOp<T> Subject
        {
            [MethodImpl(Inline)]
            get => F;
        }

        [MethodImpl(Inline)]
        public SurrogateFunc<T,T,T,T> AsFunc()
            => SFx.surrogate(this);

        [MethodImpl(Inline)]
        public static implicit operator SurrogateFunc<T,T,T,T>(TernarySurrogate<T> src)
            => src.AsFunc();

        [MethodImpl(Inline)]
        public static implicit operator TernarySurrogate<T>(SurrogateFunc<T,T,T,T> src)
            => SFx.canonical(src);
    }
}
